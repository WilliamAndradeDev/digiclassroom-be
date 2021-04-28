using System;
using System.Collections.Generic;

namespace DigiClassroom.Infrastructure.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string name { get; set; }
        public IList<Classroom> Classroom { get; set; }
    }
}
