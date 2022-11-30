using Microsoft.AspNetCore.Mvc;
using OurFavoriteMusicGenres.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace OurFavoriteMusicGenres.Controllers
{
    public class SongController: Controller
    {
        private SongContext context { get; set; }

        public SongController(SongContext ctx)
        {
            context = ctx;
        }
      
        public IActionResult Index()
        {
            SongViewModel model = new SongViewModel();

            model.Songs = context.Songs
                .Include(s => s.Genre)
                .OrderBy(s => s.Title)
                .ToList();

            return View(model);
        }
        // this is the add button which leads to the Add.Cshtml page 
        public IActionResult Add()
        {
            SongViewModel model = new SongViewModel();
            model.Genres = context.Genres
                .ToList();
            return View(model);
        }

        // This is the form control on the Add.cshtml page
        [HttpPost]
        public IActionResult Edit(SongViewModel model)
        {
            try
            {
                // getting Genre name by genre Id
                Genre? data = context.Genres
                    .Find(model.selectedSong.GenreId);

                //Assigning values to the song
                model.selectedSong.Genre = data;

                // saving to database
                if(model.selectedSong.SongId == 0)
                {
                    // add movie
                    context.Songs.Add(model.selectedSong);
                }
                else
                {
                    // update movie
                }
                context.SaveChanges();
                return RedirectToAction("Index", "Song");
            }
            catch(Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
              
        }

    }
}
