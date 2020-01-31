using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EFCore.TextTemplating.Models;

namespace EFCore.TextTemplating.Data
{
    public class PlaylistTrackConfiguration : IEntityTypeConfiguration<PlaylistTrack>
    {
        public void Configure(EntityTypeBuilder<PlaylistTrack> builder)
        {
            builder.HasKey(x => new { x.PlaylistId, x.TrackId });

            builder.ToTable("PlaylistTrack");

            builder.HasOne(d => d.Playlist).WithMany(p => p.PlaylistTracks)
                .HasForeignKey(x => x.PlaylistId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(d => d.Track).WithMany(p => p.PlaylistTracks)
                .HasForeignKey(x => x.TrackId)
                .OnDelete(DeleteBehavior.ClientSetNull);

        }
    }
}
