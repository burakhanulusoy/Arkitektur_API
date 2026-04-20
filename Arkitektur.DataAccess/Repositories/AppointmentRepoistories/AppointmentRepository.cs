using Arkitektur.DataAccess.Context;
using Arkitektur.DataAccess.Repositories.GenericRepositories;
using Arkitektur.Entity.Entities;

namespace Arkitektur.DataAccess.Repositories.AppointmentRepoistories
{
    public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(AppDbContext _context) : base(_context)
        {

        }

    }
}
