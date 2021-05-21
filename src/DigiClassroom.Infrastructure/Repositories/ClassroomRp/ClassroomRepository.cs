using DigiClassroom.Infrastructure.DBConfig;
using DigiClassroom.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DigiClassroom.Infrastructure.Repositories.ClassroomRp
{
    public class ClassroomRepository : IClassroomRepository
    {

        private DigiClassroomContext _dbContext;

        public ClassroomRepository(DigiClassroomContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Classroom> FindClassroom(Guid id)
        => await _dbContext.Classrooms.Where(c => c.Id.Equals(id)).FirstOrDefaultAsync();

        public async Task<Classroom> Save(Classroom classroom)
        {
            _dbContext.Classrooms.Add(classroom);
            await _dbContext.SaveChangesAsync();
            return classroom;
        }

    }
}
