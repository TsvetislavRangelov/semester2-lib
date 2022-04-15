using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Models;
using System.Data;

namespace JointInterfaces.Interfaces
{
   public interface ISeriesDAL
    {
        int AddSeries(Series s);
        List<Series> GetSeries();
        bool DeleteSeries(int id);
        void UpdateSeries(Series s);
    }
}
