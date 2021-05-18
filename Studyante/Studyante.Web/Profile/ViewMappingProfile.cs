using AutoMapper;

using Studyante.DataAccess.Models;
using Studyante.DTO;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Studyante.Web
{
    public class ViewMappingProfile : Profile
    {
        public ViewMappingProfile()
        {
            CreateMap<StudentDTO, Student>();
            CreateMap<Student, StudentDTO>();
        }
    }
}
