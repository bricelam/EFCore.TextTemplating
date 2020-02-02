using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Chinook.Models;

namespace Chinook.Data
{
    public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder.ToTable("Artist");

            builder.HasIndex(x => x.ArtistId)
                .IsUnique();

            builder.Property(e => e.ArtistId)
                .ValueGeneratedNever();

            builder.Property(e => e.Name)
                .HasColumnType("NVARCHAR(120)");

        }
    }
}
