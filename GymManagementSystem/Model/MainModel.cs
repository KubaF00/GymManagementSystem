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
        public ObservableCollection<Activity> AllActivity { get; set; } = new ObservableCollection<Activity>();
        public ObservableCollection<Participation> AllParticipation { get; set; } = new ObservableCollection<Participation>();
        public List<string> AllActivityString { get; set; } = new List<string>();
        public List<Location> FullLocations { get; set; } = new List<Location>();
        public List<string> AllLocations { get; set; } = new List<string>();
        public List<string> AllTrainers { get; set; } = new List<string>();
        public List<long> AllTrainersID { get; set; } = new List<long>();
        public List<UserData> AllTrainersData { get; set; } = new List<UserData>();
        public List<string> ExerciseType { get; set; } = new List<string>()
        {
           "Cardio", "Trening pleców", "Zajęcia ogólnorozwojowe", "Trening torsu", "Trening górnych partii", "Trening dolnych partii"
        };

        public MainModel()
        {
            FullLocations = Locations.LoadLocations();
            AllLocations = Locations.GetLocationAddresses();

            var dbUsers = Users.LoadUsers();
            foreach (var u in dbUsers)
            {
                UpdateUserPassInfo(u);
                AllUsers.Add(u);
                if(u.UserType.Equals("trener"))
                    AllTrainersID.Add(u.UserID);
            }
            var dbUserData = UserDataRepo.LoadUsersData();
            foreach (var ud in dbUserData)
            {
                AllUsersData.Add(ud);
                if (AllTrainersID.Contains(ud.UserID))
                    AllTrainersData.Add(ud);
            }
            AllTrainersData = AllTrainersData.OrderBy(UserData => UserData.UserID).ToList();

            var dbActivities = Activities.LoadActivity();
            foreach (var a in dbActivities)
            {
                if (DateTime.Compare(DateTime.Now, a.Time) > 0)
                { if (Activities.DeleteOldActivity(a)) { } }
                else
                {
                    AllActivity.Add(a);
                    foreach (var t in AllTrainersData)
                    {
                        foreach (var l in FullLocations)
                        {
                            if(l.LocationID == a.LocationID)
                            {
                                string[] addressSplit = l.Address.Split();
                                string shortAddress = $"{addressSplit[0]} {addressSplit[1].Trim(',')}";
                                AllTrainers.Add($"{t.Name} {t.Surname}");
                                if (a.TrainerID == t.UserID)
                                    AllActivityString.Add(a.GetStringInputValue(shortAddress, $"{t.Name} {t.Surname}"));
                            }
                        }
                    }

                }
            }
            var dbParticipation = ParticipationRepo.LoadParticipation();
            foreach (var p in dbParticipation)
                AllParticipation.Add(p);
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

        public long GetHighestUserID()
        {
            long val = 0;
            foreach (var u in AllUsers)
                if (u.UserID > val)
                    val = u.UserID;
            return val;
        }

        public long GetHighestActivityID()
        {
            long val = 0;
            foreach (var a in AllActivity)
                if (a.ActivityID > val)
                    val = a.ActivityID;
            return val;
        }

        public string GetLocationID(string address)
        {
            string id = string.Empty;
            foreach (var l in FullLocations)
                if (address.Equals(l.Address))
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

        private void UpdateUserPassInfo(User user)
        {
            if (DateTime.Compare(DateTime.Now, (user.TicketExpiration ?? DateTime.Now)) > 0)
            {
                user.TicketExpiration = DateTime.MinValue;
                user.TicketCode = null;
                if (Users.ExpiredPass(user)) { }
            }
        }

        public bool UserAlreadySigned(Participation participation) => AllParticipation.Contains(participation);
        #endregion
    }
}