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
using System.ComponentModel.DataAnnotations;

namespace WAD.Pages
{
    public class ViewMangaModel : PageModel
    {
        [BindProperty]
        public Manga DisplayManga { get; set; }
        [BindProperty]
        public int UserId { get; set; }
        public UserManager usermanager = new UserManager(new UsersDAL());
        public MangaManager mm = new MangaManager(new MangaDAL());
        public UserContentManager um = new UserContentManager(new MangaUserDAL());

        public IActionResult OnGet(int id)
        {
            if(Convert.ToInt32(HttpContext.Session.GetString("UserId")) == 0)
            {
                return new RedirectToPageResult("/Error");
            }
            UserId = usermanager.GetUser(Convert.ToInt32(HttpContext.Session.GetString("UserId"))).Id;
            
            DisplayManga = mm.GetMangaById(id);
            HttpContext.Session.SetString("MangaId", DisplayManga.Id.ToString());
            return null;
            
        }

        public void OnPost()
        {
            um.AddMangaToProfile(Convert.ToInt32(HttpContext.Session.GetString("UserId")), DisplayManga.Id);
            OnGet(DisplayManga.Id);
        }

        public void OnPostDeleteItem()
        {
            UserId = usermanager.GetUser(Convert.ToInt32(HttpContext.Session.GetString("UserId"))).Id;
            if (mm.DeleteMangaById(Convert.ToInt32(HttpContext.Session.GetString("MangaId"))))
            {
                HttpContext.Session.Remove("MangaId");
                ViewData["DeleteMessage"] = "Deletion successful.";
                
            }
            else
            {
                ViewData["DeleteMessage"] = "Deletion failed. Try again in a few minutes.";
            }

        }
    }
}
