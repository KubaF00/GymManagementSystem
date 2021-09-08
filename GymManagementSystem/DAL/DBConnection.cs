using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SQLite;
using System.Data;
using Dapper;

namespace GymManagementSystem.DAL
{
    class DBConnection
    {
        private SQLiteConnectionStringBuilder stringBuilder = new SQLiteConnectionStringBuilder();
        private static DBConnection instance = null;
        public static DBConnection Instance => instance ?? (instance = new DBConnection());
        public SQLiteConnection DataConnector => new SQLiteConnection(stringBuilder.ToString());
        private DBConnection()
        {
            stringBuilder.DataSource = Properties.Settings.Default.DataSource;
            stringBuilder.Version = Properties.Settings.Default.Version;
        }
    }
}
