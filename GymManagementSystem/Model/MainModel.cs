using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.IO;
using System.Windows;
using System.Collections.ObjectModel;

namespace GymManagementSystem.Model
{
    using GymManagementSystem.DAL.Entities;
    using GymManagementSystem.DAL.Repositories;

    class MainModel
    {
        //Kolekcje
        public ObservableCollection<User> AllUsers { get; set; } = new ObservableCollection<User>();
        public ObservableCollection<UserData> AllUsersData { get; set; } = new ObservableCollection<UserData>();
        public List<Location> FullLocations { get; set; } = new List<Location>();
        public List<string> AllLocations { get; set; } = new List<string>();

        public MainModel()
        {
            FullLocations = Locations.LoadLocations();
            AllLocations = Locations.GetLocationAddresses();
            var dbUsers = Users.LoadUsers();
            foreach (var u in dbUsers)
                AllUsers.Add(u);
            var dbUserData = UserDataRepo.LoadUsersData();
            foreach (var ud in dbUserData)
                AllUsersData.Add(ud);
        }

        #region METHODS
        public bool emailValid(string email)
        {
            bool contains = false;
            foreach (var ud in AllUsersData)
                if (ud.Email.Equals(email))
                {
                    contains = true;
                    break;
                }
            return contains;
        }

        public string getPasswordHash(string email)
        {
            string hash = string.Empty;
            foreach (var ud in AllUsersData)
                if (ud.Email.Equals(email))
                {
                    hash = ud.HashedPassword;
                    break;
                }
            return hash;
        }

        public long GetHighestID()
        {
            long val = 0;
            foreach (var u in AllUsers)
                if (u.UserID > val)
                    val = u.UserID;
            return val;
        }

        public string GetLocationID(string address)
        {
            string id = string.Empty;
            foreach(var l in FullLocations)
                if(address.Equals(l.Address))
                {
                    id = l.LocationID;
                    break;
                }
            return id;
        }

        public bool UserNotExistant(string pesel)
        {
            bool val = true;
            foreach (var ud in AllUsersData)
                if (ud.Pesel.Equals(pesel))
                    val = false;
            return val;
        }

        public void UpdateUserPassInfo(User user)
        {
            for(int i = 0; i < AllUsers.Count; i++)
            {
                if (AllUsers[i].UserID == user.UserID)
                {
                    AllUsers[i].TicketCode = user.TicketCode;
                    AllUsers[i].TicketExpiration = user.TicketExpiration;
                    break;
                }
            }
        }
        #endregion
    }
}
