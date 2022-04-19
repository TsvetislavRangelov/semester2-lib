using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models.Models;
using Models.Enums;
using ClassLibrary1.Managers;
using DAL.DAL;

namespace WAD.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public User LoggedUser { get; set; }
        public UserManager um;

        public IndexModel()
        {
            this.um = new UserManager(new UsersDAL());
        }

        public IActionResult OnGet()
        {
            LoggedUser = um.GetUser(Convert.ToInt32(HttpContext.Session.GetString("UserId")));
            if(LoggedUser == null)
            {
                return null;
            }
            else if(LoggedUser.Role == Role.ADMIN)
            {
                return new RedirectToPageResult("/UserProfile");
            }
            else
            {
                return new RedirectToPageResult("/UserProfile");
            }
        }
    }
}
