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
    public class MangaLibraryModel : PageModel
    {
        [BindProperty, DataType("Manga")]
        public int MangaID { get; set; }
        [BindProperty]
        public User LoggedUser { get; set; }
        public MangaManager mm;
        public UserContentManager cm;
        public UserManager um;
        [BindProperty]
        public Manga[] Mangas { get; set; }

        public MangaLibraryModel()
        {
            this.mm = new MangaManager(new MangaDAL());
            this.cm = new UserContentManager(new MangaUserDAL());
            this.um = new UserManager(new UsersDAL());
        }
        
        public IActionResult OnGet()
        {
            Mangas = mm.GetMangaList().ToArray();

            LoggedUser = um.GetUser(Convert.ToInt32(HttpContext.Session.GetString("UserId")));
            if (LoggedUser == null)
            {
                return new RedirectToPageResult("/Login");
            }
            return null;
        }
    }
}
