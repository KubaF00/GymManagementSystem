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
        public long UserID { get; set; }
        public long ActivityID { get; set; }
        #endregion

        #region Constructors
        public Participation(SQLiteDataReader reader)
        {
            UserID = int.Parse(reader["id_użytkownika"].ToString());
            ActivityID = int.Parse(reader["id_zajęć"].ToString());
        }

        public Participation(long id_użytkownika, long id_zajęć)
        {
            UserID = id_użytkownika; ActivityID = id_zajęć;
        }
        #endregion

        #region Methods
        public string ToInsert()
        {
            return $"({UserID}, {ActivityID})";
        }

        public override bool Equals(object obj)
        {
            var participation = obj as Participation;
            if (participation is null) return false;
            if (UserID != participation.UserID) return false;
            if (ActivityID != participation.ActivityID) return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
    }
}
