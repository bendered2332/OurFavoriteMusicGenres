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
      
        public IActionResult SongTable()
        {
            SongViewModel model = new SongViewModel();
            model.Genres = context.Genres
                .ToList();

            model.Songs = context.Songs
                .Include(s => s.Genre)
                .OrderBy(s => s.Title)
                .ToList();

            return View(model);
        }
        public IActionResult Add()
        {
            SongViewModel model = new SongViewModel();
            model.Genres = context.Genres
                .ToList();
            return View(model);
        }

        [HttpPost]
        public AcceptedResult Edit()
        {
            return Ok();
        }

    }
}
