using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClassLibrary1.Managers;
using Models.Models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using DAL.DAL;

namespace WAD.Pages
{
    public class LoginModel : PageModel
    {
        public const string SessionKeyRole = "User";

        private readonly ILogger<LoginModel> logger;

        private readonly UserManager um = new(new UsersDAL());

        public LoginModel(ILogger<LoginModel> logger)
        {
            this.logger = logger;
        }

        [BindProperty]
        public UserLogin LoginUser { get; set; }

        public void OnGet()
        {
            HttpContext.Session.Remove("User");
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                User loggedUser = um.LoginUser(LoginUser.Username, LoginUser.Password);

                if (loggedUser != null)
                {

                    if (loggedUser.Role == Models.Enums.Role.USER)
                    {
                        HttpContext.Session.SetString("User", loggedUser.Role.ToString());
                        ViewData["Role"] = HttpContext.Session.GetString("User");

                        return new RedirectToPageResult("/UserProfile");
                    }
                    else
                    {
                        HttpContext.Session.SetString("User", loggedUser.Role.ToString());
                        ViewData["Role"] = HttpContext.Session.GetString("User");
                        return new RedirectToPageResult("/Library");
                    }
                }
                ViewData["successMessage"] = "Your credentials are invalid. Please try again.";
                return Page();
            }
            ViewData["successMessage"] = "Please provide valid credentials.";
            return Page();

        }
    }
}
