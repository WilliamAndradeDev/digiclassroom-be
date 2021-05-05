using DigiClassroom.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigiClassroom.Infrastructure.DBConfig.EntityConfigurations
{
    public class UserEC : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u=>u.Id);
            builder.Property(u=>u.Id).ValueGeneratedOnAdd();

            builder.Property(u => u.Username).HasMaxLength(256).IsRequired();
            builder.HasIndex(u => u.Username).HasDatabaseName("UserNameIndex").IsUnique();
            
            builder.Property(u=>u.Password).HasMaxLength(256).IsRequired();

            builder.Property(u=>u.Role).HasMaxLength(120).IsRequired();

            builder.HasMany(u=>u.Classrooms).WithMany(c=>c.Users).UsingEntity(uc=>uc.ToTable("UserClassrooms"));
        }
    }
}