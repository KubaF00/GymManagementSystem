using System;
using System.Data.SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementSystem.DAL.Entities
{
    class Location
    {
        #region Properties
        public string LocationID { get; set; }
        public string Address { get; set; }
        public string OpeningHours { get; set; }
        #endregion

        #region Constructors
        public Location(SQLiteDataReader reader)
        {
            LocationID = reader["id_lokalizacji"].ToString();
            Address = reader["adres"].ToString();
            OpeningHours = reader["godziny_otwarcia"].ToString();
        }

        public Location(string id_lokalizacji, string adres, string godziny_otwarcia)
        {
            LocationID = id_lokalizacji; Address = adres; OpeningHours = godziny_otwarcia;
        }
        #endregion

        #region Methods
        #endregion
    }
}
