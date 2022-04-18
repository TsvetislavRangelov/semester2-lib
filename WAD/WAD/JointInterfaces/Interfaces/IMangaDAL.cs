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
        bool DeleteMangaById(int id);
        void UpdateManga(UpdatedManga m, int id);
        List<Manga> GetMangaListNoCover();
        void UploadImage(byte[] img, int id);

    }
}
