using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClassLibrary1.Managers;
using WAD.Models;

namespace WAD.Pages
{
    public class LoginModel : PageModel
    {
        private readonly UserManager um = new();

        [BindProperty]
        public User LoginUser { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (um.LoginUser(LoginUser))
                {
                    if(LoginUser.Password == LoginUser.ConfirmPassword && LoginUser.DbUsername == LoginUser.Username)
                    {
                        return new RedirectToPageResult("UserProfile");
                    }
                }
                ViewData["successMessage"] = "Your credentials are invalid. Please try again.";
                return Page();
            }
            ViewData["successMessage"] = "YourCredentials are invalid. Please try again.";
            return Page();
        }
    }
}
