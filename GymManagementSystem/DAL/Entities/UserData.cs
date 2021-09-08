using System;
using System.Data.SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace GymManagementSystem.DAL.Entities
{
    class UserData
    {
        #region Properties
        public string Pesel { get; set; }
        public long UserID { get; set; }
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

        public UserData(string pesel, long id_użytkownika, string imię, string nazwisko, DateTime data_urodzenia, string email, string hash_hasła)
        {
            Pesel = pesel; UserID = id_użytkownika; Name = imię; Surname = nazwisko; 
            BirthDate = data_urodzenia; Email = email; HashedPassword = hash_hasła;
        }

        public UserData(List<UserData> list, string email)
        {
            foreach (UserData u in list)
                if (u.Email.Equals(email))
                {
                    Pesel = u.Pesel; UserID = u.UserID; Name = u.Name; Surname = u.Surname;
                    BirthDate = u.BirthDate; Email = u.Email; HashedPassword = u.HashedPassword;
                    break;
                }
        }

        public UserData(bool newUser, string pesel, long userID, string name, string surname, DateTime birthDate, string email, string password)
        {
            Pesel = pesel;
            UserID = userID;
            Name = name;
            Surname = surname;
            BirthDate = birthDate;
            Email = email;
            HashedPassword = EncryptPassword(password);
        }

        public UserData(bool isDefault) 
        {
            Pesel = "0";
            UserID = 0;
            Name = "0";
            Surname = "0";
            BirthDate = DateTime.Now.Date;
            Email = "0";
            HashedPassword = "0";
    }
        #endregion

        #region Methods
        public static string EncryptPassword(string password)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            SHA256Managed hashstring = new SHA256Managed();
            byte[] hash = hashstring.ComputeHash(passwordBytes);
            var passwordHash = new StringBuilder();
            foreach (byte b in hash)
            {
                passwordHash.Append(b.ToString("x2"));
            }
            return passwordHash.ToString();
        }

        public bool CorrectLogin(string hash) { return hash.Equals(HashedPassword); }

        public static bool IsPasswordValid(string p1, string p2) { return (p1.Length >= 8 && p1.Equals(p2)); }

        public string ToInsert()
        {
            return $"('{Pesel}', {UserID}, '{Name}', '{Surname}', '{BirthDate.ToString("yyyy-MM-dd")}', '{Email}', '{HashedPassword}')";
        }

        public override bool Equals(object obj)
        {
            var data = obj as UserData;
            if (data is null) return false;
            if (!Pesel.Equals(data.Pesel)) return false;
            return true;
        }
        #endregion
    }
}
