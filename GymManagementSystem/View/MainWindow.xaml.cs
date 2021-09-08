using GymManagementSystem.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GymManagementSystem
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            loginContent.Content = new MainWindowControl();
            mainPanelContent.Content = new MainPanel();
            registerContent.Content = new RegistrationPanel();
            passChoiceContent.Content = new PassChoiceControl();
            contactContent.Content = new ContactControl();
            exerciseChooseContent.Content = new ExercisesChoose();
            trainerContent.Content = new TrainerControl();
        }
    }
}
