using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Project
{
    class User
    {
        public User(int id, string login, string password, string email, string username)
        {
            Id = id;
            Login = login;
            Password = password;
            Email = email;
            Username = username;
        }
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }

    }
}
