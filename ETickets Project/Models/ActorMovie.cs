namespace ETickets_Project.Models
{
    public class ActorMovie
    {
        public int ActorID { get; set; }
        public Actor Actor { get; set; }

        public int MovieID { get; set; }
        public Movie Movie { get; set; }
    }
}
