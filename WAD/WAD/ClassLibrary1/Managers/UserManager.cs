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
        private PasswordManager pm;
        
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

        public bool LoginUser(User user)
        {
            string comparePassword = pm.HashPassword(user.Password);
            foreach(User u in src.GetUsers())
            {
                if(u.Password == comparePassword && u.Username == user.Username)
                {
                    return true;
                }
            }
            return false;
        }

        public User CheckIfUserExists(User user)
        {
            foreach(User u in src.GetUsers())
            {
                if(u.Id == user.Id)
                {
                    return user;
                }
            }
            return null;
        }
    }
}
