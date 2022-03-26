using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAD.Models;
using ClassLibrary1.Interfaces;

namespace ClassLibrary1.Managers
{
   public class UserManager: IUsersDAL
    {
        private readonly UsersDAL dal = new();

        public void RegisterUser(User user)
        {
            dal.RegisterUser(user);
        }

        public bool LoginUser(User user)
        {
            if (dal.LoginUser(user))
            {
                return true;
            }
            return false;
        }
    }
}
