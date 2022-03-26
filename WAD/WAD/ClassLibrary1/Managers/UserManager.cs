﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAD.Models;

namespace ClassLibrary1.Managers
{
   public class UserManager
    {
        private readonly UsersDAL dal = new();

        public void RegisterUser(User user)
        {
            dal.RegisterUser(user);
        }
    }
}
