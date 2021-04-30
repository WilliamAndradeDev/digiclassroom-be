using DigiClassroom.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigiClassroom.Infrastructure.DBConfig.EntityConfigurations
{
    public class LibraryFileEntityConfiguration : IEntityTypeConfiguration<LibraryFile>
    {
        public void Configure(EntityTypeBuilder<LibraryFile> builder)
        {
            builder.HasKey(lf => lf.Id);
            builder.Property(lf => lf.Id).ValueGeneratedOnAdd();

            builder.Property(lf => lf.LocatedAt).IsRequired();
        }
    }
}
