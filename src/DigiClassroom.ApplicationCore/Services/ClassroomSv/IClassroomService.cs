using DigiClassroom.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigiClassroom.ApplicationCore.Services.ClassroomSv
{
    public interface IClassroomService
    {
        Task<Classroom> Save(Classroom classroom);
        Task<Classroom> FindClassroom(Guid id);
        IList<Classroom> FindClassrooms();
    }
}
