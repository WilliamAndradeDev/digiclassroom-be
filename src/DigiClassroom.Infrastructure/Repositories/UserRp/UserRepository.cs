using System;
using System.Linq;
using System.Threading.Tasks;
using DigiClassroom.Infrastructure.DBConfig;
using DigiClassroom.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace DigiClassroom.Infrastructure.Repositories.UserRp
{
    public class UserRepository : IUserRepository
    {

        private DigiClassroomContext _digiClassroomContext;

        public UserRepository(DigiClassroomContext digiClassroomContext)
        {
            _digiClassroomContext = digiClassroomContext;
        }

        public async Task<User> FindUserById(Guid id)
        => await _digiClassroomContext.Users
                            .Where(u=>u.Id.Equals(id))
                                    .FirstOrDefaultAsync();

        public async Task<User> FindUserByUsernameAndPasswordAsync(string username, string password)
        => await _digiClassroomContext.Users
                           .Where(u => u.Username.Equals(username) &&
                                       u.Password.Equals(password)).FirstOrDefaultAsync();

        public async Task<User> Save(User user)
        {
            _digiClassroomContext.Users.Add(user);
            await _digiClassroomContext.SaveChangesAsync();
            return user;
        }
    }
}