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


        public IActionResult GenreTable()
        {
            return View();
        }


    }
}
