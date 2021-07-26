using System;
using System.Data.SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementSystem.DAL.Entities
{
    class Station
    {
        #region Properties
        public string StationCode { get; set; }
        public string StationName { get; set; }
        #endregion

        #region Constructors
        public Station(SQLiteDataReader reader)
        {
            StationCode = reader["kod_stanowiska"].ToString();
            StationName = reader["nazwa"].ToString();
        }

        public Station(string stationCode, string stationName)
        {
            StationCode = stationCode; StationName = stationName;
        }
        #endregion

        #region Methods
        #endregion
    }
}
