using System.Threading;
using System.Threading.Tasks;
using MediatR;
using StudentManagementSystem.Application.Dtos;
using StudentManagementSystem.Application.Interfaces;
using StudentManagementSystem.Domain.Entities;

namespace StudentManagementSystem.Application.Students.Commands
{
    public record AddStudentCommand(StudentRequestDto student) : IRequest<StudentDTO>;

    public class AddStudentCommandHandler : IRequestHandler<AddStudentCommand, StudentDTO>
    {
        private readonly IStudentService _studentService;

        public AddStudentCommandHandler(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public async Task<StudentDTO> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var studentEntity = new Student
            {
                FirstName = request.student.FirstName,
                LastName = request.student.LastName,
                Email = request.student.Email,
                PhoneNumber = request.student.PhoneNumber,
                Address = request.student.Address,
                Gender = request.student.Gender,
                BirthDate = request.student.BirthDate,
                EnrollmentDate = request.student.EnrollmentDate,
                CourseId = request.student.CourseId // ✅ Associate via FK, not CourseDto
            };

            return await _studentService.AddStudent(studentEntity);
        }
    }
}
