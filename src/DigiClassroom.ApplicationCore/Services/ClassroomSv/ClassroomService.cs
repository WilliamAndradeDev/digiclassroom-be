using DigiClassroom.Infrastructure.Models;
using DigiClassroom.Infrastructure.Repositories.ClassroomRp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigiClassroom.ApplicationCore.Services.ClassroomSv
{
    public class ClassroomService : IClassroomService
    {

        private IClassroomRepository _classroomRepository;

        public ClassroomService(IClassroomRepository classroomRepository)
        {
            _classroomRepository = classroomRepository;
        }

        public async Task<Classroom> FindClassroom(Guid id)
        => await _classroomRepository.FindClassroom(id);

        public IList<Classroom> FindClassrooms()
        => _classroomRepository.FindClassrooms();

        public Task<Classroom> Save(Classroom classroom)
        => _classroomRepository.Save(classroom);
    }
}
