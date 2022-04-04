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
        public string GeneratePasswordSalt()
        {
            byte[] saltBytes = new byte[128 / 8];
            var rng = RandomNumberGenerator.Create();
            rng.GetNonZeroBytes(saltBytes);
            return Convert.ToBase64String(saltBytes);

            //var rng = System.Security.Cryptography.RandomNumberGenerator.Create();
            //rng.GetBytes(saltBytes);
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
