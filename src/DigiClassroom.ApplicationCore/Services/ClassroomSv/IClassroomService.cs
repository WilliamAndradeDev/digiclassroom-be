using DigiClassroom.Infrastructure.Models;
using System;
using System.Threading.Tasks;

namespace DigiClassroom.ApplicationCore.Services.ClassroomSv
{
    public interface IClassroomService
    {
        Task<Classroom> Save(Classroom classroom, string username);
        Task<Classroom> FindClassroom(Guid id);
    }
}
