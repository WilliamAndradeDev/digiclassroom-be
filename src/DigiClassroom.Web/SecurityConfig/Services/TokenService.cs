using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using DigiClassroom.Infrastructure.Models;
using Microsoft.IdentityModel.Tokens;

namespace DigiClassroom.Web.SecurityConfig.Services
{
    public class TokenService : ITokenService
    {

        private JwtSecurityTokenHandler _jwtSecurityTokenHandler;

        public TokenService(JwtSecurityTokenHandler jwtSecurityTokenHandler)
        {
            _jwtSecurityTokenHandler = jwtSecurityTokenHandler;
        }

        public string GenerateToken(User user)
        {
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(JwtConfig.Secret),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };
            var token = _jwtSecurityTokenHandler.CreateToken(tokenDescriptor);
            return _jwtSecurityTokenHandler.WriteToken(token);
        }

        public string GetUserName(string token)
        {
            var jsonToken = _jwtSecurityTokenHandler.ReadJwtToken(token);
            return jsonToken.Claims.First(claim => claim.Type == ClaimTypes.Name).Value;
        }
    }
}