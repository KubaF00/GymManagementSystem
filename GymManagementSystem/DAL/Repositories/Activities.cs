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
    class Activities
    {
        #region QUERIES
        private const string ALL_ACTIVITY = "select * from ZAJĘCIA";
        private const string ADD_ACTIVITY = "insert into 'ZAJĘCIA'('id_zajęć', 'id_lokalizacji', 'nazwa', 'rodzaj_treningu', " +
            "'kiedy', 'id_prowadzącego', 'max', 'zapisanych') values";
        private const string DELETE_ACTIVITY = "delete from ZAJĘCIA where id_zajęć =";
        private const string UPDATE_SIGNED_STATUS = "update ZAJĘCIA set zapisanych = zapisanych + 1 where id_zajęć =";
        #endregion

        #region CRUD
        public static List<Activity> LoadActivity()
        {
            using (IDbConnection cnn = DBConnection.Instance.DataConnector)
            {
                var output = cnn.Query<Activity>(ALL_ACTIVITY);
                return output.ToList();
            }
        }

        public static bool DeleteOldActivity(Activity activity)
        {
            bool state = false;
            using (IDbConnection cnn = DBConnection.Instance.DataConnector)
            {
                var input = cnn.Execute($"{DELETE_ACTIVITY} {activity.ActivityID}");
                state = true;
            }
            return state;
        }

        public static bool AddActivity(Activity activity)
        {
            bool state = false;
            using (IDbConnection cnn = DBConnection.Instance.DataConnector)
            {
                var input = cnn.Execute($"{ADD_ACTIVITY} {activity.ToInsert()}");
                state = true;
            }
            return state;
        }

        public static bool UpdateActivity(Activity activity)
        {
            bool state = false;
            using (IDbConnection cnn = DBConnection.Instance.DataConnector)
            {
                var input = cnn.Execute($"{UPDATE_SIGNED_STATUS} {activity.ActivityID}");
                state = true;
            }
            return state;
        }
        #endregion
    }
}
