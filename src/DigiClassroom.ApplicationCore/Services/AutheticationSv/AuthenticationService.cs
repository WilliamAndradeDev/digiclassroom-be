using DigiClassroom.ApplicationCore.Services.UserSv;
using DigiClassroom.ApplicationCore.Services.UtilSv.PasswordManager;
using DigiClassroom.Infrastructure.Models;
using System.Threading.Tasks;

namespace DigiClassroom.ApplicationCore.Services.AutheticationSv
{
    public class AuthenticationService : IAuthenticationService
    {

        private IUserService _userService;
        private IPasswordManager _passwordManager;

        public AuthenticationService(IUserService userRepository, IPasswordManager passwordManager)
        {
            _userService = userRepository;
            _passwordManager = passwordManager;
        }

        public async Task<User> AuthenticateUser(string userName, string password)
        {
            var user = await _userService.FindUserByUsernameAsync(userName);
            if (user != null && _passwordManager.IsAMatch(password, user.Password))
                return user;
            else
                return null;
        }
    }
}
