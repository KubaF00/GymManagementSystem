using System;
using System.Data.SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementSystem.DAL.Entities
{
    class Ownership
    {
        #region Properties
        public string LocationID { get; set; }
        public string StationCode { get; set; }
        public int StationCount { get; set; }
        #endregion

        #region Constructors
        public Ownership(SQLiteDataReader reader)
        {
            LocationID = reader["id_lokalizacji"].ToString();
            StationCode = reader["kod_stanowiska"].ToString();
            StationCount = int.Parse(reader["ile"].ToString());
        }

        public Ownership(string locationID, string stationCode, int stationCount)
        {
            LocationID = locationID; StationCode = stationCode; StationCount = stationCount;
        }
        #endregion

        #region Methods
        #endregion
    }
}
