using Microsoft.VisualStudio.TestTools.UnitTesting;
using WAD.Models;
using ClassLibrary1.Managers;
using ClassLibrary1.Interfaces;

namespace BALTest
{
    [TestClass]
    public class UserTests
    {
        private readonly IUsersDAL src;
        [TestMethod]
        public void TestCreateUser()
        {
            User u = new User(2, "test", "test@gmail.com", "12345", Role.USER);

            Assert.AreEqual(u.Id, 2);
            Assert.AreEqual(u.Username, "test");
            Assert.AreEqual(u.Email, "test@gmail.com");
            Assert.AreEqual(u.Password, "12345");
            Assert.AreEqual(u.Role, Role.USER);
        }

        public void TestRegisterUser()
        {

            //UserManager um = new UserManager(src);
        }
    }
}
