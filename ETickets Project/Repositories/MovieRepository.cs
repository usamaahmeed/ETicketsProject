using ETickets_Project.Data;
using ETickets_Project.Models;
using ETickets_Project.Repositories.IRepositories;

namespace ETickets_Project.Repositories
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        public MovieRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
