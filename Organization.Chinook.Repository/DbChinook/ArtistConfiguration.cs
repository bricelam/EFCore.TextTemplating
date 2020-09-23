namespace Organization.Chinook.Repository.DbChinook
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Table;

    public partial class ArtistConfiguration : IEntityTypeConfiguration<TableArtist>
    {
        /// <summary>
        /// Configure
        /// </summary>
        public void Configure(EntityTypeBuilder<TableArtist> builder)
        {
            ConfigurePartial(builder);
        }

        partial void ConfigurePartial(EntityTypeBuilder<TableArtist> builder);
    }
}
