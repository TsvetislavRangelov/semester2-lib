using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.Models;
using ClassLibrary1.Managers;
using JointInterfaces.Interfaces;
using Models.Enums;
using System.Collections.Generic;
using System.Linq;

namespace BALTest
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void TestCheckIfUserExists()
        {
            //Arrange
            
            User testUser = new User(2, "user3", "user3@gmail.com", "123abc", Role.ADMIN);
            UserManager um = new UserManager(new FakeUserDAL());

            //Act
            User result = um.CheckIfUserExists(testUser.Username);

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
            
            UserManager um = new UserManager(new FakeUserDAL());

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
        public void TestFailedLoginUser()
        {
            UserManager um = new UserManager(new FakeUserDAL());

            User result = um.LoginUser("user2", "falsepassword");

            Assert.AreEqual(result, null);
        }

        [TestMethod]
        public void TestRegisterUser()
        {
            //Arrange
            
            User testUser = new User(6, "testname", "testmail@gmail.com", "1235678", Role.USER);
            UserManager um = new UserManager(new FakeUserDAL());
            int initialCount = um.GetUsers().Count;

            //Act
            um.RegisterUser(testUser);
            int actualUserCount = um.GetUsers().Count;

            //Assert
            Assert.AreEqual(initialCount, 4);
            Assert.AreEqual(actualUserCount, 5);
        }

        [TestMethod]
        public void TestGetUsers()
        {
            //Arrange
            UserManager um = new UserManager(new FakeUserDAL());
            List<User> EmptyUsers = new List<User>();

            //Act
            List<User> resultUsers = um.GetUsers();

            //Assert
            CollectionAssert.AreNotEqual(EmptyUsers, resultUsers);
        }

        [TestMethod]
        public void TestDeleteUser()
        {
            UserManager um = new UserManager(new FakeUserDAL());

            um.DeleteUser(1);
            um.DeleteUser(2);

            Assert.AreEqual(um.GetUsers().Count, 2);
        }

        [TestMethod]
        public void TestChangeRole()
        {
            UserManager um = new UserManager(new FakeUserDAL());

            um.ChangeRole(1, "ADMIN");

            Assert.AreEqual(Role.ADMIN, um.GetUsers()[1].Role);
        }

        [TestMethod, ExpectedException(typeof(NullReferenceException),
            "User Id was not found")]
        public void TestChangeRoleOutOfRangeId()
        {
            UserManager um = new UserManager(new FakeUserDAL());

            um.ChangeRole(7, "ADMIN");

            Assert.AreEqual(Role.ADMIN, um.GetUsers()[7].Role);
        }

        [TestMethod]
        public void TestUploadImage()
        {
            UserManager um = new UserManager(new FakeUserDAL());
            byte[] image = Enumerable.Repeat((byte)0x20, 20).ToArray();

            um.UploadImage(image, 2);

            Assert.AreEqual(um.GetUsers()[2].Image, image);
        }

        [TestMethod, ExpectedException(typeof(NullReferenceException),
            "User Id was not found.")]
        public void TestUploadImageNullId()
        {
            UserManager um = new UserManager(new FakeUserDAL());
            byte[] image = Enumerable.Repeat((byte)0x20, 20).ToArray();

            um.UploadImage(image, 30);

            Assert.AreNotEqual(um.GetUsers()[30].Image, image);
        }

        [TestMethod]
        public void TestGetPasswordSalt()
        {
            UserManager um = new UserManager(new FakeUserDAL());

           string salt = um.GetPasswordSalt(um.GetUsers()[3].Id);

            Assert.AreEqual("RandomSaltTest", salt); 
        }
    }
}
