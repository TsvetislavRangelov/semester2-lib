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
    public class AdminMangaLibraryModel : PageModel
    {
        public User LoggedUser { get; set; }
        private UserManager um = new UserManager(new UsersDAL());
        public void OnGet()
        {
            LoggedUser = um.GetUser(Convert.ToInt32(HttpContext.Session.GetString("UserId")));
        }
    }
}
