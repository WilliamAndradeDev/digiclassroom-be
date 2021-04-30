using System;
using System.Collections;
using System.Collections.Generic;

namespace DigiClassroom.Infrastructure.Models
{
    public class LibraryFile
    {
        public Guid Id { get; set; }
        public string LocatedAt { get; set; }
        public ICollection<Library> Libraries { get; set; }
    }
}
