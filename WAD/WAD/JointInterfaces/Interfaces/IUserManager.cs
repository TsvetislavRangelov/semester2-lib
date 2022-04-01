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
        public bool LoginUser(User user);
        public User CheckIfUserExists(User user);
    }
}
