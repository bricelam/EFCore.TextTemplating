namespace Organization.Chinook.Repository.DbChinook
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Table;

    public partial class EnumConfiguration : IEntityTypeConfiguration<TableEnum>
    {
        /// <summary>
        /// Configure
        /// </summary>
        public void Configure(EntityTypeBuilder<TableEnum> builder)
        {
            builder.Property(e => e.Id)
                .ValueGeneratedNever();

            ConfigurePartial(builder);
        }

        partial void ConfigurePartial(EntityTypeBuilder<TableEnum> builder);
    }
}
