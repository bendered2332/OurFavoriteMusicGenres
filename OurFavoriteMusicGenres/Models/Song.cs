using System.ComponentModel.DataAnnotations;

namespace OurFavoriteMusicGenres.Models

{
    public class Song
    {
        public int SongId { get; set; }

        [Required(ErrorMessage = "Please enter a song title.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter the song artist.")]
        public string Artist { get; set; }

        [Required(ErrorMessage = "Please select the song genre.")]
        public string GenreId { get; set; }
        public Genre? Genre { get; set; }
    }
}
