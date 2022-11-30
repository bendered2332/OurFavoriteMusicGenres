using Microsoft.EntityFrameworkCore;

namespace OurFavoriteMusicGenres.Models
{
    public class SongContext : DbContext
    {
        public SongContext(DbContextOptions<SongContext> options)
            : base(options)
        { }

        public DbSet<Song> Songs { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }
}
