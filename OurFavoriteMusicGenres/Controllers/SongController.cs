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
            var songs = context.Songs
                .Include(s => s.Genre)
                .OrderBy(s => s.Title)
                .ToList();
            return View(songs);
        }


    }
}
