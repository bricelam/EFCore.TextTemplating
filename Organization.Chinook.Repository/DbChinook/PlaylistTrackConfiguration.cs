namespace Organization.Chinook.Repository.DbChinook
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Table;

    public partial class PlaylistTrackConfiguration : IEntityTypeConfiguration<TablePlaylistTrack>
    {
        /// <summary>
        /// Configure
        /// </summary>
        public void Configure(EntityTypeBuilder<TablePlaylistTrack> builder)
        {
            builder.HasKey(x => new { x.PlaylistId, x.TrackId })
                .HasName("PRIMARY");

            builder.HasIndex(x => x.TrackId)
                .HasName("IFK_PlaylistTrackTrackId");

            builder.HasOne(d => d.Playlist).WithMany(p => p.PlaylistTrack)
                .HasForeignKey(x => x.PlaylistId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(d => d.Track).WithMany(p => p.PlaylistTrack)
                .HasForeignKey(x => x.TrackId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            ConfigurePartial(builder);
        }

        partial void ConfigurePartial(EntityTypeBuilder<TablePlaylistTrack> builder);
    }
}
