using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

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

        public string MovieStatus { get; set; } // Available (true) or Unavailable (false)

        // Foreign Keys
        public int CinemaId { get; set; }
        [ForeignKey("CinemaId")]
        public Cinema Cinema { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }



        // Many-to-Many with Actors
        public List<ActorMovie> ActorMovies { get; set; }
    }
}
