using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.Models;
using ClassLibrary1.Managers;
using JointInterfaces.Interfaces;
using Models.Enums;
using System.Collections.Generic;
using BALTest.TestData;

namespace BALTest
{
    [TestClass]
    public class SeriesTests
    {
        [TestMethod]
        public void TestGetSeries()
        {
            SeriesManager sm = new SeriesManager(new FakeSeriesDAL());
            List<Series> emptySeries = new List<Series>();

            List<Series> resultSeries = sm.GetSeries();

            CollectionAssert.AreNotEqual(emptySeries, resultSeries);
        }

        [TestMethod]
        public void TestAddSeries()
        {
            SeriesManager sm = new SeriesManager(new FakeSeriesDAL());
            Series newSeries = new Series(5, "Whatever", 1, 23);

            int result = sm.AddSeries(newSeries);

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void TestUpdateSeries()
        {
            SeriesManager sm = new SeriesManager(new FakeSeriesDAL());
            Series updateSeries = new Series(8, "Whatever", 4, 50);
            Series initial = sm.GetSeries()[1];

            sm.UpdateSeries(updateSeries);

            Assert.AreNotEqual(initial, sm.GetSeries()[1]);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestUpdateSeriesOutOfBounds()
        {
            SeriesManager sm = new SeriesManager(new FakeSeriesDAL());
            Series updateSeries = new Series(8, "Whatever", 4, 50);
            Series initial = sm.GetSeries()[1];

            sm.UpdateSeries(updateSeries);

            Assert.AreNotEqual(initial, sm.GetSeries()[5]);
        }
    }
}
