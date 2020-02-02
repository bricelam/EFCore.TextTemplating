using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Chinook.Models;

namespace Chinook.Data
{
    public class PlaylistTrackConfiguration : IEntityTypeConfiguration<PlaylistTrack>
    {
        public void Configure(EntityTypeBuilder<PlaylistTrack> builder)
        {
            builder.HasKey(x => new { x.PlaylistId, x.TrackId });

            builder.ToTable("PlaylistTrack");

            builder.HasIndex(x => new { x.PlaylistId, x.TrackId })
                .IsUnique();

            builder.HasOne(d => d.Playlist).WithMany(p => p.PlaylistTracks)
                .HasForeignKey(x => x.PlaylistId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(d => d.Track).WithMany(p => p.PlaylistTracks)
                .HasForeignKey(x => x.TrackId)
                .OnDelete(DeleteBehavior.ClientSetNull);

        }
    }
}
