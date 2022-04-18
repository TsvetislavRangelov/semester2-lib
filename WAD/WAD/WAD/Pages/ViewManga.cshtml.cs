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
    public class ViewMangaModel : PageModel
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
            if((HttpContext.Session.GetString("UserId")) == null)
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
            ViewData["DeleteMessage"] = "The item you are looking for does not exist.";
            return null;
            
        }

        public IActionResult OnPostUpdateItem()
        {
            DisplayManga = mm.GetMangaById(Int32.Parse(HttpContext.Session.GetString("MangaId")));
            return new RedirectToPageResult("/UpdateManga", DisplayManga.Id);
        }

        public IActionResult OnPostAddItem()
        {
            DisplayManga = mm.GetMangaById(Convert.ToInt32(HttpContext.Session.GetString("MangaId")));
            UserId = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
            if (HttpContext.Session.GetString("MangaId") == null)
            {
                return OnGet(null);
            }
            um.AddMangaToProfile(Convert.ToInt32(HttpContext.Session.GetString("UserId")),Convert.ToInt32(HttpContext.Session.GetString("MangaId")));
            ViewData["DeleteMessage"] = "Successfully added!";
            return null;
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
