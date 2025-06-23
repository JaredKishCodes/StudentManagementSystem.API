using StudentManagementSystem.Domain.Entities;

namespace StudentManagementSystem.Application.Interfaces
{
    public interface IJwtTokenService
    {
        Task<string> CreateTokenAsync(IUserBase user);
    }
}
