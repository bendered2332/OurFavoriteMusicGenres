using Microsoft.AspNetCore.Mvc;

namespace OurFavoriteMusicGenres.Controllers
{
    public class SongController: Controller
    {

        private readonly ILogger<SongController> _logger;

        public SongController(ILogger<SongController> logger)
        {
            _logger = logger;
        }


        public IActionResult SongTable()
        {
            return View();
        }


    }
}
