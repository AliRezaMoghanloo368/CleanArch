
using CleanArch.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Data.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _context;
        public GenericRepository(DbContext context)
        {
            _context = context;
        }

        public async Task Create(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<TEntity> GetAsync(string id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<IQueryable<TEntity>> GetAll()
        {
            return _context.Set<TEntity>().AsQueryable().AsNoTracking();
        }
    }
}
