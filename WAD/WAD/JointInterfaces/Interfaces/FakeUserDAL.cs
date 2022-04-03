using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Models;
using Models.Enums;
using JointInterfaces.Interfaces;

namespace JointInterfaces.Interfaces
{
    public class FakeUserDAL : IUsersDAL
    {
        private List<User> users;


        public FakeUserDAL()
        {
            this.users = new List<User>
            {
                 new User(0, "user1", "user1@gmail.com", "827ccb0eea8a706c4c34a16891f84e7b", Role.USER),
                 new User(1, "user2", "user2@gmail.com", "JdVa0oOqQAr0ZMdtcTwHrQ==", Role.USER),
                 new User(2, "user3", "user3@gmail.com", "123abc", Role.ADMIN)
            };
        }

        public void RegisterUser(User user)
        {
            users.Add(user);
        }

        public List<User> GetUsers()
        {
            return this.users;
        }
    }
}
