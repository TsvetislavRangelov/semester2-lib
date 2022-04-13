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
using System.ComponentModel.DataAnnotations;

namespace WAD.Pages
{
    public class UpdateMangaModel : PageModel
    {
        [BindProperty]
        public Manga DisplayMangaUpdate { get; set; }
        public MangaManager mm = new MangaManager(new MangaDAL());
        public IActionResult OnGet(int id)
        {
            if(Convert.ToInt32(HttpContext.Session.GetString("UserId")) == 0 || HttpContext.Session.GetString("MangaId") == null)
            {
                return new RedirectToPageResult("/Error");
            }
            DisplayMangaUpdate = mm.GetMangaById(id);
            return null;
        }
    }
}
