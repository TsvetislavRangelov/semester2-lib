using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Models;
using System.Data;

namespace JointInterfaces.Interfaces
{
   public interface IMangaDAL
    {
        void AddManga(Manga manga);
    }
}
