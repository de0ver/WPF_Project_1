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
using System.Windows.Shapes;

namespace WPF_Project
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            Boolean goodName, goodEmail, goodLogin, goodPassword;

            if (getPassword_BoxReg.Password.Length < 6 || getConfPassword_BoxReg.Password.Length < 6)
            {
                MessageBox.Show(this, "Ошибка", "Минимальная длина пароля: 6", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);   
            }

            if (getPassword_BoxReg.Password != getConfPassword_BoxReg.Password)
            {
                MessageBox.Show(this, "Ошибка", "Пароли не совпадают!", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
            }

            goodPassword = getPassword_BoxReg.Password == getConfPassword_BoxReg.Password;

            if (getName_BoxReg.Text.Length <= 1)
            {
                MessageBox.Show(this, "Ошибка", "Вы не указали имя!", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
            }

            goodName = getName_BoxReg.Text.Length >= 2;

            if (getEmail_BoxReg.Text.Length <= 1) 
            {
                MessageBox.Show(this, "Ошибка", "Вы не указали почту!", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
            }

            goodEmail = getEmail_BoxReg.Text.Length >= 2;

            if (getLogin_BoxReg.Text.Length <= 3)
            {
                MessageBox.Show(this, "Ошибка", "Минимальная длина логина: 4", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
            }

            goodLogin = getLogin_BoxReg.Text.Length >= 4;

            if (goodName && goodEmail && goodLogin && goodPassword)
            {
                mainWindow.userName = getName_BoxReg.Text;
                mainWindow.userEmail = getEmail_BoxReg.Text;
                mainWindow.userLogin = getLogin_BoxReg.Text;
                mainWindow.userPassword = getPassword_BoxReg.Password;

                mainWindow.getLogin_Box.Text = getLogin_BoxReg.Text;
                mainWindow.getPassword_Box.Password = getPassword_BoxReg.Password;


                MessageBox.Show(this, "Успех", "Все отлично!", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
                mainWindow.Show();
                Hide();
            }
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            Application.Current.Shutdown();
        }
    }
}
