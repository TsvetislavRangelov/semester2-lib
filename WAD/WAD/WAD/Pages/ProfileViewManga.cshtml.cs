using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClassLibrary1.Managers;
using Models.Models;
using DAL.DAL;

namespace WAD.Pages
{
    public class ProfileViewMangaModel : PageModel
    {
        [BindProperty]
        public Manga DisplayManga { get; set; }
        [BindProperty]
        public int UserId { get; set; }
        public UserManager usermanager = new UserManager(new UsersDAL());
        public MangaManager mm = new MangaManager(new MangaDAL());
        public UserContentManager um = new UserContentManager(new MangaUserDAL());

        public IActionResult OnGet(int? id)
        {
            if (HttpContext.Session.GetString("UserId") == null)
            {
                return new RedirectToPageResult("/Error");
            }
            if (id.HasValue)
            {
                UserId = usermanager.GetUser(Convert.ToInt32(HttpContext.Session.GetString("UserId"))).Id;

                DisplayManga = mm.GetMangaById((int)id);
                HttpContext.Session.SetString("MangaId", DisplayManga.Id.ToString());
                return null;
            }
           
            return null;

        }
        
        public IActionResult OnPost()
        {
            int mid = Int32.Parse(HttpContext.Session.GetString("MangaId"));
            int uid = Int32.Parse(HttpContext.Session.GetString("UserId"));
            um.RemoveOwnedManga(uid, mid);
            HttpContext.Session.Remove("MangaId");
            ViewData["DeleteMessage"] = "Removed from list successfully";
            return OnGet(mid);
        }
    }
}
