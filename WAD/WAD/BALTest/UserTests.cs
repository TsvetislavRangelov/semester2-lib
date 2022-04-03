using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.Models;
using ClassLibrary1.Managers;
using JointInterfaces.Interfaces;
using Models.Enums;
using System.Collections.Generic;

namespace BALTest
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void TestCheckIfUserExists()
        {
            //Arrange
            IUsersDAL src = new FakeUserDAL();
            User testUser = new User(2, "user3", "user3@gmail.com", "123abc", Role.ADMIN);
            UserManager um = new UserManager(src);

            //Act
            User result = um.CheckIfUserExists(testUser);

            //Assert
            Assert.AreEqual(result.Id, 2);
            Assert.AreEqual(result.Username, "user3");
            Assert.AreEqual(result.Password, "123abc");
            Assert.AreEqual(result.Email, "user3@gmail.com");
            Assert.AreEqual(result.Role, Role.ADMIN);

        }

        [TestMethod]
        public void TestLoginUser()
        {
            //Arrange
            IUsersDAL src = new FakeUserDAL();
            UserManager um = new UserManager(src);

            //Act
            User result = um.LoginUser("user2", "12345678");

            //Assert
            Assert.AreEqual(result.Id, 1);
            Assert.AreEqual(result.Username, "user2");
            Assert.AreEqual(result.Password, "JdVa0oOqQAr0ZMdtcTwHrQ==");
            Assert.AreEqual(result.Email, "user2@gmail.com");
            Assert.AreEqual(result.Role, Role.USER);
        }

        [TestMethod]
        public void TestRegisterUser()
        {
            //Arrange
            IUsersDAL src = new FakeUserDAL();
            User testUser = new User(6, "testname", "testmail@gmail.com", "1235678", Role.USER);
            UserManager um = new UserManager(src);
            int initialCount = um.GetUsers().Count;

            //Act
            um.RegisterUser(testUser);
            int actualUserCount = src.GetUsers().Count;

            //Assert
            Assert.AreEqual(initialCount, 3);
            Assert.AreEqual(actualUserCount, 4);
        }

        [TestMethod]
        public void TestGetUsers()
        {
            //Arrange
            IUsersDAL src = new FakeUserDAL();
            UserManager um = new UserManager(src);
            List<User> EmptyUsers = new List<User>();


            //Act
            List<User> resultUsers = um.GetUsers();

            
            //Assert
            CollectionAssert.AreNotEqual(EmptyUsers, resultUsers);
        }
    }
}
