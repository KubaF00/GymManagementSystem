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
        public int ActivityID { get; set; }
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

        public Activity(int activityID, string locationID, string name, string trainingType, DateTime time,
            int trainerID, int maxNumberOfParticipants, int numberOfSignepUp)
        {
            ActivityID = activityID; LocationID = locationID; ActivityName = name; TrainingType = trainingType;
            Time = time; TrainerID = trainerID; MaxNumberOfParticipants = maxNumberOfParticipants; NumberOfSignedUp = numberOfSignepUp;
        }
        #endregion

        #region Methods
        #endregion
    }
}
