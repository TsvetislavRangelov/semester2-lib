using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Models;
using JointInterfaces.Interfaces;
using System.Data;

namespace ClassLibrary1.Managers
{
    public class UserManager
    {
        private readonly IUsersDAL src;
        private readonly PasswordManager pm;

        public UserManager(IUsersDAL src)
        {
            this.src = src;
            this.pm = new PasswordManager();
        }
        public void RegisterUser(User user)
        {
            src.RegisterUser(user);
        }

        public User LoginUser(string username, string password)
        {
            User loginUser = CheckIfUserExists(username);
            if (loginUser == null)
            {
                return null;
            }
            string comparePassword = pm.HashPassword(password) + GetPasswordSalt(loginUser.Id);

            if (loginUser.Password + loginUser.Salt == comparePassword)
            {
                return loginUser;
            }
            return null;
        }

        public User CheckIfUserExists(string username)
        {
            foreach (User u in GetUsers())
            {
                if (u.Username == username)
                {
                    return u;
                }
            }
            return null;
        }

        public List<User> GetUsers()
        {
            return src.GetUsers();
        }

        public string GetPasswordSalt(int id)
        {
            return src.GetPasswordSalt(id);
        }

        public DataTable FillUserTable()
        {
            return src.FillUserTable();
        }

        public bool DeleteUser(int id)
        {
            return src.DeleteUser(id);
        }

        public void ChangeRole(int id, string role)
        {
            src.ChangeRole(id, role);
        }
    }
}
