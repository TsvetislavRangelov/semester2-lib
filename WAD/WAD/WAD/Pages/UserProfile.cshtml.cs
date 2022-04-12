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
using System.IO;

namespace WAD.Pages
{
    public class UserProfileModel : PageModel
    {
        [BindProperty]
        public User LoggedUser { get; set; }
        public UserManager um = new UserManager(new UsersDAL());
        [BindProperty]
        public IFormFile Image { get; set; }
        public IActionResult OnGet()
        {
            LoggedUser = um.GetUser(Convert.ToInt32(HttpContext.Session.GetString("UserId")));
            if(LoggedUser == null)
            {
                return new RedirectToPageResult("/Error");
            }
            return null;
        }

        public async Task<IActionResult> OnPost(IFormFile image)
        {
            LoggedUser = um.GetUser(Convert.ToInt32(HttpContext.Session.GetString("UserId")));
            if (image != null)
            {
                using (var stream = new MemoryStream())
                {
                    await image.CopyToAsync(stream);
                    LoggedUser.Image = stream.ToArray();
                    
                }
                um.UploadImage(LoggedUser.Image, LoggedUser.Id);
                ViewData["ImageMessage"] = "Image has been uploaded";
            }
            else
            {
                ViewData["ImageMessage"] = "Image is not valid, please select a new one.";
            }
            return Page();
        }



    }
}
