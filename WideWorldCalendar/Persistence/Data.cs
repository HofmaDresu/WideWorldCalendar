﻿using System;
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

        #region Divisions
        public bool IsNewDivision(string seasonName)
        {
            return Seasons.Any(d => d.Name == seasonName);
        }

        public void UpdateDivisions(List<string> seasonNames)
        {
            _db.DeleteAll<Season>();
            _db.InsertAll(seasonNames.Select(n => new Season { Name = n}));
        }
        #endregion

        #region Notifications

        public IEnumerable<GameNotification> GetTodaysNotifications()
        {
            var teamsWithReminders = GetMyCurrentTeams().Where(t => t.SendGameTimeReminders).ToList();
            var todaysTeamGamesWithReminders =
                teamsWithReminders.SelectMany(
                    t => GetGames(t.Id).Where(g => g.ScheduledDateTime.Date == DateTime.Now.Date))
                    .GroupBy(g => g.MyTeamId);

            foreach (var teamGames in todaysTeamGamesWithReminders)
            {
                string notificationTitle;

                switch (teamGames.Count())
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
                var currentTeam = teamsWithReminders.First(t => t.Id == teamGames.Key);
                var notificationMessage =
                    $"{currentTeam.TeamName} @ {string.Join(",", teamGames.Select(g => g.ScheduledDateTime.ToString("t")))}";

                yield return new GameNotification
                {
                    TeamId = currentTeam.Id,
                    Title = notificationTitle,
                    Message = notificationMessage
                };
            }
        }
        #endregion
    }
}
