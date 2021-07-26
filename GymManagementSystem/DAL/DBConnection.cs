using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace GymManagementSystem.DAL
{
    class DBConnection
    {
        private readonly SQLiteConnectionStringBuilder DBConnectionString = new SQLiteConnectionStringBuilder();
        private static DBConnection instance = null;

        public static DBConnection Instance => instance ?? (instance = new DBConnection());

        public SQLiteConnection Connection => new SQLiteConnection(DBConnectionString.ToString());

        private DBConnection()
        {
            DBConnectionString.DataSource = Properties.Settings.Default.DataSource;
            DBConnectionString.Version = Properties.Settings.Default.Version;
        }
    }
}
