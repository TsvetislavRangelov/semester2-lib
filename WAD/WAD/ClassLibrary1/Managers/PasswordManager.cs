using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace ClassLibrary1.Managers
{
   public class PasswordManager
    {
        public string GeneratePasswordSalt(int salt)
        {
           byte[] saltBytes = new byte[salt];
            var rng = System.Security.Cryptography.RandomNumberGenerator.Create();
            rng.GetBytes(saltBytes);
            return Convert.ToBase64String(saltBytes);
        }

        public string HashPassword(string password, string salt)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(password + salt);
            var hash = System.Security.Cryptography.MD5.Create();
            bytes = hash.ComputeHash(bytes);
            return Convert.ToBase64String(bytes);
        }
    }
}
