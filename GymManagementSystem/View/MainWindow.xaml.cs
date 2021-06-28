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
        }

        private void NewMember_Click(object sender, RoutedEventArgs e)
        {
            View.NewMember newMember = new NewMember();
            newMember.Show();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            View.homePage HomePage = new homePage();
            HomePage.Show();
        }
    }
}
