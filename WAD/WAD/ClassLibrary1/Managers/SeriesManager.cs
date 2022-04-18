using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Models;
using JointInterfaces.Interfaces;
using System.Data;

namespace ClassLibrary1.Managers
{
   public class SeriesManager : ImageManager
    {
        private readonly ISeriesDAL src;

        public SeriesManager(ISeriesDAL src)
        {
            this.src = src;
        }
        public List<Series> GetSeries() =>
            this.src.GetSeries();

        public int AddSeries(Series s) =>
            this.src.AddSeries(s);

        public bool DeleteSeries(int id) =>
            this.src.DeleteSeries(id);
        
        public void UpdateSeries(Series s) =>
            this.src.UpdateSeries(s);

        public Series GetSeriesById(int id)
        {
            Series foundSeries = GetSeries().Find(s => s.Id == id);
            if(foundSeries is not null)
            {
                return foundSeries;
            }
            return null; 
        }
    }
}
