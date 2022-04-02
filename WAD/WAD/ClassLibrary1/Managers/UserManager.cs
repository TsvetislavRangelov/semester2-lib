using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Models;
using JointInterfaces.Interfaces;
using DAL.DAL;

namespace ClassLibrary1.Managers
{
   public class UserManager: IUserManager
    {
        private readonly IUsersDAL src;
        private readonly PasswordManager pm;
        
        public UserManager()
        {
            src = new UsersDAL();
            this.pm = new PasswordManager();
        }

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
            string comparePassword = pm.HashPassword(password);
            foreach(User u in src.GetUsers())
            {
                if(u.Password == comparePassword && u.Username == username)
                {
                    return u;
                }
            }
            return null;
        }

        public User CheckIfUserExists(User user)
        {
            foreach(User u in src.GetUsers())
            {
                if(u.Id == user.Id)
                {
                    return u;
                }
            }
            return null;
        }
    }
}
