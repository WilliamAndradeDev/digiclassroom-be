using System;
using System.Threading.Tasks;
using DigiClassroom.Infrastructure.Models;

namespace DigiClassroom.Infrastructure.Repositories.UserRp
{
    public interface IUserRepository
    {
        Task<User> Save(User user);
        Task<User> FindUserById(Guid id);
        Task<User> FindUserByUsernameAsync(string username);
        Task<User> FindUserWithClassroomsByUsernameAsync(string username);
    }
}