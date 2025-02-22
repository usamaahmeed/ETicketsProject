using System.ComponentModel.DataAnnotations;

namespace ETickets_Project.Models
{
    public class Cinema
    {
        [Key]
        public int CinemaID { get; set; }

        [Required, MaxLength(255)]
        public string Name { get; set; }

        public string Description { get; set; }
        public string CinemaLogo { get; set; }

        [Required]
        public string Address { get; set; }

        // علاقة 1:N مع الأفلام
        public List<Movie> Movies { get; set; } = new List<Movie>();
    }
}
