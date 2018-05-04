using SQLite;

namespace WideWorldCalendar.Persistence
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
