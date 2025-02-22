using ETickets_Project.Data;
using ETickets_Project.Models;
using ETickets_Project.Repositories.IRepositories;

namespace ETickets_Project.Repositories
{
    public class ActorRepository : Repository<Actor>, IActorRepository
    {
        public ActorRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
