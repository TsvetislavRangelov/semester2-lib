﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Models;
using JointInterfaces.Interfaces;
namespace BALTest.TestData
{
   public class FakeMangaDAL : IMangaDAL
    {
        List<Manga> mangas;

        public FakeMangaDAL()
        {
            this.mangas = new List<Manga>
            {
                new Manga(0, "manga1", DateTime.Now, "auth1"),
                new Manga(1, "manga2", DateTime.Now, "auth2"),
                new Manga(2, "manga3", DateTime.Now, "auth3"),
                new Manga(3, "manga4", DateTime.Now, "auth4"),
                new Manga(4, "manga5", DateTime.Now, "auth5"),
                new Manga(5, "manga6", DateTime.Now, "auth6")

            };

        }
        
        public List<Manga> GetMangaList()
        {
            return this.mangas;
        }

        public int AddManga(Manga m)
        {
            this.mangas.Add(m);
            if(this.mangas.Count > 6)
            {
                return 1;
            }
            return 0;
        }

        public Manga GetMangaById(int id)
        {
            foreach(Manga m in this.GetMangaList())
            {
                if(m.Id == id)
                {
                    return m;
                }
            }
            return null;
        }

        public bool DeleteMangaById(int id)
        {
            return false;
        }

    }
}