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
                    User user = new User(int.Parse(reader.GetValue(0).ToString()), reader.GetValue(1).ToString(), reader.GetValue(2).ToString(), reader.GetValue(3).ToString(), reader.GetValue(4).ToString());

                    if (getLogin_Box.Text == user.Login && getPassword_Box.Password == user.Password)
                    {
                        isLogged = true;
                        MessageBox.Show(this, "Добро пожаловать!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
                        Profile profile = new Profile();
                        profile.userNameProfile.Content = user.Username;
                        profile.userEmailProfile.Content = user.Email;
                        profile.userLoginProfile.Content = user.Login;
                        profile.userIdProfile.Content = user.Id;
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
                    MessageBox.Show(this, "Неправильный логин или пароль!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
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
