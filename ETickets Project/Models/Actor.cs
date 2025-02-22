using System.ComponentModel.DataAnnotations;

namespace ETickets_Project.Models
{
    public class Actor
    {
        [Key]
        public int ActorID { get; set; }

        [Required, MaxLength(100)]
        public string FirstName { get; set; }

        [Required, MaxLength(100)]
        public string LastName { get; set; }

        public string Bio { get; set; }
        public string ProfilePicture { get; set; }
        public string News { get; set; }

        // Many-to-Many Relationship
        public List<ActorMovie> ActorMovies { get; set; }
    }
}
