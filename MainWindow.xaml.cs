using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_Project
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        static String admin = "admin";
        public String getLogin = null, getPassword = null;
        public String adminLogin = admin, adminPassword = admin, adminName = admin, adminEmail = admin;
        public String userLogin = null,  userPassword = null, userEmail = null, userName = null;
        public SqliteConnection connection = new SqliteConnection("Data Source=user_data.db");
        public SqliteCommand command;
        private bool isLogged = false;

        public MainWindow()
        {
            InitializeComponent();

            connection.Open();
        }

private void LogIn(object sender, RoutedEventArgs e)
        {
            command = new SqliteCommand("SELECT * FROM user_data", connection);
            SqliteDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var id = reader.GetValue(0);
                    var login = reader.GetValue(1);
                    var password = reader.GetValue(2);
                    var email = reader.GetValue(3);
                    var username = reader.GetValue(4);

                    //MessageBox.Show("ID: " + id + "; LOGIN: " + login + "; PASSWORD: " + password + "; EMAIL: " + email + "; USERNAME: " + username + "; ");

                    if (getLogin_Box.Text == login.ToString() && getPassword_Box.Password == password.ToString())
                    {
                        isLogged = true;
                        MessageBox.Show(this, "Успех", "Добро пожаловать!", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
                        Profile profile = new Profile();
                        profile.UserName = username.ToString();
                        profile.UserEmail = email.ToString();
                        profile.userNameProfile.Content = username.ToString();
                        profile.userEmailProfile.Content = email.ToString();
                        profile.Show();
                        Hide();
                    }

                    if (isLogged) //break while if user logged
                    {
                        break;
                    }
                }

                if (!isLogged)
                {
                    MessageBox.Show("Такого пользователя не существует!");
                }
            }
        }

        private void Register(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            Hide();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            Application.Current.Shutdown();
        }
    }
}
