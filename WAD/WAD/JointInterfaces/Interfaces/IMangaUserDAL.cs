using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Models;
using System.Data;

namespace JointInterfaces.Interfaces
{
   public interface IMangaUserDAL
    {
        void AddMangaToProfile(int uid, int mid);
        bool UserOwnsManga(int uid, int mid);
        List<Manga> GetOwnedManga(int uid);
        void RemoveOwnedManga(int uid, int mid);
    }
}
