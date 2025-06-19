using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using StudentManagementSystem.Application.Dtos.Subject.Requests;
using StudentManagementSystem.Application.Dtos.Subject.Response;
using StudentManagementSystem.Application.Interfaces;

namespace StudentManagementSystem.Application.Subjects.Commands
{
    public record UpdateSubjectCommand(int id, SubjectRequestDto subReqDto) : IRequest<SubjectResponseDto>;
    public class UpdateSubjectCommandHandler(ISubjectService subjectService)
         : IRequestHandler<UpdateSubjectCommand, SubjectResponseDto>
    {
        public async Task<SubjectResponseDto> Handle(UpdateSubjectCommand request, CancellationToken cancellationToken)
        {
            return await subjectService.UpdateSubjectAsync(request.id, request.subReqDto);
        }
    }
}
