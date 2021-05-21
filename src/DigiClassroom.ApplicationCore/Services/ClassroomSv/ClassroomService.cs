using DigiClassroom.ApplicationCore.Services.UserSv;
using DigiClassroom.Infrastructure.Models;
using DigiClassroom.Infrastructure.Repositories.ClassroomRp;
using DigiClassroom.Infrastructure.Repositories.UserRp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigiClassroom.ApplicationCore.Services.ClassroomSv
{
    public class ClassroomService : IClassroomService
    {

        private IClassroomRepository _classroomRepository;
        private IUserService _userService;

        public ClassroomService(IClassroomRepository classroomRepository, IUserService userService)
        {
            _classroomRepository = classroomRepository;
            _userService = userService;
        }

        public async Task<Classroom> FindClassroom(Guid id)
        => await _classroomRepository.FindClassroom(id);

        public async Task<Classroom> Save(Classroom classroom, string username)
        {
            var user = await _userService.FindUserByUsernameAsync(username);
            classroom.Users = new List<User> { user };
            return await _classroomRepository.Save(classroom);
        }
    }
}
