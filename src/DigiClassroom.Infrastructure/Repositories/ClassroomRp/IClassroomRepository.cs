using DigiClassroom.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigiClassroom.Infrastructure.Repositories.ClassroomRp
{
    public interface IClassroomRepository
    {
        IList<Classroom> FindClassrooms();
        Task<Classroom> FindClassroom(Guid id);
        Task<Classroom> Save(Classroom classroom);
    }
}
