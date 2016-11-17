using Xamarin.Forms;
using System;
using System.IO;
using SQLite;
using WideWorldCalendar.iOS;
using WideWorldCalendar.Persistence;

[assembly: Dependency(typeof(SQLite_iOS))]
namespace WideWorldCalendar.iOS
{
    public class SQLite_iOS : ISQLite
    {
        SQLiteConnection ISQLite.GetConnection()
        {
            const string sqliteFilename = "WideWorldCalendar.db3";
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
            var libraryPath = Path.Combine(documentsPath, "..", "Library"); // Library folder
            var path = Path.Combine(libraryPath, sqliteFilename);
            // Create the connection
            var conn = new SQLiteConnection(path);
            // Return the database connection
            return conn;
        }
    }
}
