using Arkitektur.DataAccess.Context;
using Arkitektur.DataAccess.Repositories.GenericRepositories;
using Arkitektur.Entity.Entities;

namespace Arkitektur.DataAccess.Repositories.BannerRepositories
{
    public class BannerRepository : GenericRepository<Banner>, IBannerRepository
    {
        public BannerRepository(AppDbContext _context) : base(_context)
        {
        }
    }
}
