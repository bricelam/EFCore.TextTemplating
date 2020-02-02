using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Chinook.Models;

namespace Chinook.Data
{
    public class MediaTypeConfiguration : IEntityTypeConfiguration<MediaType>
    {
        public void Configure(EntityTypeBuilder<MediaType> builder)
        {
            builder.ToTable("MediaType");

            builder.HasIndex(x => x.MediaTypeId)
                .IsUnique();

            builder.Property(e => e.MediaTypeId)
                .ValueGeneratedNever();

            builder.Property(e => e.Name)
                .HasColumnType("NVARCHAR(120)");

        }
    }
}
