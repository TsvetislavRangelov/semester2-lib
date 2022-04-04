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
        User LoginUser(string username, string password);
        User CheckIfUserExists(string username);
    }
}
