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
      
        public IActionResult Index()
        {
            SongViewModel model = new SongViewModel();

            model.Songs = context.Songs
                .Include(s => s.Genre)
                .OrderBy(s => s.Title)
                .ToList();

            return View(model);
        }
        /// <summary>
        /// this is the add button which leads to the Add.Cshtml page 
        /// </summary>
        /// <returns></returns>
        public IActionResult Add()
        {
            SongViewModel model = new SongViewModel();
            model.Genres = context.Genres
                .ToList();
            return View(model);
        }
        /// <summary>
        /// When clicking on the update button this will lead to this function
        /// using id to find song and pass it back to the form 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult UpdateSong(int id)
        {
            SongViewModel model = new SongViewModel();
            model.Genres = context.Genres
                .ToList();

            Song song = context.Songs.Find(id);

            model.selectedSong = song;
            return View("Add", model);
        }

        /// <summary>
        /// This is the form control on the Add.cshtml page
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
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

                if (ModelState.IsValid)
                {
                    if (model.selectedSong.SongId == 0) { 
                        // add song
                        context.Songs.Add(model.selectedSong);
                    }
                    else
                    {
                        // update song
                        context.Songs.Update(model.selectedSong);
                    }
                    context.SaveChanges();
                    return RedirectToAction("Index", "Song");
                }
                else
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors);

                    model.Genres = context.Genres.ToList();
                    return View("Add", model);
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
              
        }

        [HttpPost]
        public IActionResult DeleteSong(int id)
        {
            try
            {
                SongViewModel model = new SongViewModel();


                Song? song = context.Songs.Find(id);

                model.selectedSong = song;
                context.Songs.Remove(model.selectedSong);
                context.SaveChanges();

                return RedirectToAction("Index", "Song");
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
           
        }
    }
}
