using RepositoryPattern.Data;
using RepositoryPattern.Models;
using RepositoryPattern.Repository;

namespace RepositoryPattern.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public IGenericRepository<Student> _studentRepository { get; set; }
        private readonly DataContext _context;
        public UnitOfWork(DataContext context)
        {
            _context= context;
            _studentRepository = new GenericRepository<Student>(_context);
        }
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
