using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using StudentManagementSystem.Application.Interfaces;
using StudentManagementSystem.Domain.Entities;
using StudentManagementSystem.Infrastructure.Entities;

namespace StudentManagementSystem.Infrastructure.Service
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly IConfiguration config;
        private readonly UserManager<AppUser> _userManager;
        private readonly SymmetricSecurityKey _key;

        public JwtTokenService(IConfiguration config, UserManager<AppUser> userManager)
        {
            this.config = config;
            this._userManager = userManager;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:SigningKey"]));
        }

        public async Task<string> CreateTokenAsync(IUserBase user)
        {
            var appUser = user as AppUser;
            if (appUser == null)
                throw new ArgumentException("Invalid user type for token creation");

            var issuer = config["JWT:Issuer"];
            var audience = config["JWT:Audience"];

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Email, appUser.Email),
                new Claim(JwtRegisteredClaimNames.GivenName, appUser.UserName)
            };

            var roles = await _userManager.GetRolesAsync(appUser);
            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds,
                Issuer = issuer,
                Audience = audience
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
