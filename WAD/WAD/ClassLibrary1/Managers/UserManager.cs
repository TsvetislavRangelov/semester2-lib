﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Models;
using JointInterfaces.Interfaces;
using DAL.DAL;

namespace ClassLibrary1.Managers
{
   public class UserManager
    {
        private readonly IUsersDAL src;
        
        public UserManager()
        {
            src = new UsersDAL();
        }

        public UserManager(IUsersDAL src)
        {
            this.src = src;
        }
        public void RegisterUser(User user)
        {
            src.RegisterUser(user);
        }

        public bool LoginUser(User user)
        {
            
        }
    }
}
