using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Models;
using JointInterfaces.Interfaces;
using System.Data;

namespace ClassLibrary1.Managers
{
    public class UserManager
    {
        private readonly IUsersDAL src;
        private readonly PasswordManager pm;

        public UserManager(IUsersDAL src)
        {
            this.src = src;
            this.pm = new PasswordManager();
        }
        public void RegisterUser(User user) =>
             this.src.RegisterUser(user);
        

        public User LoginUser(string username, string password)
        {
            User loginUser = CheckIfUserExists(username);
            if (loginUser is null)
            {
                return null;
            }
            string comparePassword = pm.HashPassword(password) + GetPasswordSalt(loginUser.Id);

            if (loginUser.Password + loginUser.Salt == comparePassword)
            {
                return loginUser;
            }
            return null;
        }

        public User CheckIfUserExists(string username)
        {
            User foundUser = GetUsers().Find(u => u.Username == username);
            if (foundUser is not null)
            {
                return foundUser;
            }
            return null;
        }

        public List<User> GetUsers() =>
            this.src.GetUsers();
        

        public string GetPasswordSalt(int id)
        {
            string salt = GetUsers().Find(u => u.Id == id).Salt;
            return salt;
        }

        public DataTable FillUserTable() =>
            this.src.FillUserTable();
       

        public bool DeleteUser(int id)
        {
            bool result = this.src.DeleteUser(id) ? true : false;
            return result;
        }

        public void ChangeRole(int id, string role) =>
            src.ChangeRole(id, role);
        

        public User GetUser(int id)
        {
            User foundUser = GetUsers().Find(u => u.Id == id);
            if (foundUser != null)
            {
                return foundUser;
            }
            return null;
        }

        public string ConvertProfileImage(byte[] img)
        {
            if (img == null)
            {
                return null;
            }
            else
            {
                var base64 = Convert.ToBase64String(img);
                var mangaImg = String.Format("data:image/.*;base64,{0}", base64);
                return mangaImg;
            }
        }

        public void UploadImage(byte[] img, int id) =>
            this.src.UploadImage(img, id);
        
    }
}
