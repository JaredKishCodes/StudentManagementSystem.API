using StudentManagementSystem.Application.Dtos.Auth;

namespace StudentManagementSystem.Application.Interfaces
{
     interface IAuthService
    {
        string Login(LoginDto loginDto);
        string Register(RegisterDto registerDto);
    }
}
