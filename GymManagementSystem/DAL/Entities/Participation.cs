using System;
using System.Data.SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementSystem.DAL.Entities
{
    class Participation
    {
        #region Properties
        public int UserID { get; set; }
        public int ActivityID { get; set; }
        #endregion

        #region Constructors
        public Participation(SQLiteDataReader reader)
        {
            UserID = int.Parse(reader["id_użytkownika"].ToString());
            ActivityID = int.Parse(reader["id_zajęć"].ToString());
        }

        public Participation(int userID, int activityID)
        {
            UserID = userID; ActivityID = activityID;
        }
        #endregion

        #region Methods
        #endregion
    }
}
