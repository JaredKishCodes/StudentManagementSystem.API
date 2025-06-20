using StudentManagementSystem.Domain.Entities;


namespace StudentManagementSystem.Application.Interfaces
{
    public interface IJwtTokenService
    {
        string CreateToken(UserBase user);
    }
}
