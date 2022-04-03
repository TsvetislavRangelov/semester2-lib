using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JointInterfaces.Interfaces;
using Models.Models;
using ClassLibrary1.Managers;

namespace BALTest
{
    [TestClass]
   public class ItemTests
    {
        [TestMethod]
        public void TestGetItems()
        {
            //Arrange
            IItemDAL src = new FakeItemDAL();
            ItemManager im = new ItemManager(src);
            List<LibraryItem> emptyItems = new List<LibraryItem>();
           

            //Act
            List<LibraryItem> resultItems = im.GetItems();

            CollectionAssert.AreNotEqual(emptyItems, resultItems);
        }

        [TestMethod]
        public void TestAddItem()
        {
            //Arrange
            IItemDAL src = new FakeItemDAL();
            ItemManager im = new ItemManager(src);
            LibraryItem testItem = new LibraryItem(12, "example6", DateTime.Now, "author10", Models.Enums.Genre.SCIENCE);
            int initial = im.GetItems().Count;
            //Act
            im.AddItem(testItem);
            int actual = im.GetItems().Count;

            //Assert
            Assert.AreEqual(initial, 3);
            Assert.AreEqual(actual, 4);
        }
    }
}
