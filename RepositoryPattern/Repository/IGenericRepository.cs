using RepositoryPattern.Models;

namespace RepositoryPattern.Repository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(int id);
        Task<TEntity> Update(int id, TEntity entity);
        Task<TEntity> Create(TEntity entity);
        Task<TEntity> Delete(int id);
        Task Save();
        Task<bool> EntityExists(int id);
    }
}
