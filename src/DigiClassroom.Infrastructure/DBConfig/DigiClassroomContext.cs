using DigiClassroom.Infrastructure.DBConfig.EntityConfigurations;
using DigiClassroom.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace DigiClassroom.Infrastructure.DBConfig
{
    public class DigiClassroomContext : DbContext
    {
        public DbSet<Assingment> Assingments { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Library> Libraries { get; set; }

        public DigiClassroomContext(DbContextOptions<DigiClassroomContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AssingmentEntityConfiguration());
            builder.ApplyConfiguration(new AnnouncementEntityConfiguration());
            builder.ApplyConfiguration(new LibraryFileEntityConfiguration());
            builder.ApplyConfiguration(new LibraryEntityConfiguration());
            builder.ApplyConfiguration(new CommentEntityConfiguration());
            builder.ApplyConfiguration(new ClassroomEntityConfiguration());
        }
    }
}
