using AutoMapper;

using Microsoft.EntityFrameworkCore;

using Studyante.DataAccess.Models;
using Studyante.DataAccess.Repository;
using Studyante.DTO;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studyante.Service
{
    public interface IStudentService
    {
        Task<StudentDTO> Get(int Id);
        Task<IEnumerable<StudentDTO>> GetAll();
        Task<StudentDTO> Add(StudentDTO student);
        Task<StudentDTO> Update(StudentDTO student);
        Task<StudentDTO> Delete(StudentDTO student);
    }
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repository;
        private readonly IMapper _mapper;
        public StudentService(IStudentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<StudentDTO> Add(StudentDTO student)
        {
            var result = await _repository.Add(_mapper.Map<Student>(student)).ConfigureAwait(false);
            return _mapper.Map<StudentDTO>(result);
        }

        public async Task<StudentDTO> Delete(StudentDTO student)
        {
            var result = await _repository.Delete(_mapper.Map<Student>(student)).ConfigureAwait(false);
            return _mapper.Map<StudentDTO>(result);
        }

        public async Task<StudentDTO> Get(int Id)
        {
            var result = await _repository.Get(Id).ConfigureAwait(false);
            return _mapper.Map<StudentDTO>(result);
        }

        public async Task<IEnumerable<StudentDTO>> GetAll()
        {
            var result = await _repository.GetAll().ToListAsync().ConfigureAwait(false);
            return _mapper.Map<IEnumerable<StudentDTO>>(result);

        }

        public async Task<StudentDTO> Update(StudentDTO student)
        {
            var result = await _repository.Update(_mapper.Map<Student>(student)).ConfigureAwait(false);
            return _mapper.Map<StudentDTO>(result);
        }
    }
}
