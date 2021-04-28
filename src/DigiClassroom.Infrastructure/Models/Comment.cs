using System;

namespace DigiClassroom.Infrastructure.Models
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string Content { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
