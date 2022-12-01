namespace OurFavoriteMusicGenres.Models
{
    public class SongViewModel
    {
        public SongViewModel() { }

        public List<Song> ?Songs { get; set; }
        public List<Genre> ?Genres { get; set; }
        public Song selectedSong { get; set; } // use this when updating a song
    }
}
