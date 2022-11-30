using Microsoft.AspNetCore.Mvc;
using OurFavoriteMusicGenres.Models;
using Microsoft.EntityFrameworkCore;

namespace OurFavoriteMusicGenres.Controllers
{
    public class SongController: Controller
    {
        private SongContext context { get; set; }
        
        public SongController(SongContext ctx)
        {
            context = ctx;
        }
        public IActionResult Add()
        {
            return View();
        }
        public IActionResult SongTable()
        {
            SongViewModel model = new SongViewModel();
            model.Songs = context.Songs
                .Include(s => s.Genre)
                .OrderBy(s => s.Title)
                .ToList();
            return View(model);
        }


    }
}
