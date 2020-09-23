namespace Organization.Chinook.Repository.DbChinook
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Table;

    public partial class PlaylistConfiguration : IEntityTypeConfiguration<TablePlaylist>
    {
        /// <summary>
        /// Configure
        /// </summary>
        public void Configure(EntityTypeBuilder<TablePlaylist> builder)
        {
            ConfigurePartial(builder);
        }

        partial void ConfigurePartial(EntityTypeBuilder<TablePlaylist> builder);
    }
}
