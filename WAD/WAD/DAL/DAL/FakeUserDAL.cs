using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Models;
using Models.Enums;

namespace DAL.DAL
{
   public class FakeUserDAL
    {
        private List<User> users = new List<User>();


        public FakeUserDAL()
        {
            AddUsersToList();
        }

        public void AddUsersToList()
        {
            User u1 = new User(0, "user1", "user1@gmail.com", "12345", Role.USER);
            User u2 = new User(1, "user2", "user2@gmail.com", "abcdefg", Role.USER);
            User u3 = new User(2, "user3", "user3@gmail.com", "123abc", Role.ADMIN);

            users.Add(u1);
            users.Add(u2);
            users.Add(u3);
        }
        
    }
}
