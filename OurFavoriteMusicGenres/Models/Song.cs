namespace OurFavoriteMusicGenres.Models
{
    public class Song
    {
        public int SongId { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}
