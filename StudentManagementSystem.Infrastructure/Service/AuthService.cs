using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Application.Common;
using StudentManagementSystem.Application.Dtos.Auth;
using StudentManagementSystem.Application.Interfaces;
using StudentManagementSystem.Infrastructure.Entities;

namespace StudentManagementSystem.Infrastructure.Services
{
    public class AuthService(SignInManager<AppUser> _signInManager, UserManager<AppUser> _userManager, IJwtTokenService jwtTokenService) : IAuthService
    {
        public async Task<Result<AuthResponseDto>> Login(LoginDto loginDto)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(loginDto.Email);
                if (user == null)
                {
                    return Result<AuthResponseDto>.Failure("Invalid email");
                }

                var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

                if (!result.Succeeded)
                {
                    return Result<AuthResponseDto>.Failure("Invalid password");
                }

                var token = await jwtTokenService.CreateTokenAsync(user);

                var response = new AuthResponseDto
                {
                    Message = "Login Success!",
                    Token = token,
                    Status = true,
                    Email = user.Email,
                    Username = user.UserName
                };

                return Result<AuthResponseDto>.Success(response);
            }
            catch (Exception ex)
            {
                return Result<AuthResponseDto>.Failure($"Login failed: {ex.Message}");
            }
        }

        public async Task<Result<AuthResponseDto>> Register(RegisterDto registerDto)
        {
            var user = await _userManager.FindByEmailAsync(registerDto.Email);
            if (user != null)
            {
                return Result<AuthResponseDto>.Failure("User with this email already exists.");
            }

            var appUser = new AppUser
            {
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                Age = registerDto.Age,
                DateofBirth = registerDto.DateofBirth,
                Email = registerDto.Email,
                Gender = registerDto.Gender,
                UserName = registerDto.UserName,
            };

            var createdUser = await _userManager.CreateAsync(appUser, registerDto.Password);

            if (!createdUser.Succeeded)
            {
                var errorMessage = string.Join(", ", createdUser.Errors.Select(e => e.Description));
                return Result<AuthResponseDto>.Failure(errorMessage);
            }

            var usersCount = await _userManager.Users.CountAsync();
            if (usersCount == 1)
            {
                await _userManager.AddToRoleAsync(appUser, "Admin");
            }
            else
            {
                await _userManager.AddToRoleAsync(appUser, "User");
            }

            var token = await jwtTokenService.CreateTokenAsync(appUser);

            var response = new AuthResponseDto
            {
                Username = appUser.UserName,
                Email = appUser.Email,
                Token = token
            };

            return Result<AuthResponseDto>.Success(response);
        }
    }
}
