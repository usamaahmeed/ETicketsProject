using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ETickets_Project.Models
{
    public class CinemaMovie
    {

        // Foreign Key for Movie
        public int MovieID { get; set; }
        [ForeignKey("MovieID")]
        public Movie Movie { get; set; }

        // Foreign Key for Cinema
        public int CinemaID { get; set; }
        [ForeignKey("CinemaID")]
        public Cinema Cinema { get; set; }
    }
}
