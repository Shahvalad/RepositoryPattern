using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Data;
using RepositoryPattern.Models;

namespace RepositoryPattern.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DataContext _context;
        public StudentRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Student> DeleteStudent(int id)
        {

            var student = await GetStudent(id);
            _context.Students.Remove(student);
            Save();
            return student;
        }

        public async Task<Student> GetStudent(int id)
        {
            return await _context.Students.FindAsync(id);
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student> PostStudent(Student student)
        {
            _context.Students.Add(student);
            Save();
            return student;
        }

        public async Task<Student> PutStudent(int id, Student student)
        {
            Student existingStudent = await _context.Students.FindAsync(id);
            _context.Entry(existingStudent).CurrentValues.SetValues(student);
            _context.Entry(student).State = EntityState.Modified;
            Save();
            return existingStudent;
        }

        public async void Save()
        {
            await _context.SaveChangesAsync();
        }

        public bool StudentExists(int id)
        {
            return (_context.Students?.Any(e => e.Id == id)).GetValueOrDefault();
        }



    }
}
