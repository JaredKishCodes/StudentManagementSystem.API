using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using StudentManagementSystem.Application.Dtos.Subject.Response;
using StudentManagementSystem.Application.Interfaces;

namespace StudentManagementSystem.Application.Subjects.Commands
{
    public record DeleteSubjectCommand(int id) : IRequest<bool>;
    public class DeleteSubjectCommandHandler(ISubjectService subjectService)
         : IRequestHandler<DeleteSubjectCommand, bool>
    {

        public async Task<bool> Handle(DeleteSubjectCommand request, CancellationToken cancellationToken)
        {
            return await subjectService.DeleteSubjectAsync(request.id);

        }
    }
}
