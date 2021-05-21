using DigiClassroom.Infrastructure.Models;
using System;
using System.Threading.Tasks;

namespace DigiClassroom.Infrastructure.Repositories.ClassroomRp
{
    public interface IClassroomRepository
    {
        Task<Classroom> FindClassroom(Guid id);
        Task<Classroom> Save(Classroom classroom);
    }
}
