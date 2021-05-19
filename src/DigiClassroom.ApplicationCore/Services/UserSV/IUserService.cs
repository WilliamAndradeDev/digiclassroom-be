using System;
using System.Threading.Tasks;
using DigiClassroom.Infrastructure.Models;

namespace DigiClassroom.ApplicationCore.Services.UserSv
{
    public interface IUserService
    {
        Task<User> Create(User user);
        Task<User> FindUser(Guid id);
    }
}