﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Models;

namespace JointInterfaces.Interfaces
{
    public interface IUsersDAL
    {
        void RegisterUser(User user);
        List<User> GetUsers();
        string GetPasswordSalt(int id);
    }
}
