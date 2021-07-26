using System;
using System.Data.SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementSystem.DAL.Entities
{
    class User
    {
        #region Properties
        public int UserID { get; set; }
        public string TicketCode { get; set; }
        public string LocationID { get; set; }
        public string UserType { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime TicketExpiration { get; set; }

        #endregion

        #region Constructors
        public User(SQLiteDataReader reader)
        {
            UserID = int.Parse(reader["id_użytkownika"].ToString());
            TicketCode = reader["kod_karnetu"].ToString();
            LocationID = reader["id_lokalizacji"].ToString();
            UserType = reader["typ_użytkownika"].ToString();
            CreationDate = DateTime.Parse(reader["data_utworzenia"].ToString());
            TicketExpiration = DateTime.Parse(reader["data_wyg_karnetu"].ToString());
        }

        public User(int userID, string ticketCode, string locationID, string userType, DateTime creationDate, DateTime ticketExpiration)
        {
            UserID = userID; TicketCode = ticketCode; LocationID = locationID; UserType = userType;
            CreationDate = creationDate; TicketExpiration = ticketExpiration;
        }
        #endregion

        #region Methods
        #endregion
    }
}
