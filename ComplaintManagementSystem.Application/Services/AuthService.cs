using ComplaintManagementSystem.Application.Common;
using ComplaintManagementSystem.Application.DTOs;
using ComplaintManagementSystem.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ComplaintManagementSystem.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _config;
        private readonly IUserRepository _userRepo;
        public AuthService(IConfiguration config, IUserRepository userRepo)
        {
            _config = config;
            _userRepo = userRepo;
        }

        public string Login(LoginDto dto)
        {
            var user = _userRepo.GetByEmail(dto.Email);

            if (user == null)
                throw new Exception("Invalid credentials");

            var hashed = PasswordHasher.Hash(dto.Password);

            if (user.PasswordHash != hashed)
                throw new Exception("Invalid credentials");

            // TEMP user (we’ll use DB next)
            if (dto.Email != "admin@test.com" || dto.Password != "1234")
                throw new Exception("Invalid credentials");

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                 new Claim(ClaimTypes.Email, user.Email),
                 new Claim(ClaimTypes.Role, user.Role)
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_config["Jwt:Key"])
            );

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );

            var refreshToken = TokenGenerator.GenerateRefreshToken();

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

}
