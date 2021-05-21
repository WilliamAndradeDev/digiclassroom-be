using DigiClassroom.Infrastructure.Models;

namespace DigiClassroom.Web.SecurityConfig.Services
{
    public interface ITokenService
    {
        string GenerateToken(User user);
        string GetUserName(string tokenRaw);
    }
}