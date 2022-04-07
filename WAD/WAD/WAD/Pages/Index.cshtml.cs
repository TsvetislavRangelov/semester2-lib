using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WAD.Pages
{
    public class IndexModel : PageModel
    {

        public IndexModel()
        {
            
        }

        public IActionResult OnGet()
        {
            if(HttpContext.Session.GetString("User") == "USER")
            {
                return new RedirectToPageResult("UserProfile");
            }
            if(HttpContext.Session.GetString("User") == "ADMIN")
            {
                return new RedirectToPageResult("Library");
            }
            return Page();
        }
    }
}
