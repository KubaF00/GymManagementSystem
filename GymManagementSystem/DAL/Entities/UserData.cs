using System;
using System.Data.SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementSystem.DAL.Entities
{
    class UserData
    {
        #region Properties
        public string Pesel { get; set; }
        public int? UserID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string HashedPassword { get; set; }
        #endregion

        #region Constructors
        public UserData(SQLiteDataReader reader)
        {
            Pesel = reader["pesel"].ToString();
            UserID = int.Parse(reader["id_użytkownika"].ToString());
            Name = reader["imię"].ToString();
            Surname = reader["nazwisko"].ToString();
            BirthDate = DateTime.Parse(reader["data_urodzenia"].ToString());
            Email = reader["email"].ToString();
            HashedPassword = reader["hash_hasła"].ToString();
        }

        public UserData(string pesel, int userID, string name, string surname, DateTime birthDate, string email, string hashedPassword)
        {
            Pesel = pesel; UserID = userID; Name = name; Surname = surname; 
            BirthDate = birthDate; Email = email; HashedPassword = hashedPassword;
        }
        #endregion

        #region Methods
        #endregion
    }
}
