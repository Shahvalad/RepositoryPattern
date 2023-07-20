using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Data;
using RepositoryPattern.Models;

namespace RepositoryPattern.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly DataContext _context;
        private DbSet<TEntity> Table => _context.Set<TEntity>();
        public GenericRepository(DataContext context)
        {
            _context = context;
        }
        
        public async Task<TEntity> Create(TEntity entity)
        {
            await Table.AddAsync(entity);
            return entity;
        }

        public async Task<TEntity> Delete(int id)
        {
            var entity = await GetById(id);
            Table.Remove(entity);
            return entity;
        }

        public async Task<bool> EntityExists(int id)
        {
            return GetById(id) != null;
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            IEnumerable<TEntity> list = await Table.ToListAsync();
            return list;
        }

        public async Task<TEntity> GetById(int id)
        {
            return await Table.FindAsync(id);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<TEntity> Update(int id, TEntity entity)
        {
            var existingEntity = await GetById(id);
            _context.Entry(existingEntity).CurrentValues.SetValues(entity);
            return entity;
        }
    }
}
