using System;
using System.Collections.Generic;
using System.Linq;
using SQLite;
using WideWorldCalendar.Persistence.Models;
using Xamarin.Forms;

namespace WideWorldCalendar.Persistence
{
    public class Data
    {
        private SQLiteConnection _db;
        private IEnumerable<MyTeam> MyTeams => _db.Table<MyTeam>();
        private IEnumerable<OpposingTeam> OpposingTeams => _db.Table<OpposingTeam>();
        private IEnumerable<Game> Games => _db.Table<Game>();
        private IEnumerable<Season> Seasons => _db.Table<Season>();

        private static readonly Lazy<Data> LazyData = new Lazy<Data>();

        public static Data GetInstance(SQLiteConnection connection = null)
        {
            var instance = LazyData.Value;
            instance.Initalize(connection);
            return instance;
        }

        private void Initalize(SQLiteConnection connection = null)
        {
            _db = connection ?? DependencyService.Get<ISQLite>().GetConnection();

            _db.CreateTable<MyTeam>();
            _db.CreateTable<Game>();
            _db.CreateTable<OpposingTeam>();
            _db.CreateTable<Season>();
            _db.CreateTable<DeviceData>();
            _db.CreateTable<GameNotificationPreference>();

            if (!_db.Table<DeviceData>().Any())
            {
                _db.Insert(new DeviceData
                {
                    ShowGameNotifications = true,
                    ShowNewSeasonAvailableNotifications = true,
                    ShowScheduleChangedNotifications = true
                });
            }

            if (!_db.Table<GameNotificationPreference>().Any())
            {
                _db.Insert(new GameNotificationPreference
                {
                    Day = DayPreference.DayBefore,
                    Hour = 11,
                    Meridian = Meridian.Am
                });
            }
        }

        #region MyTeams
        public List<MyTeam> GetMyTeams()
        {
            return MyTeams.ToList();
        }
        public List<MyTeam> GetMyCurrentTeams()
        {
            return MyTeams.Where(t => t.LastGameDateTime.Date >= DateTime.Now.Date).ToList();
        }
        public List<MyTeam> GetMyPastTeams()
        {
            return MyTeams.Where(t => t.LastGameDateTime.Date < DateTime.Now.Date).ToList();
        }

        public void DeleteMyTeam(int id)
        {
            _db.Delete<MyTeam>(id);
            DeleteGames(id);
        }

        public void InsertMyTeam(MyTeam myTeam)
        {
            DeleteMyTeam(myTeam.Id);
            _db.Insert(myTeam);
        }
        #endregion

        #region OpposingTeams
        public List<OpposingTeam> GetOpposingTeams()
        {
            return OpposingTeams.ToList();
        }

        public OpposingTeam GetOpposingTeam(int id)
        {
            return _db.Get<OpposingTeam>(id);
        }

        public void DeleteOpposingTeam(int id)
        {
            _db.Delete<OpposingTeam>(id);
        }

        public void InsertOpposingTeam(OpposingTeam opposingTeam)
        {
            _db.Insert(opposingTeam);
        }
        #endregion

        #region OpposingTeams
        public List<Game> GetGames(int myTeamId)
        {
            var enumerable = Games.Where(g => g.MyTeamId == myTeamId).ToList();
            return enumerable
                .Select(g =>
                {
                    g.OpposingTeam = GetOpposingTeam(g.OpposingTeamId);
                    return g;
                }).ToList();
        }

        public void DeleteGames(int myTeamId)
        {
            var games = GetGames(myTeamId);
            var opposingTeams = games.Select(g => g.OpposingTeam);
            foreach (var team in opposingTeams)
            {
                _db.Delete(team);
            }
            foreach (var game in games)
            {
                _db.Delete(game);
            }
        }

        public void InsertGame(Game game)
        {
            InsertOpposingTeam(game.OpposingTeam);
            game.OpposingTeamId = game.OpposingTeam.Id;
            _db.Insert(game);
        }
        #endregion

        #region Seasons
        public bool IsNewSeason(string seasonName)
        {
			return Seasons.Any() && Seasons.All(d => d.Name != seasonName);
        }

        public void UpdateSeasons(List<string> seasonNames)
        {
            _db.DeleteAll<Season>();
            _db.InsertAll(seasonNames.Select(n => new Season { Name = n}));
        }
        #endregion

