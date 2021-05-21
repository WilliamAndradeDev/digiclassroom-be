using DigiClassroom.Infrastructure.DBConfig;
using DigiClassroom.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

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
                            .Where(u => u.Id.Equals(id))
                                    .FirstOrDefaultAsync();

        public async Task<User> FindUserByUsernameAsync(string username)
        => await _digiClassroomContext.Users
                                .Where(u => u.Username.Equals(username))
                                                            .FirstOrDefaultAsync();

        public async Task<User> FindUserWithClassroomsByUsernameAsync(string username)
        => await _digiClassroomContext.Users
                                .Where(u => u.Username.Equals(username))
                                            .Include(u => u.Classrooms)
                                                            .FirstOrDefaultAsync();

        public async Task<User> Save(User user)
        {
            _digiClassroomContext.Users.Add(user);
            await _digiClassroomContext.SaveChangesAsync();
            return user;
        }
    }
}