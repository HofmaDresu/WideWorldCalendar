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

        private static readonly Lazy<Data> LazyData = new Lazy<Data>();

        public static Data GetInstance()
        {
            var instance = LazyData.Value;
            instance.Initalize();
            return instance;
        }

        private void Initalize()
        {
            _db = DependencyService.Get<ISQLite>().GetConnection();

            _db.CreateTable<MyTeam>();
            _db.CreateTable<Game>();
            _db.CreateTable<OpposingTeam>();
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
    }
}
