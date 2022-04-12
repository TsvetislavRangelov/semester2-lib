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
    public class MangaManager
    {
        private readonly IMangaDAL src;

        public MangaManager(IMangaDAL src)
        {
            this.src = src;
        }

        public int AddManga(Manga manga)
        {
            return this.src.AddManga(manga);
        }

        public List<Manga> GetMangaList()
        {
            return this.src.GetMangaList();
        }

        public Manga GetMangaById(int id)
        {
            Manga result = this.src.GetMangaById(id);

            if (result != null)
            {
                return result;
            }
            return null;
        }

        public string ConvertImage(byte[] img)
        {
            if (img == null)
            {
                return null;
            }
            else
            {
                var base64 = Convert.ToBase64String(img);
                var mangaImg = String.Format("data:image/.*;base64,{0}", base64);
                return mangaImg;
            }
        }

    }
}
