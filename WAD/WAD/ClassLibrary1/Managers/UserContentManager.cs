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
        private readonly MangaUserDAL mu;

        public UserContentManager(MangaUserDAL mu)
        {
            this.mu = mu;
        }
        public void AddMangaToProfile(int uid, int mid)
        {
            mu.AddMangaToProfile(uid, mid);
        }
    }
}
