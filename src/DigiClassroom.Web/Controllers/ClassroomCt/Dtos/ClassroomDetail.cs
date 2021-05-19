using DigiClassroom.Infrastructure.Models;
using System;

namespace DigiClassroom.Web.Controllers.ClassroomCt.Dtos
{
    public class ClassroomDetail
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LocationClassroom { get; set; }

        public ClassroomDetail(Classroom classroom)
        {
            this.Id = classroom.Id;
            this.Name = classroom.Name;
            this.Description = classroom.Description;
            this.LocationClassroom = classroom.LocationClassroom;
        }

    }
}
