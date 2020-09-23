namespace Organization.Chinook.Repository.DbChinook
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Table;

    public partial class EmployeeConfiguration : IEntityTypeConfiguration<TableEmployee>
    {
        /// <summary>
        /// Configure
        /// </summary>
        public void Configure(EntityTypeBuilder<TableEmployee> builder)
        {
            builder.HasIndex(x => x.ReportsTo)
                .HasName("IFK_EmployeeReportsTo");

            builder.HasOne(d => d.ReportsToNavigation).WithMany(p => p.InverseReportsToNavigation)
                .HasForeignKey(x => x.ReportsTo);

            ConfigurePartial(builder);
        }

        partial void ConfigurePartial(EntityTypeBuilder<TableEmployee> builder);
    }
}
