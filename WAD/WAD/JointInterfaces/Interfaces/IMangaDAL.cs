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
        int AddManga(Manga manga);
        List<Manga> GetMangaList();
        Manga GetMangaById(int id);

    }
}
