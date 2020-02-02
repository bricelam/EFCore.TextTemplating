using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ChinookApp.Models;

namespace ChinookApp.Data
{
    public class TrackConfiguration : IEntityTypeConfiguration<Track>
    {
        public void Configure(EntityTypeBuilder<Track> builder)
        {
            builder.ToTable("Track");

            builder.Property(e => e.UnitPrice)
                .HasColumnType("numeric(10, 2)");

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
