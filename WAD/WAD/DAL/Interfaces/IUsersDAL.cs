using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Models;

namespace DAL.Interfaces
{
   public interface IUsersDAL
    {
        public void RegisterUser(User user);
        public bool LoginUser(User user);
    }
}
