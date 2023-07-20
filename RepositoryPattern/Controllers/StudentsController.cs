using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Data;
using RepositoryPattern.Models;
using RepositoryPattern.UnitOfWork;

namespace RepositoryPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public StudentsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Students
        [HttpGet]
        public async Task<object> GetStudents()
        {
            var list = await _unitOfWork._studentRepository.GetAll();
            return list.ToList();
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            var student = await _unitOfWork._studentRepository.GetById(id);
            if (student == null)
            {
                return NotFound();
            }
            return student;
        }

        // PUT: api/Students/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, Student student)
        {
            var existingStudent = await _unitOfWork._studentRepository.GetById(id);
            if(existingStudent == null)
            {
                return NotFound();
            }
            await _unitOfWork._studentRepository.Update(id, student);
            await _unitOfWork.Save();
            return NoContent();
        }

        // POST: api/Students
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
            await _unitOfWork._studentRepository.Create(student);
            await _unitOfWork.Save();
            return CreatedAtAction("GetStudent", new { id = student.Id }, student);
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var existingStudent = await _unitOfWork._studentRepository.GetById(id);
            if (existingStudent == null)
            {
                return NotFound();
            }
            await _unitOfWork._studentRepository.Delete(id);
            await _unitOfWork.Save();
            return NoContent();
        }

        private Task<bool> StudentExists(int id)
        {
            return _unitOfWork._studentRepository.EntityExists(id);
        }
    }
}
