using DigiClassroom.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigiClassroom.Infrastructure.DBConfig.EntityConfigurations
{
    public class AssingmentEntityConfiguration : IEntityTypeConfiguration<Assingment>
    {
        public void Configure(EntityTypeBuilder<Assingment> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();

            builder.Property(a => a.Creation).HasColumnType("date");
            builder.Property(a => a.Creation).ValueGeneratedOnAdd();

            builder.Property(a => a.Deadline).IsRequired();

            builder.Property(a => a.Updated).HasColumnType("date");
            builder.Property(a => a.Updated).ValueGeneratedOnUpdate();//testar o update

            builder.Property(a => a.Description).IsRequired();

            builder.Property(a => a.Pontuation).HasPrecision(4, 2);

            builder.HasMany(a => a.Comments).WithOne();

        }
    }
}
