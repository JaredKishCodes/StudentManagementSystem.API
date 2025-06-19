
using MediatR;
using StudentManagementSystem.Application.Dtos.Subject.Requests;
using StudentManagementSystem.Application.Dtos.Subject.Response;
using StudentManagementSystem.Application.Interfaces;
using StudentManagementSystem.Domain.Entities;
using StudentManagementSystem.Domain.Interfaces;

namespace StudentManagementSystem.Application.Subjects.Commands
{
    public record AddSubjectCommand(SubjectRequestDto subjectReq) : IRequest<SubjectResponseDto>;
    public class AddSubjectCommandHandler(ISubjectService subjectService, ICourseRepository courseRepository)
        : IRequestHandler<AddSubjectCommand, SubjectResponseDto>
    {

        public async Task<SubjectResponseDto> Handle(AddSubjectCommand request, CancellationToken cancellationToken)
        {
            return  await subjectService.AddSubjectAsync(request.subjectReq);
           
        }
    }
}

