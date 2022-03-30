using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAD.Models;

namespace OOD
{
   internal interface IUserData
    {
        public List<User> GetUsers();
        
    }
}
