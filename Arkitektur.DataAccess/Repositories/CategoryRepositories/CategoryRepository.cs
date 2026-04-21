using Arkitektur.DataAccess.Context;
using Arkitektur.DataAccess.Repositories.GenericRepositories;
using Arkitektur.Entity.Entities;

namespace Arkitektur.DataAccess.Repositories.CategoryRepositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext _context) : base(_context)
        {
        }
    }
}
