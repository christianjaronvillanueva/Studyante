using Microsoft.EntityFrameworkCore;

using Studyante.DataAccess.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studyante.DataAccess.Repository
{
    public interface IStudentRepository
    {
        Task<Student> Get(int Id);
        IQueryable<Student> GetAll();
        Task<Student> Add(Student student);
        Task<Student> Update(Student student);
        Task<Student> Delete(Student student);
    }
    public class StudentRepository : IStudentRepository
    {
        private readonly StudyanteContext _context;

        public StudentRepository(StudyanteContext context)
        {
            _context = context;
        }
        public async Task<Student> Add(Student student)
        {
            await _context.Students.AddAsync(student).ConfigureAwait(false);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<Student> Delete(Student student)
        {
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return student;
        }

        public async Task<Student> Get(int Id)
        {
            return await _context.Students.SingleOrDefaultAsync(x => x.Id == Id).ConfigureAwait(false);
        }

        public IQueryable<Student> GetAll()
        {
            return _context.Students.AsQueryable();
        }

        public async Task<Student> Update(Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();

            return student;
        }
    }
}
