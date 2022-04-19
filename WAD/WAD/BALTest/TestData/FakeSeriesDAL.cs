using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Models;
using Models.Enums;
using JointInterfaces.Interfaces;
using System.Data;

namespace BALTest.TestData
{
   public class FakeSeriesDAL : ISeriesDAL
    {
        private List<Series> series;

        public FakeSeriesDAL()
        {
            this.series = new List<Series>
            {
                new Series(1, "Test1", 3, 60),
                new Series(2, "Test2", 5, 80),
                new Series(3, "Test3", 1, 12),
                new Series(4, "Test4", 2, 24)
            };
        }

        public List<Series> GetSeries() =>
            this.series;

        public int AddSeries(Series s)
        {
            this.series.Add(s);
            if (this.series.Count > 4) return 1;
            return 0;
        }

        public void UpdateSeries(Series s) =>
            this.series[1] = s;
        

        public bool DeleteSeries(int id) =>
             false;
        
        

        
    }
}
