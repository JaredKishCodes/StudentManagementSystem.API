using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using StudentManagementSystem.Application.Dtos.Subject.Response;
using StudentManagementSystem.Application.Interfaces;

namespace StudentManagementSystem.Application.Subjects.Queries
{
    public record GetSubjectByIdQuery(int id) : IRequest<SubjectResponseDto>;
    public class GetSubjectByIdQueryHandler(ISubjectService subjectService)
       : IRequestHandler<GetSubjectByIdQuery, SubjectResponseDto>
    {
        public Task<SubjectResponseDto> Handle(GetSubjectByIdQuery request, CancellationToken cancellationToken)
        {
            return subjectService.GetSubjectByIdAsync(request.id);
        }
    }
}
