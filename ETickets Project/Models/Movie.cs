using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ETickets_Project.Models
{
    public class Movie
    {
        [Key]
        public int MovieID { get; set; }

        [Required, MaxLength(255)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        public string ImgUrl { get; set; }

        public string TrailerUrl { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string MovieStatus { get; set; } // Available, Coming Soon, etc.

        // Foreign Key for Category
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        // Many-to-Many with Cinemas
        public List<CinemaMovie> CinemaMovies { get; set; }

        // Many-to-Many with Actors
        public List<ActorMovie> ActorMovies { get; set; } 
    }
}
