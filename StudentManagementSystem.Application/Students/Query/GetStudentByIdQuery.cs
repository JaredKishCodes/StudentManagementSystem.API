using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using StudentManagementSystem.Application.Dtos;
using StudentManagementSystem.Application.Interfaces;

namespace StudentManagementSystem.Application.Students.Query
{
    public record GetStudentByIdQuery(int id) : IRequest<StudentDTO>;
    public class GetStudentByIdQueryHandler(IStudentService _studentService)
        : IRequestHandler<GetStudentByIdQuery, StudentDTO>
    {
        public async Task<StudentDTO> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            return await _studentService.GetStudentByIdAsync(request.id);
        }
    }
}
