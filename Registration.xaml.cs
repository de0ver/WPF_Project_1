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

            if (getPassword_BoxReg.Password.Length < 6)
            {
                MessageBox.Show("Минимальная длина пароля: 6");   
            }

            if (getPassword_BoxReg.Password != getConfPassword_BoxReg.Password)
            {
                MessageBox.Show("Пароли не совпадают!");
            }

            goodPassword = getPassword_BoxReg.Password == getConfPassword_BoxReg.Password;

            if (getName_BoxReg.Text.Length < 1)
            {
                MessageBox.Show("Вы не ввели свое имя!");
            }

            goodName = getName_BoxReg.Text != null;

            if (getEmail_BoxReg.Text.Length < 1) 
            { 
                MessageBox.Show("Вы не указали свою почту!");
            }

            goodEmail = getEmail_BoxReg.Text != null;

            if (getLogin_BoxReg.Text.Length < 3)
            {
                MessageBox.Show("Минимальная длина логина: 4");
            }

            goodLogin = getLogin_BoxReg.Text.Length > 3;

            if (goodName && goodEmail && goodLogin && goodPassword)
            {
                mainWindow.userName = getName_BoxReg.Text;
                mainWindow.userEmail = getEmail_BoxReg.Text;
                mainWindow.userLogin = getLogin_BoxReg.Text;
                mainWindow.userPassword = getPassword_BoxReg.Password;

                mainWindow.getLogin_Box.Text = getLogin_BoxReg.Text;
                mainWindow.getPassword_Box.Password = getPassword_BoxReg.Password;

                MessageBox.Show("Все отлично!");
                mainWindow.Show();
                Hide();
            }
        }
    }
}
