using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using JointInterfaces.Interfaces;

namespace ClassLibrary1.Managers
{
   public class PasswordManager
    {
        public string GeneratePasswordSalt(int salt = 25)
        {
            byte[] saltBytes = new byte[salt]; // parameter of 25 always guarantees a scrambled string with length 36
            var rng = RandomNumberGenerator.Create();
            rng.GetNonZeroBytes(saltBytes);
            return Convert.ToBase64String(saltBytes);
        }

        public string HashPassword(string password)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(password);
            var hash = MD5.Create();
            bytes = hash.ComputeHash(bytes);
            return Convert.ToBase64String(bytes);
        }
    }
}
