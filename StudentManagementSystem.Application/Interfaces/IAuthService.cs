using StudentManagementSystem.Application.Common;
using StudentManagementSystem.Application.Dtos.Auth;

namespace StudentManagementSystem.Application.Interfaces
{
   public interface IAuthService
    {
        Task<Result<AuthResponseDto>> Login(LoginDto loginDto);
        Task<Result<AuthResponseDto>> Register(RegisterDto registerDto);
    }
}
