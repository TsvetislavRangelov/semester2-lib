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
        [BindProperty]
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
        
        public IActionResult OnGet(string sortOrder)
        {

            if (Int32.Parse(HttpContext.Session.GetString("UserId")) == 0)
            {
                return new RedirectToPageResult("/Login");
            }
            ViewData["TitleSort"] = String.IsNullOrEmpty(sortOrder) ? "title_descending" : "";
            ViewData["AuthorSort"] = sortOrder == "Author" ? "author_desc" : "Author";
            ViewData["ReleaseDateSort"] = sortOrder == "Release Date" ? "release_date_desc" : "Release Date";
            Mangas = mm.GetMangaList().ToArray();
            LoggedUser = um.GetUser(Convert.ToInt32(HttpContext.Session.GetString("UserId")));
            switch (sortOrder)
            {
                case "title_descending":
                    Mangas = Mangas.OrderByDescending(m => m.Title).ToArray();
                    break;
                case "Author":
                    Mangas = Mangas.OrderBy(m => m.Author).ToArray();
                    break;
                case "author_desc":
                    Mangas = Mangas.OrderByDescending(m => m.Author).ToArray();
                    break;
                case "Release Date":
                    Mangas = Mangas.OrderBy(m => m.ReleaseDate).ToArray();
                    break;
                case "release_date_desc":
                    Mangas = Mangas.OrderByDescending(m => m.ReleaseDate).ToArray();
                    break;
                default:
                    Mangas = Mangas.OrderBy(s => s.Title).ToArray();
                    break;
            }
            return Page();
        }
    }
}
