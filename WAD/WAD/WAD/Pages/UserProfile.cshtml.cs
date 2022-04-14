using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Models.Models;
using ClassLibrary1.Managers;
using DAL.DAL;
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
        public List<Manga> OwnedManga { get; set; }
        public MangaManager mm = new MangaManager(new MangaDAL());
        public UserContentManager cm = new UserContentManager(new MangaUserDAL());
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("UserId") is null)
            {
                return new RedirectToPageResult("/Error");
            }
            LoggedUser = um.GetUser(Convert.ToInt32(HttpContext.Session.GetString("UserId")));
            OwnedManga = cm.GetOwnedManga(LoggedUser.Id);
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
               return OnGet();
            }
            else
            {
                ViewData["ImageMessage"] = "Image is not valid, please select a new one.";
            }
            return OnGet();
        }
    }
}
