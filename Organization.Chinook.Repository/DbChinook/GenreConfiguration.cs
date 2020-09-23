namespace Organization.Chinook.Repository.DbChinook
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Table;

    public partial class GenreConfiguration : IEntityTypeConfiguration<TableGenre>
    {
        /// <summary>
        /// Configure
        /// </summary>
        public void Configure(EntityTypeBuilder<TableGenre> builder)
        {
            ConfigurePartial(builder);
        }

        partial void ConfigurePartial(EntityTypeBuilder<TableGenre> builder);
    }
}
