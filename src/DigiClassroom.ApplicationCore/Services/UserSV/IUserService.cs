using System;
using System.Threading.Tasks;
using DigiClassroom.Infrastructure.Models;

namespace DigiClassroom.ApplicationCore.Services.UserSV
{
    public interface IUserService
    {
        Task<User> Create(User user);
        Task<User> FindUser(Guid id);
    }
}