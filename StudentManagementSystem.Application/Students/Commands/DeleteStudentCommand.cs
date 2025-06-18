using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using StudentManagementSystem.Application.Interfaces;

namespace StudentManagementSystem.Application.Students.Commands
{   
    public record DeleteStudentCommand(int id) : IRequest<bool>;
    public class DeleteStudentCommandHandler(IStudentService _studentService)
        : IRequestHandler<DeleteStudentCommand, bool>
    {
        public async Task<bool> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            return await _studentService.DeleteStudentAsync(request.id);
        }
    }
}
