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
    class Users
    {
        #region QUERIES
        private const string ALL_USERS = "select * from UŻYTKOWNIK";
        private const string ADD_USER = "insert into 'UŻYTKOWNIK'('id_użytkownika', 'id_lokalizacji', 'typ_użytkownika', 'data_utworzenia') values";
        private const string UPDATE_PASS_INFO = "update 'UŻYTKOWNIK' set";
        #endregion

        #region CRUD
        public static List<User> LoadUsers()
        {
            using (IDbConnection cnn = DBConnection.Instance.DataConnector)
            {
                var output = cnn.Query<User>(ALL_USERS);
                return output.ToList();
            }
        }

        public static bool AddUser(User user)
        {
            bool state = false;
            using (IDbConnection cnn = DBConnection.Instance.DataConnector)
            {
                var input = cnn.Execute($"{ADD_USER} {user.ToInsert()}");
                state = true;
            }
            return state;
        }

        public static bool UpdatePassInfo(User user)
        {
            bool state = false;
            using (IDbConnection cnn = DBConnection.Instance.DataConnector)
            {
                var input = cnn.Execute($"{UPDATE_PASS_INFO} kod_karnetu = '{user.TicketCode}', " +
                    $"data_wyg_karnetu = '{(user.TicketExpiration ?? DateTime.Now).ToString("yyyy-MM-dd")}' where id_użytkownika = {user.UserID}");
                state = true;
            }
            return state;
        }

        public static bool ExpiredPass(User user)
        {
            {
                bool state = false;
                using (IDbConnection cnn = DBConnection.Instance.DataConnector)
                {
                    var input = cnn.Execute($"{UPDATE_PASS_INFO} kod_karnetu = NULL, data_wyg_karnetu = NULL where id_użytkownika = {user.UserID}");
                    state = true;
                }
                return state;
            }
        }
        #endregion

        #region METHODS
        #endregion
    }
}
