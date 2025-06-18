using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using StudentManagementSystem.Application.Dtos;
using StudentManagementSystem.Domain.Interfaces;

namespace StudentManagementSystem.Application.Courses.Commands
{   
    public record DeleteCourseCommand(int id) : IRequest<bool>;
    public class DeleteCourseCommandHandler(ICourseRepository _courseRepository)
        : IRequestHandler<DeleteCourseCommand, bool>
    {
        public async Task<bool> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            return await _courseRepository.DeleteCourseAsync(request.id);
        }
    }
}
