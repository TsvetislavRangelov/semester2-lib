using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Models;
using Models.Enums;
using JointInterfaces.Interfaces;
using System.Data;

namespace JointInterfaces.Interfaces
{
    public class FakeUserDAL : IUsersDAL
    {
        private readonly List<User> users;

        public FakeUserDAL()
        {
            this.users = new List<User>
            {
                 new User(0, "user1", "user1@gmail.com", "827ccb0eea8a706c4c34a16891f84e7b", Role.USER),
                 new User(1, "user2", "user2@gmail.com", "JdVa0oOqQAr0ZMdtcTwHrQ==", Role.USER),
                 new User(2, "user3", "user3@gmail.com", "123abc", Role.ADMIN),
                 new User(3, "whatever", "whatever", "whatever", Role.USER, "RandomSaltTest")
            };
        }

        public void RegisterUser(User user)
        {
            users.Add(user);
        }

        public List<User> GetUsers() =>
             this.users;
        
        public string GetPasswordSalt(int id)
        {
            string salt = GetUsers().Find(u => u.Id == id).Salt;
            return salt;
        }

        public DataTable FillUserTable() =>     
             null;
        
        public bool DeleteUser(int id)
        {
            User found = GetUser(id);
            return users.Remove(found);
        }

        public void ChangeRole(int id, string role)
        {
            User found = GetUser(id);
            found.Role = (Role)Enum.Parse(typeof(Role), role);
        }

        public User GetUser(int id)
        {
            User found = GetUser(id);
            return found is null ? null : found;
        }

        public void UploadImage(byte[] img, int id)
        {
            User found = GetUser(id);
            found.Image = img;
        }
    }
}
