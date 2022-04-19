using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary1.Managers;
using Models.Models;
using BALTest.TestData;
using System.Collections.Generic;
using System.Linq;

namespace BALTest
{
    [TestClass]
    public class UserMangaTests
    {
        [TestMethod]
        public void TestAddMangaToProfile()
        {
            FakeUserMangaDAL repo = new FakeUserMangaDAL();
            UserContentManager ucm = new UserContentManager(repo);
            int uid = repo.GetUsers()[1].Id;
            int mid = repo.GetMangas()[2].Id;

            ucm.AddMangaToProfile(uid, mid);

            Assert.AreEqual(repo.GetRelationship()[0].Key, 1);
            Assert.AreEqual(repo.GetRelationship()[0].Value, 2); 
        }

        [TestMethod, ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestAddMangaToProfileNoUserId()
        {
            FakeUserMangaDAL repo = new FakeUserMangaDAL();
            UserContentManager ucm = new UserContentManager(repo);
            int uid = repo.GetUsers()[6].Id;
            int mid = repo.GetMangas()[1].Id;

            ucm.AddMangaToProfile(uid, mid);

            Assert.AreEqual(repo.GetRelationship()[0].Key, 6);
            Assert.AreEqual(repo.GetRelationship()[0].Value, 1);
        }

        [TestMethod, ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestAddMangaToProfileNoMangaId()
        {
            FakeUserMangaDAL repo = new FakeUserMangaDAL();
            UserContentManager ucm = new UserContentManager(repo);
            int uid = repo.GetUsers()[1].Id;
            int mid = repo.GetMangas()[8].Id;

            ucm.AddMangaToProfile(uid, mid);

            Assert.AreEqual(repo.GetRelationship()[0].Key, 1);
            Assert.AreEqual(repo.GetRelationship()[0].Value, 8);
        }
        [TestMethod]
        public void TestRemoveOwnedManga()
        {
            FakeUserMangaDAL repo = new FakeUserMangaDAL();
            UserContentManager ucm = new UserContentManager(repo);

            int uid1 = repo.GetUsers()[1].Id;
            int mid1 = repo.GetMangas()[1].Id;
            int uid2 = repo.GetUsers()[2].Id;
            int mid2 = repo.GetUsers()[2].Id;
            ucm.AddMangaToProfile(uid1, mid1);
            ucm.AddMangaToProfile(uid2, mid2);
            ucm.RemoveOwnedManga(uid2, mid2);

            Assert.AreEqual(repo.GetRelationship()[0].Key, 1);
            Assert.AreEqual(repo.GetRelationship()[0].Value, 1);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestRemoveOwnedMangaIndexOutOfRange()
        {
            FakeUserMangaDAL repo = new FakeUserMangaDAL();
            UserContentManager ucm = new UserContentManager(repo);

            int uid1 = repo.GetUsers()[1].Id;
            int mid1 = repo.GetMangas()[1].Id;
            int uid2 = repo.GetUsers()[2].Id;
            int mid2 = repo.GetUsers()[2].Id;
            ucm.AddMangaToProfile(uid1, mid1);
            ucm.AddMangaToProfile(uid2, mid2);
            ucm.RemoveOwnedManga(uid2, mid2);

            Assert.AreEqual(repo.GetRelationship()[1].Key, 1);
            Assert.AreEqual(repo.GetRelationship()[1].Value, 1);
        }
        [TestMethod]
        public void TestUserOwnsManga()
        {
            FakeUserMangaDAL repo = new FakeUserMangaDAL();
            UserContentManager ucm = new UserContentManager(repo);

            int uid1 = repo.GetUsers()[1].Id;
            int mid1 = repo.GetMangas()[3].Id;
            int uid2 = repo.GetUsers()[2].Id;
            int mid2 = repo.GetUsers()[2].Id;
            ucm.AddMangaToProfile(uid1, mid2);
            ucm.AddMangaToProfile(uid2, mid2);

            bool result = ucm.UserOwnsManga(uid2, mid2);

            Assert.AreEqual(true, result);
        }
    }
}
