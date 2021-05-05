using System;
using System.Collections.Generic;

namespace DigiClassroom.Infrastructure.Models
{
    public class Classroom
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LocationClassroom { get; set; }
        public List<Assingnment> Assingments { get; set; }
        public List<Announcement> Announcements { get; set; }
        public Library Library { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
