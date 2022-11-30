using Microsoft.AspNetCore.Mvc;
using OurFavoriteMusicGenres.Models;

namespace OurFavoriteMusicGenres.Controllers
{
    public class SongController: Controller
    {

        private readonly ILogger<SongController> _logger;
        private readonly SongContext _context;

        public SongController(ILogger<SongController> logger, SongContext context)
        {
            _logger = logger;
            _context = context;
        }


        public IActionResult SongTable()
        {
            return View();
        }


    }
}
