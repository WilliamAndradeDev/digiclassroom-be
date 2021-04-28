using System;
using System.Collections.Generic;

namespace DigiClassroom.Infrastructure.Models
{
    public class Assingment
    {
        public Guid Id { get; set; }
        public DateTime Creation { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime Updated { get; set; }
        public string Description { get; set; }
        public double Pontuation { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
