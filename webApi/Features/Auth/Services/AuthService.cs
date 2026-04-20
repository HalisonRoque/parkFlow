using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BCrypt.Net;
using Microsoft.IdentityModel.Tokens;
using webApi.Features.Auth.Dtos;
using webApi.Features.User.Repository;
using UserEntity = webApi.Features.User.Models.User;

namespace webApi.Features.Auth.Services
{
    public class AuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _config;

        public AuthService(IUserRepository userRepository, IConfiguration config)
        {
            _userRepository = userRepository;
            _config = config;
        }

        public async Task<string?> AuthenticateAsync(LoginDto login)
        {
            var user = await _userRepository.GetUserByEmailAsync(login.Email);
            if (user == null)
                return null;

            bool isValid = BCrypt.Net.BCrypt.Verify(login.Password, user.PasswordHash);
            if (!isValid)
                return null;

            return GenerateToken(user);
        }

        private string GenerateToken(UserEntity user)
        {
            var handler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config["Jwt:Key"]!);

            var credentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature
            );

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new[]
                    {
                        new Claim(ClaimTypes.Name, user.Name),
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim("id", user.Id.ToString()),
                    }
                ),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = credentials,
                Issuer = _config["Jwt:Issuer"],
                Audience = _config["Jwt:Audience"],
            };

            var token = handler.CreateToken(tokenDescriptor);
            return handler.WriteToken(token);
        }
    }
}
