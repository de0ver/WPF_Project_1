using Microsoft.Data.Sqlite;
using System;
using System.Windows;

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
                MessageBox.Show(this, "Минимальная длина пароля: 6", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);   
            }

            if (getPassword_BoxReg.Password != getConfPassword_BoxReg.Password)
            {
                MessageBox.Show(this, "Пароли не совпадают!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
            }

            goodPassword = getPassword_BoxReg.Password == getConfPassword_BoxReg.Password && getPassword_BoxReg.Password.Length >= 6 && getConfPassword_BoxReg.Password.Length >= 6;

            if (getName_BoxReg.Text.Length <= 1)
            {
                MessageBox.Show(this, "Вы не указали имя!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
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
                mainWindow.getLogin_Box.Text = getLogin_BoxReg.Text;
                mainWindow.getPassword_Box.Password = getPassword_BoxReg.Password;

                mainWindow.command = new SqliteCommand("INSERT INTO user_data (login, password, email, username) VALUES (@login, @password, @email, @username)", mainWindow.connection);

                SqliteParameter loginParam = new SqliteParameter("@login", getLogin_BoxReg.Text);
                mainWindow.command.Parameters.Add(loginParam);

                SqliteParameter passParam = new SqliteParameter("@password", getPassword_BoxReg.Password);
                mainWindow.command.Parameters.Add(passParam);

                SqliteParameter emailParam = new SqliteParameter("@email", getEmail_BoxReg.Text);
                mainWindow.command.Parameters.Add(emailParam);

                SqliteParameter nameParam = new SqliteParameter("@username", getName_BoxReg.Text);
                mainWindow.command.Parameters.Add(nameParam);

                try {
                    mainWindow.command.ExecuteNonQuery();
                } catch (SqliteException error) {
                    if (error.SqliteErrorCode == 19)
                    {
                        MessageBox.Show(this, "Данный пользователь уже зарегистрирован!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                        return;
                    }
                }

                MessageBox.Show(this, "Все отлично!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
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
