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
    public class MangaManager : ImageManager
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

        public List<Manga> SortByTitle(List<Manga> inList) =>
             inList.OrderBy(m => m.Title).ToList();
        
        public List<Manga> SortByReleaseDate(List<Manga> inList) =>
             inList.OrderBy(m => m.ReleaseDate).ToList();

        public List<Manga> SortByAuthor(List<Manga> inList) =>
             inList.OrderBy(m => m.Author).ToList();
        
        public bool DeleteMangaById(int id) =>
            this.src.DeleteMangaById(id);

        public void UpdateManga(Manga m) =>
            this.src.UpdateManga(m);

        public List<Manga> GetMangaListNoCover() =>
            this.src.GetMangaListNoCover();
    }
}
