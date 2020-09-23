namespace Organization.Chinook.Repository.DbChinook
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Table;

    public partial class MediaTypeConfiguration : IEntityTypeConfiguration<TableMediaType>
    {
        /// <summary>
        /// Configure
        /// </summary>
        public void Configure(EntityTypeBuilder<TableMediaType> builder)
        {
            ConfigurePartial(builder);
        }

        partial void ConfigurePartial(EntityTypeBuilder<TableMediaType> builder);
    }
}
