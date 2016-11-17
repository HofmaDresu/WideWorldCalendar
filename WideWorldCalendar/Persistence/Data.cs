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
        }

        public List<MyTeam> GetMyTeams()
        {
            return MyTeams.ToList();
        }

        public void DeleteTeam(int id)
        {
            _db.Delete<MyTeam>(id);
        }

        public void InsertTeam(MyTeam newExerciseBlock)
        {
            _db.Insert(newExerciseBlock);
        }
    }
}
