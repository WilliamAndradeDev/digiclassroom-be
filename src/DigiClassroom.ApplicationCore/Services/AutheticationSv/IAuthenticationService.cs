using DigiClassroom.Infrastructure.Models;
using System.Threading.Tasks;

namespace DigiClassroom.ApplicationCore.Services.AutheticationSv
{
    public interface IAuthenticationService
    {
        Task<User> AuthenticateUser(string userName, string password);
    }
}
