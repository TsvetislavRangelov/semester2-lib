using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Models;
using JointInterfaces.Interfaces;
using System.Data;
using DAL.DAL;

namespace ClassLibrary1.Managers
{
   public class UserContentManager
    {
        private readonly IMangaUserDAL src;

        public UserContentManager(IMangaUserDAL src)
        {
            this.src = src;
        }
        public void AddMangaToProfile(int uid, int mid) =>
            this.src.AddMangaToProfile(uid, mid);

        public bool UserOwnsManga(int uid, int mid) =>
            this.src.UserOwnsManga(uid, mid);

        public List<Manga> GetOwnedManga(int uid) =>
             src.GetOwnedManga(uid);

        public void RemoveOwnedManga(int uid, int mid) =>
            src.RemoveOwnedManga(uid, mid);
    }
}
