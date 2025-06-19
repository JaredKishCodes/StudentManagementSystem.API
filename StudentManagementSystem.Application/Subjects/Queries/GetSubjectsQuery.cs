using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using StudentManagementSystem.Application.Dtos.Subject.Response;
using StudentManagementSystem.Application.Interfaces;
using StudentManagementSystem.Domain.Entities;

namespace StudentManagementSystem.Application.Subjects.Queries
{
    public record GetSubjectsQuery() : IRequest<IEnumerable<SubjectResponseDto>>;
    public class GetSubjectsQueryHandler(ISubjectService subjectService)
       : IRequestHandler<GetSubjectsQuery, IEnumerable<SubjectResponseDto>>
    {
        public async Task<IEnumerable<SubjectResponseDto>> Handle(GetSubjectsQuery request, CancellationToken cancellationToken)
        {
            return await subjectService.GetAllSubjectAsync();
        }
    }
}
