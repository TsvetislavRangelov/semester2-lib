using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using Models.Models;
using ClassLibrary1.Managers;
using DAL.DAL;
using JointInterfaces.Interfaces;

namespace WAD.Pages
{
    public class UserProfileModel : PageModel
    {
        [BindProperty]
        public User LoggedUser { get; set; }
        public UserManager um = new UserManager(new UsersDAL());
        public IActionResult OnGet()
        {
            LoggedUser = um.GetUser(Convert.ToInt32(HttpContext.Session.GetString("UserId")));
            if(LoggedUser == null)
            {
                return new RedirectToPageResult("/Login");
            }
            return null;
        }
    }
}
