using ETickets_Project.Data;
using ETickets_Project.Models;
using ETickets_Project.Repositories.IRepositories;

namespace ETickets_Project.Repositories
{
    public class ActorMoviesRepository : Repository<ActorMovie>, IActorMoviesRepository
    {
        public ActorMoviesRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
