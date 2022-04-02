using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Models;

namespace JointInterfaces.Interfaces
{
   public interface IUserManager
    {
        public User LoginUser(string username, string password);
        public User CheckIfUserExists(User user);
    }
}
