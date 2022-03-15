using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WAD.Models;

namespace WAD.Pages
{
    public class RegisterModel : PageModel
    {
        UsersDAL da = new UsersDAL();
        [BindProperty]
        public new User User { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                //da.RegisterUser(this.User);
                return new RedirectToPageResult("Login");
            }
            else
            {
                return Page();
            }
        }
    }
}
