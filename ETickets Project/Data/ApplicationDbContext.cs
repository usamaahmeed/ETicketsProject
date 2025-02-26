using ETickets_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace ETickets_Project.Data
{
    public class ApplicationDbContext : DbContext
    {


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<ActorMovie> ActorMovies { get; set; }
        public DbSet<CinemaMovie> CinemaMovies { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure Many-to-Many Relationship for ActorMovies
            modelBuilder.Entity<ActorMovie>()
                .HasKey(am => new { am.ActorID, am.MovieID });

            modelBuilder.Entity<ActorMovie>()
                .HasOne(am => am.Actor)
                .WithMany(a => a.ActorMovies)
                .HasForeignKey(am => am.ActorID);

            modelBuilder.Entity<ActorMovie>()
                .HasOne(am => am.Movie)
                .WithMany(m => m.ActorMovies)
                .HasForeignKey(am => am.MovieID);

            modelBuilder.Entity<CinemaMovie>()
                .HasKey(cm => new { cm.CinemaID, cm.MovieID });

            modelBuilder.Entity<CinemaMovie>()
                .HasOne(cm => cm.Cinema)
                .WithMany(c => c.CinemaMovies)
                .HasForeignKey(cm => cm.CinemaID);
            modelBuilder.Entity<CinemaMovie>()
                .HasOne(cm => cm.Movie)
                .WithMany(m => m.CinemaMovies)
                .HasForeignKey(cm => cm.MovieID);
        }

    }
}
