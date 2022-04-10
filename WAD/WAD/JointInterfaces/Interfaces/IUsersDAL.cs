using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Models;
using System.Data;

namespace JointInterfaces.Interfaces
{
    public interface IUsersDAL
    {
        void RegisterUser(User user);
        List<User> GetUsers();
        string GetPasswordSalt(int id);
        DataTable FillUserTable();
        bool DeleteUser(int id);
        void ChangeRole(int id, string role);
        User GetUser(int id);
        
    }
}
