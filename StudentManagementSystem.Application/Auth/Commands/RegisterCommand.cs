using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using StudentManagementSystem.Application.Common;
using StudentManagementSystem.Application.Dtos.Auth;
using StudentManagementSystem.Application.Interfaces;

namespace StudentManagementSystem.Application.Auth.Commands
{
    public record RegisterCommand(RegisterDto userRegister) : IRequest<Result<AuthResponseDto>>;

    public class RegisterCommandHandler(IAuthService authService) : IRequestHandler<RegisterCommand, Result<AuthResponseDto>>
    {
        public Task<Result<AuthResponseDto>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            return authService.Register(request.userRegister);
        }
    }
}
