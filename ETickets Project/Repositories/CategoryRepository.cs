using ETickets_Project.Data;
using ETickets_Project.Models;
using ETickets_Project.Repositories.IRepositories;

namespace ETickets_Project.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
