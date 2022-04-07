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

        public void AddManga(Manga manga)
        {
            this.src.AddManga(manga);
        }

        public List<Manga> GetMangaList()
        {
            return this.src.GetMangaList();
        }

        public Manga GetMangaById(int id)
        {
            Manga result = this.src.GetMangaById(id);

            if(result != null)
            {
                return result;
            }
            return null;
        }
    }
}
