using DigiClassroom.Infrastructure.DBConfig.EntityConfigurations;
using DigiClassroom.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace DigiClassroom.Infrastructure.DBConfig
{
    public class DigiClassroomContext : DbContext
    {
        public DbSet<Assingnment> Assingments { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Library> Libraries { get; set; }
        public DbSet<User> Users { get; set; }

        public DigiClassroomContext(DbContextOptions<DigiClassroomContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AnswerEC());
            builder.ApplyConfiguration(new AssingnmentEC());
            builder.ApplyConfiguration(new AnnouncementEC());
            builder.ApplyConfiguration(new LibraryFileEC());
            builder.ApplyConfiguration(new LibraryEC());
            builder.ApplyConfiguration(new CommentEC());
            builder.ApplyConfiguration(new ClassroomEC());
            builder.ApplyConfiguration(new UserEC());
        }
    }
}
