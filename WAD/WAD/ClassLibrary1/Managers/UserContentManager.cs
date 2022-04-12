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
            this.mu.AddMangaToProfile(uid, mid);
        }

        public bool UserOwnsManga(int uid, int mid)
        {
            if(this.mu.UserOwnsManga(uid, mid))
            {
                return true;
            }
            return false;
        }
    }
}
