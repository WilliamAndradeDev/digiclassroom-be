using DigiClassroom.ApplicationCore.Services.UtilSv.PasswordManager;
using DigiClassroom.Infrastructure.Models;
using DigiClassroom.Infrastructure.Repositories.UserRp;
using System.Threading.Tasks;

namespace DigiClassroom.ApplicationCore.Services.AutheticationSv
{
    public class AuthenticationService : IAuthenticationService
    {

        private IUserRepository _userRepository;
        private IPasswordManager _passwordManager;

        public AuthenticationService(IUserRepository userRepository, IPasswordManager passwordManager)
        {
            _userRepository = userRepository;
            _passwordManager = passwordManager;
        }

        public async Task<User> AuthenticateUser(string userName, string password)
        {
            var user = await _userRepository.FindUserByUserNameAsync(userName);
            if (user != null && _passwordManager.IsAMatch(password,user.Password))
                return user;
            else
                return null;
        }
    }
}
