using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WAD.Pages
{
    public class LibraryModel : PageModel
    {
        public IActionResult OnGet()
        {
            if(HttpContext.Session.GetString("User") != "ADMIN")
            {
                return new RedirectToPageResult("/Login");
            }
            return null;
        }
    }
}
