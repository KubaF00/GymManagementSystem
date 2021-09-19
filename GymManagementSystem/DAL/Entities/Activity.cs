using System;
using System.Data.SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementSystem.DAL.Entities
{
    class Activity
    {
        #region Properties
        public long ActivityID { get; set; }
        public string LocationID { get; set; }
        public string ActivityName { get; set; }
        public string TrainingType { get; set; }
        public DateTime Time { get; set; }
        public int TrainerID { get; set; }
        public int MaxNumberOfParticipants { get; set; }
        public int NumberOfSignedUp { get; set; }
        #endregion

        #region Constructors
        public Activity(SQLiteDataReader reader)
        {
            ActivityID = int.Parse(reader["id_zajęć"].ToString());
            LocationID = reader["id_lokalizacji"].ToString();
            ActivityName = reader["nazwa"].ToString();
            TrainingType = reader["rodzaj_treningu"].ToString();
            Time = DateTime.Parse(reader["kiedy"].ToString());
            TrainerID = int.Parse(reader["id_prowadzącego"].ToString());
            MaxNumberOfParticipants = int.Parse(reader["max"].ToString());
            NumberOfSignedUp = int.Parse(reader["zapisanych"].ToString());
        }

        public Activity(long id_zajęć, string id_lokalizacji, string nazwa, string rodzaj_treningu, DateTime kiedy,
            int id_prowadzącego, int max, int zapisanych)
        {
            ActivityID = id_zajęć; LocationID = id_lokalizacji; ActivityName = nazwa; TrainingType = rodzaj_treningu;
            Time = kiedy; TrainerID = id_prowadzącego; MaxNumberOfParticipants = max; NumberOfSignedUp = zapisanych;
        }
        #endregion

        #region Methods
        public string ToInsert()
        {
            return $"('{ActivityID}', '{LocationID}', '{ActivityName}','{TrainingType}', '{Time.ToString("yyyy-MM-dd HH:mm")}', '{TrainerID}', '{MaxNumberOfParticipants}', '{NumberOfSignedUp}')";
        }
        #endregion
    }
}
