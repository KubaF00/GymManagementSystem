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
    using GymManagementSystem.DAL.Entities;
    using GymManagementSystem.DAL;
    class UserDataRepo
    {
        #region QUERIES
        private const string ALL_DATA = "select * from DANEUŻYTKOWNIKA";
        private const string ADD_USERDATA = "insert into 'DANEUŻYTKOWNIKA'" +
            "('pesel', 'id_użytkownika', 'imię', 'nazwisko', 'data_urodzenia', 'email', 'hash_hasła') values";
        #endregion

        #region CRUD
        public static List<UserData> LoadUsersData()
        {
            using (IDbConnection cnn = DBConnection.Instance.DataConnector)
            {
                var output = cnn.Query<UserData>(ALL_DATA);
                return output.ToList();
            }
        }

        public static bool AddUserData(UserData userdata)
        {
            bool state = false;
            using (IDbConnection cnn = DBConnection.Instance.DataConnector)
            {
                var input = cnn.Execute($"{ADD_USERDATA} {userdata.ToInsert()}");
                state = true;
            }
            return state;
        }
        #endregion
    }
}
