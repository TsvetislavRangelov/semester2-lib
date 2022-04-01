using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Models;

namespace JointInterfaces.Interfaces
{
   public interface IUsersDAL
    {
        public void RegisterUser(User user);
        public List<User> GetUsers(User user);   
    }
}
