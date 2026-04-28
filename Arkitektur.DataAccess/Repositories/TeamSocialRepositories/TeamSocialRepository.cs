using Arkitektur.DataAccess.Context;
using Arkitektur.DataAccess.Repositories.GenericRepositories;
using Arkitektur.Entity.Entities;

namespace Arkitektur.DataAccess.Repositories.TeamSocialRepositories
{
    public class TeamSocialRepository : GenericRepository<TeamSocial>,ITeamSocialRepository
    {
        public TeamSocialRepository(AppDbContext _context) : base(_context)
        {
        }
    }
}
