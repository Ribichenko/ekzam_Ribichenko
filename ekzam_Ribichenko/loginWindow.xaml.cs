using ekzam_Ribichenko.AppDataFile;
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
using System.Windows.Shapes;

namespace ekzam_Ribichenko
{
    /// <summary>
    /// Логика взаимодействия для loginWindow.xaml
    /// </summary>
    public partial class loginWindow : Window
    {
        public loginWindow()
        {
            InitializeComponent();

            dataTB.Text = dataTB.Text + " " + DateTime.Now.ToString("dd MMMM yyyy");
            zpTB.Text = zpTB.Text + " " + DateTime.Now.AddMonths(1).ToString("5 MMMM yyyy");
            //zadTB.Text = zadTB.Text + " " + 

            var db = RibichenkoEntities.GetContext().Task.ToList();
            byte j = 0;
            foreach (var abs in db)
            {
                if (abs.Status == "запланирована")
                {
                    j += 1;
                }
            }
            zadTB.Text = zadTB.Text + " " + j;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            User selectUser = (sender as Button).DataContext as User;
            bool log = false;
            foreach (var a in RibichenkoEntities.GetContext().User)
            {
                if (loginTB.Text == a.Login)
                {
                    log = true;
                    if (passTB.Text == a.Password)
                    {
                        MessageBox.Show("Успешная авторизация");
                        ShowMain(a.ID, a.FirstName, a.LastName, a.MiddleName);
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Неверный пароль");
                    }
                }
            }
            if (log == false)
            {
                MessageBox.Show("Неверный логин");
            }
        }

        public void ShowMain(int _ID, string _FirstName, string _LastName, string _MiddleName)
        {
            MainWindow mainWindow = new MainWindow(_ID, _FirstName, _LastName, _MiddleName);
            mainWindow.Show();
        }
    }
}
