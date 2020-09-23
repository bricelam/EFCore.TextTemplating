namespace Organization.Chinook.Repository.DbChinook
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Table;

    public partial class AlbumConfiguration : IEntityTypeConfiguration<TableAlbum>
    {
        /// <summary>
        /// Configure
        /// </summary>
        public void Configure(EntityTypeBuilder<TableAlbum> builder)
        {
            builder.HasIndex(x => x.ArtistId)
                .HasName("IFK_AlbumArtistId");

            builder.HasOne(d => d.Artist).WithMany(p => p.Album)
                .HasForeignKey(x => x.ArtistId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            ConfigurePartial(builder);
        }

        partial void ConfigurePartial(EntityTypeBuilder<TableAlbum> builder);
    }
}
