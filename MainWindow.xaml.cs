using System;
using System.Collections.Generic;
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

        public MainWindow()
        {
            InitializeComponent();
        }

        private void LogIn(object sender, RoutedEventArgs e)
        {
            if ((getLogin_Box.Text == adminLogin || getLogin_Box.Text == userLogin)
                && ((getPassword_Box.Password == adminPassword || getPassword_Box.Password == userPassword)))
            {
                MessageBox.Show(this, "Успех", "Добро пожаловать!", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
                Profile profile = new Profile();
                profile.UserName = userName;
                profile.UserEmail = userEmail;
                profile.userNameProfile.Content = userName;
                profile.userEmailProfile.Content = userEmail;
                profile.Show();
                Hide();
            } else
            {
                MessageBox.Show(this, "Ошибка", "Неправильный логин или пароль!", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
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
