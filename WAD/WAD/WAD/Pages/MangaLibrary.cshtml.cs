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
    public class MangaLibraryModel : PageModel
    {
        [BindProperty]
        public User LoggedUser { get; set; }
        public UserManager um;

        public MangaLibraryModel()
        {
            this.um = new UserManager(new UsersDAL());
        }
        
        public IActionResult OnGet()
        {
            LoggedUser = um.GetUser(Convert.ToInt32(HttpContext.Session.GetString("UserId")));
            if (LoggedUser == null)
            {
                return new RedirectToPageResult("/Login");
            }
            return null;
        }

        public void OnPost()
        {

        }

        public IActionResult OnPostAddToList()
        {
            return Page();
        }
    }
}
