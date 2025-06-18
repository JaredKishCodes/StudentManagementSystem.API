

using MediatR;
using StudentManagementSystem.Application.Dtos;
using StudentManagementSystem.Application.Interfaces;

namespace StudentManagementSystem.Application.Students.Query
{
    public record GetAllStudentsQuery() : IRequest<IEnumerable<StudentDTO>>;
    public class GetAllStudentsQueryHandler(IStudentService studentService)
        : IRequestHandler<GetAllStudentsQuery, IEnumerable<StudentDTO>>
    {
        public async Task<IEnumerable<StudentDTO>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            return await studentService.GetAllStudentsAsync();
        }
    }
}
