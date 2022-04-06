using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary1.Managers;
using Models.Models;

namespace BALTest
{
    [TestClass]
   public class PasswordTests
    {
        [TestMethod]
        public void TestPasswordHash()
        {
            //arrange
            string examplePassword = "$Uper$trongP4a$$w0rd";
            PasswordManager pm = new PasswordManager();

            //act
           string hash = pm.HashPassword(examplePassword);
            User testUser = new User(1, "test", "test", hash, Models.Enums.Role.USER);

            //assert
            Assert.AreEqual(testUser.Password, "69kMubiZJQNTPSET4giPNQ==");
        }

        [TestMethod]
        public void TestGeneratePasswordSalt()
        {
            PasswordManager pm = new PasswordManager();

            string salt = pm.GeneratePasswordSalt();

            Assert.AreEqual(salt.Length, 36);
        }
    }
}
