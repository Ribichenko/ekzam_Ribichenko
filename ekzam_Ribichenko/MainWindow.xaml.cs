using ekzam_Ribichenko.AppDataFile;
using ekzam_Ribichenko.pages;
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

namespace ekzam_Ribichenko
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private User _currentUser = new User();
        public MainWindow(int _ID, string _FirstName, string _LastName, string _MiddleName)
        {
            InitializeComponent();

            Manager.MainFrame = MainFrame;
            if (_ID == 11 || _ID == 12 || _ID == 13)
            {
                MainFrame.Navigate(new managerPage());
            }
            else
            {
                MainFrame.Navigate(new executorPage());
            }
            executorTB.Text = $"{_MiddleName} {_FirstName} {_LastName}";
        }
    }
}
