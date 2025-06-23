using MediatR;
using StudentManagementSystem.Application.Common;
using StudentManagementSystem.Application.Dtos.Auth;
using StudentManagementSystem.Application.Interfaces;

public record LoginCommand(LoginDto UserLogin) : IRequest<Result<AuthResponseDto>>;

public class LoginCommandHandler(IAuthService authService) : IRequestHandler<LoginCommand, Result<AuthResponseDto>>
{
    public Task<Result<AuthResponseDto>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        return authService.Login(request.UserLogin);
    }
}
