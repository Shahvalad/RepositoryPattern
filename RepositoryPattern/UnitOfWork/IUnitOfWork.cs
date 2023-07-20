using RepositoryPattern.Models;
using RepositoryPattern.Repository;

namespace RepositoryPattern.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IGenericRepository<Student> _studentRepository { get; set; }
        public Task Save();
    }
}
