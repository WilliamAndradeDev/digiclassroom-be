using DigiClassroom.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigiClassroom.Infrastructure.DBConfig.EntityConfigurations
{
    public class LibraryEntityConfiguration : IEntityTypeConfiguration<Library>
    {
        public void Configure(EntityTypeBuilder<Library> builder)
        {
            builder.HasKey(l => l.Id);
            builder.Property(l => l.Id).ValueGeneratedOnAdd();

            builder.HasMany(l => l.Files).WithMany(lf=>lf.Libraries).UsingEntity(lbf=>lbf.ToTable("LibraryLibraryFiles"));

        }
    }
}
