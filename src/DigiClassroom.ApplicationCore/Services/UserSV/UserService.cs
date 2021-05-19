using System;
using System.Threading.Tasks;
using DigiClassroom.ApplicationCore.Services.UtilSv.PasswordManager;
using DigiClassroom.Infrastructure.Models;
using DigiClassroom.Infrastructure.Repositories.UserRp;

namespace DigiClassroom.ApplicationCore.Services.UserSv
{
    public class UserService : IUserService
    {

        private IUserRepository _userRepository;
        private IPasswordManager _passwordManager;

        public UserService(IUserRepository userRepository, IPasswordManager passwordManager)
        {
            _userRepository = userRepository;
            _passwordManager = passwordManager;
        }

        public async Task<User> Create(User user)
        {
            user.Password = _passwordManager.GeneratePasswordHash(user.Password);
            return await _userRepository.Save(user);
        }

        public async Task<User> FindUser(Guid id)
        {
            return await _userRepository.FindUserById(id);
        }

    }
}