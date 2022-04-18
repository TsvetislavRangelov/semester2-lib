using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClassLibrary1.Managers;
using Models.Models;
using DAL.DAL;
using System.IO;

namespace WAD.Pages
{
    public class UpdateMangaModel : PageModel
    {
        [BindProperty]
        public Manga DisplayMangaUpdate { get; set; }
        [BindProperty]
        public UpdatedManga Updated { get; set; }
        public int UserId { get; set; }
        [BindProperty]
        public IFormFile Image { get; set; }

        public MangaManager mm = new MangaManager(new MangaDAL());
        public IActionResult OnGet(int id)
        {
            if (Int32.Parse(HttpContext.Session.GetString("UserId")) == 0)
            {
                return new RedirectToPageResult("/Error");
            }
            DisplayMangaUpdate = mm.GetMangaById(id);
            return null;
        }

        public IActionResult OnPostUpdate()
        {
            DisplayMangaUpdate = mm.GetMangaById(Int32.Parse(HttpContext.Session.GetString("MangaId")));
            
            if (ModelState.IsValid)
            {
                mm.UpdateManga(Updated, Int32.Parse(HttpContext.Session.GetString("MangaId")));
                ViewData["SuccessMessage"] = "Manga successfully updated.";
            }
            ViewData["SuccessMessage"] = "Manga was updated successfully.";
            return Page();
        }

        public async Task<IActionResult> OnPostUpload(IFormFile image)
        {
            DisplayMangaUpdate = mm.GetMangaById(Int32.Parse(HttpContext.Session.GetString("MangaId")));
            if (image != null)
            {
                using (var stream = new MemoryStream())
                {
                    await image.CopyToAsync(stream);
                    DisplayMangaUpdate.Image = stream.ToArray();

                }
                mm.UploadImage(DisplayMangaUpdate.Image, DisplayMangaUpdate.Id);
                ViewData["ImageMessage"] = "Image has been uploaded";
                return OnGet(DisplayMangaUpdate.Id);
            }
            else
            {
                ViewData["ImageMessage"] = "Image is not valid, please select a new one.";
            }
            return OnGet(Int32.Parse(HttpContext.Session.GetString("MangaId")));
        }
    }
}
