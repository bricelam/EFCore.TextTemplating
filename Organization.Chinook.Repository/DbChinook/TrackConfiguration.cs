namespace Organization.Chinook.Repository.DbChinook
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Table;

    public partial class TrackConfiguration : IEntityTypeConfiguration<TableTrack>
    {
        /// <summary>
        /// Configure
        /// </summary>
        public void Configure(EntityTypeBuilder<TableTrack> builder)
        {
            builder.HasIndex(x => x.AlbumId)
                .HasName("IFK_TrackAlbumId");

            builder.HasIndex(x => x.GenreId)
                .HasName("IFK_TrackGenreId");

            builder.HasIndex(x => x.MediaTypeId)
                .HasName("IFK_TrackMediaTypeId");

            builder.HasOne(d => d.Album).WithMany(p => p.Track)
                .HasForeignKey(x => x.AlbumId);

            builder.HasOne(d => d.Genre).WithMany(p => p.Track)
                .HasForeignKey(x => x.GenreId);

            builder.HasOne(d => d.MediaType).WithMany(p => p.Track)
                .HasForeignKey(x => x.MediaTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            ConfigurePartial(builder);
        }

        partial void ConfigurePartial(EntityTypeBuilder<TableTrack> builder);
    }
}
