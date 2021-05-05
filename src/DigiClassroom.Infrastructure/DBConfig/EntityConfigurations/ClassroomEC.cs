using DigiClassroom.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigiClassroom.Infrastructure.DBConfig.EntityConfigurations
{
    public class ClassroomEC : IEntityTypeConfiguration<Classroom>
    {
        public void Configure(EntityTypeBuilder<Classroom> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.Property(c => c.Name).IsRequired();
            builder.Property(c => c.Name).HasMaxLength(50);

            builder.Property(c => c.Description).HasMaxLength(120).IsRequired();

            builder.Property(c => c.LocationClassroom).IsRequired();
            builder.Property(c => c.LocationClassroom).HasMaxLength(120);

            builder.HasMany(c => c.Assingments).WithOne().IsRequired();

            builder.HasMany(c => c.Announcements).WithOne().IsRequired();

            builder.HasOne(c => c.Library).WithOne(l => l.Classroom)
                .HasForeignKey<Library>(l=>l.Id);
        }
    }
}
