using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Data;
using RepositoryPattern.Models;

namespace RepositoryPattern.Repository
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetStudents();
        Task<Student> GetStudent(int id);
        Task<Student> PutStudent(int id,Student student);
        Task<Student> PostStudent(Student student);
        Task<Student> DeleteStudent(int id);
        void Save();
        bool StudentExists(int id);
    }
}
