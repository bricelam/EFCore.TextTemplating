namespace Organization.Chinook.Repository.DbChinook
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Table;

    public partial class CustomerConfiguration : IEntityTypeConfiguration<TableCustomer>
    {
        /// <summary>
        /// Configure
        /// </summary>
        public void Configure(EntityTypeBuilder<TableCustomer> builder)
        {
            builder.HasIndex(x => x.SupportRepId)
                .HasName("IFK_CustomerSupportRepId");

            builder.HasOne(d => d.SupportRep).WithMany(p => p.Customer)
                .HasForeignKey(x => x.SupportRepId);

            ConfigurePartial(builder);
        }

        partial void ConfigurePartial(EntityTypeBuilder<TableCustomer> builder);
    }
}
