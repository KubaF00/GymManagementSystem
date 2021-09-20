using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.IO;
using System.Windows;
using System.Collections.ObjectModel;

namespace GymManagementSystem.ViewModel
{
    using BaseClass;
    using Model;
    using DAL.Entities;
    using DAL.Repositories;

    class MainViewModel : ViewModel
    {
        private MainModel model = new MainModel();

        #region CONSTRUCTOR
        public MainViewModel() 
        {
            AllUsers = model.AllUsers;
            AllUsersData = model.AllUsersData;
            AllLocations = model.AllLocations;
            AllActivity = model.AllActivity;
            AllParticipation = model.AllParticipation;
            AllExerciseTypes = model.ExerciseType;
            AllTrainers = model.AllTrainers;
            AllTrainersID = model.AllTrainersID;
            AllActivityString = model.AllActivityString;
        }
        #endregion

        #region PROPERTIES
        //Kolekcje
        public ObservableCollection<User> AllUsers { get; set; } = new ObservableCollection<User>();
        public ObservableCollection<UserData> AllUsersData { get; set; } = new ObservableCollection<UserData>();
        public ObservableCollection<Activity> AllActivity { get; set; } = new ObservableCollection<Activity>();
        public ObservableCollection<Participation> AllParticipation { get; set; } = new ObservableCollection<Participation>();
        public List<string> AllActivityString { get; set; } = new List<string>();
        public List<string> ChosenActivityString { get; set; } = new List<string>();
        public List<string> AllLocations { get; set; } = new List<string>();

        //Widoczność kontrolek
        private Visibility loginVis = Visibility.Visible, mainPanelVis = Visibility.Collapsed,
            registerVis = Visibility.Collapsed, passChoiceVis = Visibility.Collapsed, contactVis = Visibility.Collapsed, 
            exerciseVis = Visibility.Collapsed, trainerVis = Visibility.Collapsed;

        public Visibility LoginVis
        {
            get { return loginVis; }
            set { loginVis = value; OnPropertyChange(nameof(loginVis)); }
        }
        public Visibility MainPanelVis
        {
            get { return mainPanelVis; }
            set { mainPanelVis = value; OnPropertyChange(nameof(mainPanelVis)); }
        }
        public Visibility RegisterVis
        {
            get { return registerVis; }
            set { registerVis = value; OnPropertyChange(nameof(registerVis)); }
        }
        public Visibility PassChoiceVis
        {
            get { return passChoiceVis; }
            set { passChoiceVis = value; OnPropertyChange(nameof(passChoiceVis)); }
        }
        public Visibility ContactVis
        {
            get { return contactVis; }
            set { contactVis = value; OnPropertyChange(nameof(contactVis)); }
        }
        public Visibility ExerciseVis
        {
            get { return exerciseVis; }
            set { exerciseVis = value; OnPropertyChange(nameof(exerciseVis)); }
        }
        public Visibility TrainerVis
        {
            get { return trainerVis; }
            set { trainerVis = value; OnPropertyChange(nameof(trainerVis)); }
        }

        //Zalogowana osoba
        public User CurrentUser { get; set; } = new User(true);
        public UserData CurrentUserData { get; set; } = new UserData(true);

        #region LOGINVIEW PROPERTIES
        private string password, email;

        public string Password
        {
            get { return password; }
            set { password = value; OnPropertyChange(nameof(password)); }
        }
        public string Email
        {
            get { return email; }
            set { email = value; OnPropertyChange(nameof(email)); }
        }
        #endregion

