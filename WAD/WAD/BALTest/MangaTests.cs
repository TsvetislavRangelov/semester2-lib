using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary1.Managers;
using Models.Models;
using BALTest.TestData;
using System.Collections.Generic;

namespace BALTest
{
    [TestClass]
   public class MangaTests
    {
        [TestMethod]
        public void TestGetMangaList()
        {
            MangaManager mm = new MangaManager(new FakeMangaDAL());

            List<Manga> list = mm.GetMangaList();

            Assert.AreEqual(6, list.Count);
        }

        [TestMethod]
        public void TestGetMangaById()
        {
            MangaManager mm = new MangaManager(new FakeMangaDAL());

            Manga m1 = mm.GetMangaById(2);
            Manga m2 = mm.GetMangaList()[2];

            Assert.AreEqual(m1, m2);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestGetMangaByIdOutOfBounds()
        {
            MangaManager mm = new MangaManager(new FakeMangaDAL());

            Manga m1 = mm.GetMangaById(12);
            Manga m2 = mm.GetMangaList()[12];

            Assert.AreEqual(m1, m2);
        }

        [TestMethod]
        public void TestAddManga()
        {
            MangaManager mm = new MangaManager(new FakeMangaDAL());

            Manga newM = new Manga(15, "example", System.DateTime.Now, "example");

            mm.AddManga(newM);

            Assert.AreEqual(mm.GetMangaList().Count, 7);
        }

        [TestMethod]
        public void TestRemoveManga()
        {
            MangaManager mm = new MangaManager(new FakeMangaDAL());

            mm.DeleteMangaById(mm.GetMangaList()[2].Id);

            Assert.AreEqual(5, mm.GetMangaList().Count);
        }
    }
}
