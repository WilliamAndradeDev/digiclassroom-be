using System;
using System.Collections.Generic;

namespace DigiClassroom.Infrastructure.Models
{
    public class Assingnment
    {
        public Guid Id { get; set; }
        public DateTime Creation { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime Updated { get; set; }
        public string Description { get; set; }
        public double Pontuation { get; set; }
        public List<Answer> Answers { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
