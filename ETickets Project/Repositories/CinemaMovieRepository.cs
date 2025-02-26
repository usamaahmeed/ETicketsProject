using ETickets_Project.Data;
using ETickets_Project.Models;
using ETickets_Project.Repositories.IRepositories;

namespace ETickets_Project.Repositories
{
    public class CinemaMovieRepository : Repository<CinemaMovie>, ICinemaMovieRepository
    {
        public CinemaMovieRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
