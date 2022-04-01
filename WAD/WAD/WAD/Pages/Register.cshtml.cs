using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.Models;
using ClassLibrary1.Managers;

namespace WAD.Pages
{
    public class RegisterModel : PageModel
    {
       private readonly UserManager um = new();
        private readonly PasswordManager pm = new();

        [BindProperty]
        public new User User { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
               User.Password = pm.HashPassword(User.Password);
                um.RegisterUser(User);
                ViewData["successMessage"] = "Registration successful. You can now log in.";
                return Page();
            }
            else
            {
                ViewData["successMessage"] = "One or more fields are invalid. Registration failed.";
                return Page();
            }
        }

        //public void ClearFields()
        //{

        //}
    }
}
