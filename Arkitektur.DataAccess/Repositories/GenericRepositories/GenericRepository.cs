using Arkitektur.DataAccess.Context;
using Arkitektur.Entity.Entities.Common;
using Microsoft.EntityFrameworkCore;




namespace Arkitektur.DataAccess.Repositories.GenericRepositories
{
    public class GenericRepository<TEntity>(AppDbContext _context) : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
      
        private readonly DbSet<TEntity> _table = _context.Set<TEntity>();

        public async Task CreateAsync(TEntity entity)
        {
            await _context.AddAsync(entity);
        }

        public void Delete(TEntity entity)
        {
            _context.Remove(entity);
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
           return await _table.AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _table.FindAsync(id);
        }

        public IQueryable<TEntity> GetQueryable()
        {

            return _table;

        }

        public void Update(TEntity entity)
        {
         
            _context.Update(entity);
        }
    }
}