        #region Notifications

        public IEnumerable<GameNotification> GetNotificationsForDay(DateTime checkDate)
        {
            var teamsWithReminders = GetMyCurrentTeams().Where(t => t.SendGameTimeReminders).ToList();
            var todaysTeamGamesWithReminders =
                teamsWithReminders.SelectMany(
                    t => GetGames(t.Id).Where(g => g.ScheduledDateTime.Date == checkDate.Date))
                    .GroupBy(g => g.MyTeamId);

            foreach (var teamGames in todaysTeamGamesWithReminders)
            {
                var notificationTitle = GetNotificationTitle(teamGames);

                var currentTeam = teamsWithReminders.First(t => t.Id == teamGames.Key);
                var notificationMessage = GetNotificationMessage(currentTeam, teamGames);

                yield return new GameNotification
                {
                    TeamId = currentTeam.Id,
                    TeamNameAndColor = currentTeam.NameAndColor,
                    Title = notificationTitle,
                    Message = notificationMessage,
                    FirstGameTime = teamGames?.FirstOrDefault()?.ScheduledDateTime
                };
            }
        }

        public IEnumerable<GameNotification> GetAllGameNotifications()
        {
            var teamsWithReminders = GetMyCurrentTeams().Where(t => t.SendGameTimeReminders).ToList();

            foreach (var team in teamsWithReminders)
            {
                var teamGamesWithReminders = GetGames(team.Id).Where(g => g.ScheduledDateTime.Date >= DateTime.Now.Date).GroupBy(g => g.ScheduledDateTime.Date);

                foreach (var teamGames in teamGamesWithReminders)
                {
                    var notificationTitle = GetNotificationTitle(teamGames);

                    var notificationMessage = GetNotificationMessage(team, teamGames);

                    yield return new GameNotification
                    {
                        TeamId = team.Id,
                        TeamNameAndColor = team.NameAndColor,
                        Title = notificationTitle,
                        Message = notificationMessage,
                        FirstGameTime = teamGames?.FirstOrDefault()?.ScheduledDateTime
                    };
                }

            }
        }

        private string GetNotificationMessage(MyTeam team, IEnumerable<Game> games)
        {
            return $"{team.TeamName} @ {string.Join(",", games.Select(g => g.ScheduledDateTime.ToString("t")))}";
        }

        private string GetNotificationTitle(IEnumerable<Game> games)
        {
            string notificationTitle;

            switch (games.Count())
            {
                case 1:
                    notificationTitle = "Game Tonight!";
                    break;
                case 2:
                    notificationTitle = "Double Header Tonight!";
                    break;
                case 3:
                    notificationTitle = "Triple Header Tonight!";
                    break;
                default:
                    notificationTitle = "Games Tonight!";
                    break;
            }
            return notificationTitle;
        }
        #endregion

        #region devicedata
        public bool ShowGameNotifications()
        {
            return _db.Table<DeviceData>().Single().ShowGameNotifications;
        }

        public void SetShowGameNotifications(bool show)
        {
            var data = _db.Table<DeviceData>().Single();
            data.ShowGameNotifications = show;
            _db.Update(data);
        }

        public bool ShowScheduleChangedNotifications()
        {
            return _db.Table<DeviceData>().Single().ShowScheduleChangedNotifications;
        }

        public void SetShowScheduleChangedNotifications(bool show)
        {
            var data = _db.Table<DeviceData>().Single();
            data.ShowScheduleChangedNotifications = show;
            _db.Update(data);
        }

        public bool ShowNewSeasonAvailableNotifications()
        {
            return _db.Table<DeviceData>().Single().ShowNewSeasonAvailableNotifications;
        }

        public void SetShowNewSeasonAvailableNotifications(bool show)
        {
            var data = _db.Table<DeviceData>().Single();
            data.ShowNewSeasonAvailableNotifications = show;
            _db.Update(data);
        }
        #endregion

        #region GameNotificationPreferences
        public GameNotificationPreference GetGameNotificationPreferences()
        {
            return _db.Table<GameNotificationPreference>().Single();
        }

        public void SetGameNotificationPreferences(GameNotificationPreference preference)
        {
            _db.DeleteAll<GameNotificationPreference>();
            _db.Insert(preference);
        }
        #endregion
    }
}
