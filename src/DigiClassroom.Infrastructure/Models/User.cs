using System;
using System.Collections.Generic;

namespace DigiClassroom.Infrastructure.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public ICollection<Classroom> Classrooms { get; set; }
    }
}
