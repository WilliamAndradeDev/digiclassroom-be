using System;
using System.Collections.Generic;

namespace DigiClassroom.Infrastructure.Models
{
    public class Library
    {
        public Guid Id { get; set; }
        public ICollection<LibraryFile> Files { get; set; }

        public Guid ClassroomId { get; set; }
        public Classroom Classroom { get; set; }
    }
}
