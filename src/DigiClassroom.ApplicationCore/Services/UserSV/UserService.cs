using System;
using System.Threading.Tasks;
using DigiClassroom.Infrastructure.Models;
using DigiClassroom.Infrastructure.Repositories.UserRp;

namespace DigiClassroom.ApplicationCore.Services.UserSV
{
    public class UserService : IUserService
    {

        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository=userRepository;
        }

        public async Task<User> Create(User user)
        {
            return await _userRepository.Save(user);
        }

        public async Task<User> FindUser(Guid id)
        {
            return await _userRepository.FindUserById(id);
        }
    }
}