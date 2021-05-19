using System;
using System.Threading.Tasks;
using DigiClassroom.Infrastructure.Models;

namespace DigiClassroom.Infrastructure.Repositories.UserRp
{
    public interface IUserRepository
    {
        Task<User> Save(User user);
        Task<User> FindUserByUsernameAndPasswordAsync(string username,string password);
        Task<User> FindUserById(Guid id);
        Task<User> FindUserByUserNameAsync(string name);
    }
}