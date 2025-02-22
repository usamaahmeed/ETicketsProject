using System.ComponentModel.DataAnnotations;

namespace ETickets_Project.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        // علاقة 1:N مع الأفلام
        public List<Movie> Movies { get; set; }
    }
}
