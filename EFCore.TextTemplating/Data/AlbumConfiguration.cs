using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EFCore.TextTemplating.Models;

namespace EFCore.TextTemplating.Data
{
    public class AlbumConfiguration : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.ToTable("Album");

            builder.Property(e => e.AlbumId)
                .ValueGeneratedNever();

            builder.Property(e => e.Title)
                .HasColumnType("NVARCHAR(160)");

            builder.HasOne(d => d.Artist).WithMany(p => p.Albums)
                .HasForeignKey(x => x.ArtistId)
                .OnDelete(DeleteBehavior.ClientSetNull);

        }
    }
}
