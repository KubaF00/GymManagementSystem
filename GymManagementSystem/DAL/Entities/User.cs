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
        public long UserID { get; set; }
        public string? TicketCode { get; set; }
        public string LocationID { get; set; }
        public string UserType { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? TicketExpiration { get; set; }

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

        public User(long id_użytkownika, string kod_karnetu, string id_lokalizacji, string typ_użytkownika, DateTime data_utworzenia, DateTime data_wyg_karnetu)
        {
            UserID = id_użytkownika;
            TicketCode = kod_karnetu;
            LocationID = id_lokalizacji;
            UserType = typ_użytkownika;
            CreationDate = data_utworzenia;
            TicketExpiration = data_wyg_karnetu;
        }

        public User(List<User> list, long id)
        {
            foreach (User u in list)
                if (u.UserID == id)
                {
                    UserID = u.UserID; TicketCode = u.TicketCode; u.LocationID = LocationID;
                    UserType = u.UserType; CreationDate = u.CreationDate; TicketExpiration = u.TicketExpiration;
                    break;
                }
        }

        public User(long userID, string locationID, DateTime creationDate)
        {
            UserID = userID;
            LocationID = locationID;
            UserType = "klient";
            CreationDate = creationDate;
            TicketCode = null;
            TicketExpiration = null;
        }

        public User(bool isDefault) 
        {
            UserID = 0;
            TicketCode = null;
            TicketExpiration = null;
            LocationID = "0";
            UserType = "klient";
            CreationDate = DateTime.Now.Date;
        }
        #endregion

        #region Methods
        public string ToInsert()
        {
            return $"('{UserID}', '{LocationID}', '{UserType}','{DateTime.Now.ToString("yyyy-MM-dd")}')";
        }

        public string GetPassType()
        {
            if (TicketCode.Equals("ROCZ")) return "Roczny";
            else if (TicketCode.Equals("KWART")) return "Kwartalny";
            else return "Miesięczny";
        }
        #endregion
    }
}
