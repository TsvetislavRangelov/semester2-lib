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

        public int AddManga(Manga manga) =>
             this.src.AddManga(manga);
        

        public List<Manga> GetMangaList() =>
            this.src.GetMangaList();
        

        public Manga GetMangaById(int id)
        {
            Manga foundManga = GetMangaList().Find(m => m.Id == id);
            if(foundManga is not null)
            {
                return foundManga;
            }
            return null;
        }

        public List<Manga> SortByTitle(List<Manga> inList)
        {
            List<Manga> returnList = inList.OrderBy(m => m.Title).ToList();
            return returnList;
        }

        public List<Manga> SortByReleaseDate(List<Manga> inList)
        {
            List<Manga> returnList = inList.OrderBy(m => m.ReleaseDate).ToList();
            return returnList;
        }

        public List<Manga> SortById(List<Manga> inList)
        {
            List<Manga> returnList = inList.OrderBy(m => m.Id).ToList();
            return returnList;
        }

        public bool DeleteMangaById(int id)
        {
            bool result = this.src.DeleteMangaById(id) ? true : false;
            return result;
            
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
