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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Song>().HasData(
                new Song
                {
                    SongId = 1,
                    Title = "Karma",
                    Artist = "Taylor Swift",
                    GenreId = "P"
                },
                new Song
                {
                    SongId = 2,
                    Title = "Pink Venom",
                    Artist = "BLACKPINK",
                    GenreId = "P"
                }
            );

            modelBuilder.Entity<Genre>().HasData(
                new Genre
                {
                    GenreId = "IF",
                    Name = "Indie Folk"
                },
                new Genre
                {
                    GenreId = "IR",
                    Name = "Indie Rock"
                },
                new Genre
                {
                    GenreId = "P",
                    Name = "Pop"
                },
                new Genre
                {
                    GenreId = "R",
                    Name = "Rap"
                },
                new Genre
                {
                    GenreId = "HH",
                    Name = "Hip Hop"
                }
            );
        }
    }
}
