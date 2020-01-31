using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EFCore.TextTemplating.Models;

namespace EFCore.TextTemplating.Data
{
    public class TrackConfiguration : IEntityTypeConfiguration<Track>
    {
        public void Configure(EntityTypeBuilder<Track> builder)
        {
            builder.ToTable("Track");

            builder.Property(e => e.TrackId)
                .ValueGeneratedNever();

            builder.Property(e => e.Composer)
                .HasColumnType("NVARCHAR(220)");

            builder.Property(e => e.Name)
                .HasColumnType("NVARCHAR(200)");

            builder.Property(e => e.UnitPrice)
                .HasColumnType("NUMERIC(10,2)");

            builder.HasOne(d => d.Album).WithMany(p => p.Tracks)
                .HasForeignKey(x => x.AlbumId);

            builder.HasOne(d => d.Genre).WithMany(p => p.Tracks)
                .HasForeignKey(x => x.GenreId);

            builder.HasOne(d => d.MediaType).WithMany(p => p.Tracks)
                .HasForeignKey(x => x.MediaTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

        }
    }
}
