using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.Models;
using ClassLibrary1.Managers;
using JointInterfaces.Interfaces;
using Models.Enums;
using DAL.DAL;

namespace BALTest
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void TestCheckIfUserExists()
        {
            //Arrange
            User testUser = new User(1, "user2", "user2@gmail.com", "abcdefg", Role.USER);
            UserManager um = new UserManager();

            //Act
            User result = um.CheckIfUserExists(testUser);

            //Assert
            Assert.AreEqual(result.Id, 1);
            Assert.AreEqual(result.Username, "user2");
            Assert.AreEqual(result.Password, "abcdefg");
            Assert.AreEqual(result.Email, "user2@gmail.com");
            Assert.AreEqual(result.Role, Role.USER);

        }
    }
}
