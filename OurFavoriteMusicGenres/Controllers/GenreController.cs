using Microsoft.AspNetCore.Mvc;

namespace OurFavoriteMusicGenres.Controllers
{
    public class GenreController: Controller
    {

        private readonly ILogger<GenreController> _logger;

        public GenreController(ILogger<GenreController> logger)
        {
            _logger = logger;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Rap()
        {
            return View();
        }

    }
}