        #region REGISTERVIEW PROPERTIES
        private string firstName, surName, pesel, newPassword = string.Empty, newPasswordRepeat = string.Empty, newUserEmail, selectedLocation;
        private DateTime? birthDate;
        public DateTime CalendarCutDate { get; set; } = DateTime.Now.Date;

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; OnPropertyChange(nameof(firstName)); }
        }
        public string SurName
        {
            get { return surName; }
            set { surName = value; OnPropertyChange(nameof(surName)); }
        }
        public string Pesel
        {
            get { return pesel; }
            set { pesel = value; OnPropertyChange(nameof(pesel)); }
        }
        public string NewPassword
        {
            get { return newPassword; }
            set { newPassword = value; OnPropertyChange(nameof(newPassword)); }
        }
        public string NewPasswordRepeat
        {
            get { return newPasswordRepeat; }
            set { newPasswordRepeat = value; OnPropertyChange(nameof(newPasswordRepeat)); }
        }
        public string NewUserEmail
        {
            get { return newUserEmail; }
            set { newUserEmail = value; OnPropertyChange(nameof(newUserEmail)); }
        }
        public string SelectedLocation
        {
            get { return selectedLocation; }
            set { selectedLocation = value; OnPropertyChange(nameof(selectedLocation)); }
        }
        public DateTime? BirthDate
        {
            get { return birthDate; }
            set { birthDate = value; OnPropertyChange(nameof(birthDate)); }
        }
        #endregion

        #region MAINPANELVIEW PROPERTIES
        #endregion

        #region PASSCHOOSEVIEW PROPERTIES
        private const string passTypeInfo = "Twój obecny karnet:";
        private const string passExpireInfo = "Wygasa:";
        private string currentPassType, currentPassExpire;

        public string CurrentPassType
        {
            get { return currentPassType; }
            set { currentPassType = value; OnPropertyChange(nameof(currentPassType)); }
        }
        public string CurrentPassExpire
        {
            get { return currentPassExpire; }
            set { currentPassExpire = value; OnPropertyChange(nameof(currentPassExpire)); }
        }
        #endregion

        #region EXERCISECHOOSEVIEW PROPERTIES
        public List<string> AllExerciseTypes { get; set; } = new List<string>();
        public List<string> AllTrainers { get; set; } = new List<string>();
        public List<long> AllTrainersID { get; set; } = new List<long>();
        private DateTime? userExerciseDate;
        private int userSelectedExerciseTypeIndex, userSelectedLocationIndex, userSelectedTrainerIndex, selectedExerciseIndex;

        public DateTime? UserExerciseDate
        {
            get { return userExerciseDate; }
            set { userExerciseDate = value; OnPropertyChange(nameof(userExerciseDate)); }
        }
        public int UserSelectedExerciseTypeIndex
        {
            get { return userSelectedExerciseTypeIndex; }
            set { userSelectedExerciseTypeIndex = value; OnPropertyChange(nameof(userSelectedExerciseTypeIndex)); }
        }
        public int UserSelectedLocationIndex
        {
            get { return userSelectedLocationIndex; }
            set { userSelectedLocationIndex = value; OnPropertyChange(nameof(userSelectedLocationIndex)); }
        }
        public int UserSelectedTrainerIndex
        {
            get { return userSelectedTrainerIndex; }
            set { userSelectedTrainerIndex = value; OnPropertyChange(nameof(userSelectedTrainerIndex)); }
        }
        public int SelectedExerciseIndex
        {
            get { return selectedExerciseIndex; }
            set { selectedExerciseIndex = value; OnPropertyChange(nameof(selectedExerciseIndex)); }
        }
        #endregion

        #region TRAINERVIEW PROPERTIES
        private DateTime? trainerExerciseDate;
        private string trainerSelectedExerciseType, trainerSelectedLocation, exerciseName;
        private int maxParticipants = 30, exerciseSelectedHour = 11, exerciseSelectedMinutes = 29;

        public DateTime? TrainerExerciseDate
        {
            get { return trainerExerciseDate; }
            set { trainerExerciseDate = value; OnPropertyChange(nameof(trainerExerciseDate)); }
        }
        public string TrainerSelectedExerciseType
        {
            get { return trainerSelectedExerciseType; }
            set { trainerSelectedExerciseType = value; OnPropertyChange(nameof(trainerSelectedExerciseType)); }
        }
        public string TrainerSelectedLocation
        {
            get { return trainerSelectedLocation; }
            set { trainerSelectedLocation = value; OnPropertyChange(nameof(trainerSelectedLocation)); }
        }
        public string ExerciseName
        {
            get { return exerciseName; }
            set { exerciseName = value; OnPropertyChange(nameof(exerciseName)); }
        }
        public int MaxParticipants
        {
            get { return maxParticipants; }
            set { maxParticipants = value; OnPropertyChange(nameof(maxParticipants)); }
        }
        public int ExerciseSelectedHour
        {
            get { return exerciseSelectedHour; }
            set { exerciseSelectedHour = value; OnPropertyChange(nameof(exerciseSelectedHour)); }
        }
        public int ExerciseSelectedMinutes
        {
            get { return exerciseSelectedMinutes; }
            set { exerciseSelectedMinutes = value; OnPropertyChange(nameof(exerciseSelectedMinutes)); }
        }
        #endregion

        #region CONTACTVIEW PROPERTIES
        private string contactName, contactEmail, contactMessage;

        public string ContactName
        {
            get { return contactName; }
            set { contactName = value; OnPropertyChange(nameof(contactName)); }
        }
        public string ContactEmail
        {
            get { return contactEmail; }
            set { contactEmail = value; OnPropertyChange(nameof(contactEmail)); }
        }
        public string ContactMessage
        {
            get { return contactMessage; }
            set { contactMessage = value; OnPropertyChange(nameof(contactMessage)); }
        }
        #endregion
        #endregion

        #region COMMANDS
        #region LOGINVIEW COMMANDS
        private ICommand loginCommand, registration;

        public ICommand LoginCommand
        {
            get
            {
                if (loginCommand == null)
                {
                    loginCommand = new RelayCommand(arg =>
                    {
                        CollapseAll();
                        mainPanelVis = Visibility.Visible;
                        CurrentUserData = new UserData(AllUsersData.ToList(), email);
                        CurrentUser = new User(AllUsers.ToList(), CurrentUserData.UserID);
                        password = string.Empty;
                        email = string.Empty;
                        OnPropertyChange(nameof(password), nameof(email),
                            nameof(loginVis), nameof(registerVis), nameof(mainPanelVis));
                    }, arg => (!string.IsNullOrEmpty(Password) && !string.IsNullOrEmpty(Email)
                    && model.emailValid(email)
                    && model.getPasswordHash(email) == UserData.EncryptPassword(password)));
                }
                return loginCommand;
            }
        }

        public ICommand Registration
        {
            get
            {
                if (registration == null)
                {
                    registration = new RelayCommand(arg =>
                    {
                        selectedLocation = AllLocations[0];
                        CollapseAll();
                        registerVis = Visibility.Visible;
                        password = string.Empty;
                        email = string.Empty;
                        OnPropertyChange(nameof(password), nameof(email), 
                            nameof(loginVis), nameof(registerVis), nameof(selectedLocation));
                    });
                }
                return registration;
            }
        }
        #endregion

        #region REGISTERVIEW COMMANDS
        private ICommand backToLogin, createUser;

        public ICommand BackToLogin
        {
            get
            {
                if(backToLogin == null)
                {
                    backToLogin = new RelayCommand(arg =>
                    {
                        CollapseAll();
                        loginVis = Visibility.Visible;
                        ClearRegisterPanel();
                        OnPropertyChange(nameof(firstName), nameof(surName), nameof(newUserEmail),
                            nameof(pesel), nameof(newPassword), nameof(newPasswordRepeat),
                            nameof(loginVis), nameof(registerVis));
                    });
                }
                return backToLogin;
            }
        }

        public ICommand CreateUser
        {
            get
            {
                if (createUser == null)
                {
                    createUser = new RelayCommand(arg =>
                    {
                        CurrentUser = new User(model.GetHighestUserID() + 1, model.GetLocationID(selectedLocation), DateTime.Now.Date);
                        CurrentUserData = new UserData(true, Pesel, model.GetHighestUserID() + 1, FirstName, SurName, 
                            BirthDate ?? DateTime.Now, NewUserEmail, NewPassword);
                        if (Users.AddUser(CurrentUser) && UserDataRepo.AddUserData(CurrentUserData))
                        {
                            AllUsers.Add(CurrentUser);
                            AllUsersData.Add(CurrentUserData);
                            CollapseAll();
                            mainPanelVis = Visibility.Visible;
                            ClearRegisterPanel();
                            OnPropertyChange(nameof(firstName), nameof(surName), nameof(newUserEmail),
                                nameof(pesel), nameof(newPassword), nameof(newPasswordRepeat),
                                nameof(registerVis), nameof(mainPanelVis));
                        }
                        else
                        {
                            CurrentUser = new User(true);
                            CurrentUserData = new UserData(true);
                        }
                    }, arg => (CheckRegisterPanel() && model.UserNotExistant(Pesel)));
                }
                return createUser;
            }
        }
        #endregion

        #region MAINPANELVIEW COMMANDS
        private ICommand logout;
        private ICommand openPassView, openExView, openTrainerView, openContactView;

        public ICommand Logout
        {
            get
            {
                if (logout == null)
                {
                    logout = new RelayCommand(arg =>
                    {
                        CollapseAll();
                        loginVis = Visibility.Visible;
                        OnPropertyChange(nameof(loginVis), nameof(mainPanelVis));
                    });
                }
                return logout;
            }
        }
        public ICommand OpenPassView
        {
            get
            {
                if (openPassView == null)
                {
                    openPassView = new RelayCommand(arg =>
                    {
                        ShowHidePassInfo();
                        CollapseAll();
                        passChoiceVis = Visibility.Visible;
                        OnPropertyChange(nameof(passChoiceVis), nameof(mainPanelVis), nameof(currentPassType), nameof(currentPassExpire));
                    });
                }
                return openPassView;
            }
        }

        public ICommand OpenExView
        {
            get
            {
                if (openExView == null)
                {
                    openExView = new RelayCommand(arg =>
                    {
                        ChosenActivityString = new List<string>();
                        ChosenActivityString.AddRange(AllActivityString);
                        ResetExercisePanel();
                        CollapseAll();
                        exerciseVis = Visibility.Visible;
                        OnPropertyChange(nameof(exerciseVis), nameof(mainPanelVis));
                    });
                }
                return openExView;
            }
        }

        public ICommand OpenTrainerView
        {
            get
            {
                if (openTrainerView == null)
                {
                    openTrainerView = new RelayCommand(arg =>
                    {
                        trainerSelectedLocation = AllLocations[0];
                        trainerSelectedExerciseType = AllExerciseTypes[0];
                        exerciseName = string.Empty;
                        CollapseAll();
                        trainerVis = Visibility.Visible;
                        OnPropertyChange(nameof(trainerVis), nameof(mainPanelVis),
                            nameof(trainerSelectedLocation), nameof(trainerSelectedExerciseType),
                            nameof(exerciseName));
                    }, arg => CurrentUser.UserType.Equals("trener"));
                }
                return openTrainerView;
            }
        }

        public ICommand OpenContactView
        {
            get
            {
                if (openContactView == null)
                {
                    openContactView = new RelayCommand(arg =>
                    {
                        contactEmail = CurrentUserData.Email;
                        contactName = CurrentUserData.Name;
                        CollapseAll();
                        contactVis = Visibility.Visible;
                        OnPropertyChange(nameof(contactVis), nameof(mainPanelVis), nameof(contactEmail), nameof(contactName));
                    });
                }
                return openContactView;
            }
        }

        #endregion

        #region PASSCHOOSEVIEW COMMANDS
        private ICommand chooseYearPass, chooseQuarterPass, chooseMonthPass;

        public ICommand ChooseYearPass
        {
            get
            {
                if(chooseYearPass == null)
                {
                    chooseYearPass = new RelayCommand(arg =>
                    {
                        choosePass(12, "ROCZ");
                    }, arg => CurrentUser.TicketCode == null);
                }
                return chooseYearPass;
            }
        }
        public ICommand ChooseQuarterPass
        {
            get
            {
                if (chooseQuarterPass == null)
                {
                    chooseQuarterPass = new RelayCommand(arg =>
                    {
                        choosePass(3, "KWART");
                    }, arg => CurrentUser.TicketCode == null);
                }
                return chooseQuarterPass;
            }
        }
        public ICommand ChooseMonthPass
        {
            get
            {
                if (chooseMonthPass == null)
                {
                    chooseMonthPass = new RelayCommand(arg =>
                    {
                        choosePass(1, "MIES");
                    }, arg => CurrentUser.TicketCode == null);
                }
                return chooseMonthPass;
            }
        }
        #endregion

        #region EXERCISECHOOSEVIEW COMMANDS
        private ICommand saveExercises, setExerciseSearch, resetExerciseSearch;

        public ICommand SaveExercises
        {
            get
            {
                if (saveExercises == null)
                {
                    saveExercises = new RelayCommand(arg =>
                    {
                        Activity NewActivity = new Activity(true);
                        for (int i = 0; i < AllActivity.Count; i++)
                            if (AllActivityString[i].Equals(ChosenActivityString[SelectedExerciseIndex]))
                                NewActivity = AllActivity[i];
                        Participation NewParticipation = new Participation(CurrentUser.UserID, NewActivity.ActivityID);

                        if (!AllParticipation.Contains(NewParticipation) && NewActivity.MaxNumberOfParticipants - NewActivity.NumberOfSignedUp > 0)
                        {
                            if (ParticipationRepo.AddParticipation(NewParticipation) && Activities.UpdateActivity(NewActivity))
                            {
                                AllParticipation.Add(NewParticipation);
                                for (int i = 0; i < AllActivity.Count; i++)
                                    if(AllActivity[i].ActivityID == NewActivity.ActivityID)
                                    {
                                        AllActivity[i].NumberOfSignedUp += 1;
                                        int newCount = int.Parse(AllActivityString[i].Split().Last()) - 1;
                                        AllActivityString[i] = $"{AllActivityString[i].Substring(0, AllActivityString[i].LastIndexOf(' ')).TrimEnd()} {newCount}";
                                    }
                            }
                        }
                        else MessageBox.Show("Nie możesz zapisać się na te zajęcia.\nJuż to zrobiłeś, lub limit ćwiczących został osiągnięty.");

                        ChosenActivityString = new List<string>();
                        ChosenActivityString.AddRange(AllActivityString);
                        ResetExercisePanel();
                    }, arg => selectedExerciseIndex >= 0);
                }
                return saveExercises;
            }
        }

        public ICommand SetExerciseSearch
        {
            get
            {
                if (setExerciseSearch == null)
                {
                    setExerciseSearch = new RelayCommand(arg =>
                    {
                        string shortAddress = string.Empty;
                        string inputTrainer = string.Empty;
                        string inputExerciseType = string.Empty;
                        string inputDate = string.Empty;

                        if (userSelectedLocationIndex >= 0)
                        {
                            string[] addressSplit = AllLocations[UserSelectedLocationIndex].Split();
                            shortAddress = $"{addressSplit[0]} {addressSplit[1].Trim(',')}";
                        }
                        if (userSelectedExerciseTypeIndex >= 0) inputExerciseType = AllExerciseTypes[userSelectedExerciseTypeIndex];
                        if (userSelectedTrainerIndex >= 0) inputTrainer = AllTrainers[userSelectedTrainerIndex];
                        if (userExerciseDate != null) inputDate = (userExerciseDate ?? DateTime.Now).ToString("dd-MM-yyyy");

                        ChosenActivityString = new List<string>();
                        foreach (var a in AllActivityString)
                            if (a.Contains(inputDate) && a.Contains(inputExerciseType) && a.Contains(inputTrainer) && a.Contains(shortAddress))
                            { ChosenActivityString.Add(a); }
                        ResetExercisePanel();
                    }, arg => CheckExercisePanel());
                }
                return setExerciseSearch;
            }
        }

        public ICommand ResetExerciseSearch
        {
            get
            {
                if (resetExerciseSearch == null)
                {
                    resetExerciseSearch = new RelayCommand(arg =>
                    {
                        ChosenActivityString = new List<string>();
                        ChosenActivityString.AddRange(AllActivityString);
                        ResetExercisePanel();
                    });
                }
                return resetExerciseSearch;
            }
        }

        #endregion

        #region TRAINERVIEW COMMANDS
        private ICommand trainerSaveExercise;

        public ICommand TrainerSaveExercise
        {
            get
            {
                if (trainerSaveExercise == null)
                {
                    trainerSaveExercise = new RelayCommand(arg =>
                    {
                        DateTime dateInput = new DateTime((TrainerExerciseDate ?? DateTime.Now).Year, (TrainerExerciseDate ?? DateTime.Now).Month,
                            (TrainerExerciseDate ?? DateTime.Now).Day, exerciseSelectedHour, exerciseSelectedMinutes, 0);
                        Activity NewActivity = new Activity(model.GetHighestActivityID() + 1, model.GetLocationID(trainerSelectedLocation),
                            exerciseName, trainerSelectedExerciseType, dateInput, (int)CurrentUser.UserID, maxParticipants, 0);
                        if (Activities.AddActivity(NewActivity))
                        {
                            AllActivity.Add(NewActivity);
                            string[] addressSplit = trainerSelectedLocation.Split();
                            string shortAddress = $"{addressSplit[0]} {addressSplit[1].Trim(',')}";
                            AllActivityString.Add(NewActivity.GetStringInputValue(shortAddress, $"{CurrentUserData.Name} {CurrentUserData.Surname}"));
                            exerciseName = string.Empty;
                            maxParticipants = 30;
                            exerciseSelectedHour = 11;
                            exerciseSelectedMinutes = 29;
                            trainerSelectedLocation = AllLocations[0];
                            trainerSelectedExerciseType = AllExerciseTypes[0];
                            OnPropertyChange(nameof(maxParticipants), nameof(exerciseSelectedHour), nameof(exerciseSelectedMinutes),
                                nameof(trainerSelectedLocation), nameof(trainerSelectedExerciseType), nameof(exerciseName));
                        }
                    }, arg => CheckTrainerPanel());
                }
                return trainerSaveExercise;
            }
        }
        #endregion

        #region CONTACTVIEW COMMANDS
        private ICommand sendMessage;

        public ICommand SendMessage
        {
            get
            {
                if (sendMessage == null)
                {
                    sendMessage = new RelayCommand(arg =>
                    {
                        contactMessage = string.Empty;
                        contactName = CurrentUserData.Name;
                        contactEmail = CurrentUserData.Email;
                        OnPropertyChange(nameof(contactMessage), nameof(contactName), nameof(contactEmail));
                    });
                }
                return sendMessage;
            }
        }
        #endregion

        private ICommand backToMainPanel;

        public ICommand BackToMainPanel
        {
            get
            {
                if (backToMainPanel == null)
                {
                    backToMainPanel = new RelayCommand(arg =>
                    {
                        contactName = string.Empty; contactEmail = string.Empty; contactMessage = string.Empty;
                        CollapseAll();
                        mainPanelVis = Visibility.Visible;
                        OnPropertyChange(nameof(mainPanelVis),
                            nameof(passChoiceVis), nameof(exerciseVis), nameof(trainerVis), nameof(contactVis),
                            nameof(contactName), nameof(contactEmail), nameof(contactMessage));
                    });
                }
                return backToMainPanel;
            }
        }
        #endregion

        #region UTILITY FUNCTIONS
        private void CollapseAll()
        {
            loginVis = Visibility.Collapsed;
            registerVis = Visibility.Collapsed;
            mainPanelVis = Visibility.Collapsed;
            passChoiceVis = Visibility.Collapsed;
            exerciseVis = Visibility.Collapsed;
            trainerVis = Visibility.Collapsed;
            contactVis = Visibility.Collapsed;
        }

        #region REGISTERPANEL FUNCTIONS
        private void ClearRegisterPanel()
        {
            firstName = string.Empty;
            surName = string.Empty;
            pesel = string.Empty;
            newPassword = string.Empty;
            newPasswordRepeat = string.Empty;
            newUserEmail = string.Empty;
        }

        private bool CheckRegisterPanel()
        {
            bool pc = true;
            if(!UserData.IsPasswordValid(newPassword, newPasswordRepeat)) pc = false;
            if (string.IsNullOrEmpty(firstName)) pc = false;
            if (string.IsNullOrEmpty(surName)) pc = false;
            if (string.IsNullOrEmpty(Pesel) || Pesel.Length != 11) pc = false;
            if (string.IsNullOrEmpty(newUserEmail) || !newUserEmail.Contains('@')) pc = false;
            if (!birthDate.HasValue) pc = false;
            return pc;
        }
        #endregion

        #region PASSCHOICEPANEL FUNCTIONS
        private void ShowHidePassInfo()
        {
            if (DateTime.Compare((CurrentUser.TicketExpiration ?? DateTime.Now), DateTime.MinValue) == 0)
            {
                currentPassType = string.Empty;
                currentPassExpire = string.Empty;
            }
            else
            {
                currentPassType = $"{passTypeInfo} {CurrentUser.GetPassType()}";
                currentPassExpire = $"{passExpireInfo} {(CurrentUser.TicketExpiration ?? DateTime.Now).ToString("dd-MM-yyyy")}";
            }
        }

        private void choosePass(int months, string code)
        {
            CurrentUser.TicketCode = code;
            CurrentUser.TicketExpiration = DateTime.Now.AddMonths(months).Date;
            ShowHidePassInfo();
            OnPropertyChange(nameof(currentPassType), nameof(currentPassExpire));
        }
        #endregion

        #region TRAINERPANEL FUNCTIONS
        private bool CheckTrainerPanel()
        {
            bool pc = true;
            if (string.IsNullOrEmpty(exerciseName)) pc = false;
            if (!trainerExerciseDate.HasValue) pc = false;
            return pc;
        }
        #endregion

        #region EXERCISEPANEL FUNCTIONS
        private bool CheckExercisePanel()
        {
            if (userExerciseDate.HasValue || userSelectedTrainerIndex >= 0 || userSelectedLocationIndex >= 0 ||
                userSelectedExerciseTypeIndex >= 0) return true;
            return false;
        }

        private void ResetExercisePanel()
        {
            userSelectedExerciseTypeIndex = -1;
            userSelectedLocationIndex = -1;
            userSelectedTrainerIndex = -1;
            selectedExerciseIndex = -1;
            userExerciseDate = null;
            OnPropertyChange(nameof(userSelectedExerciseTypeIndex), nameof(userSelectedLocationIndex),
                nameof(userSelectedTrainerIndex), nameof(selectedExerciseIndex), nameof(userExerciseDate),
                nameof(ChosenActivityString));
        }
        #endregion
        #endregion
    }
}