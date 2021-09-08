using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using Dapper;

namespace GymManagementSystem.DAL.Repositories
{
    using DAL.Entities;
    class Locations
    {
        #region QUERIES
        private const string ALL_LOCATIONS = "select * from LOKALIZACJA";
        #endregion

        #region CRUD
        public static List<Location> LoadLocations()
        {
            using (IDbConnection cnn = DBConnection.Instance.DataConnector)
            {
                var output = cnn.Query<Location>(ALL_LOCATIONS);
                return output.ToList();
            }
        }

        public static List<string> GetLocationAddresses()
        {
            List<Location> lista = LoadLocations();
            List<string> addressList = new List<string>();
            foreach (var l in lista)
                addressList.Add(l.Address);
            return addressList;
        }
        #endregion
    }
}
