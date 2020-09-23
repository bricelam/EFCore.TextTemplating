namespace Organization.Chinook.Repository.DbChinook
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Table;

    public partial class InvoiceConfiguration : IEntityTypeConfiguration<TableInvoice>
    {
        /// <summary>
        /// Configure
        /// </summary>
        public void Configure(EntityTypeBuilder<TableInvoice> builder)
        {
            builder.HasIndex(x => x.CustomerId)
                .HasName("IFK_InvoiceCustomerId");

            builder.HasOne(d => d.Customer).WithMany(p => p.Invoice)
                .HasForeignKey(x => x.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            ConfigurePartial(builder);
        }

        partial void ConfigurePartial(EntityTypeBuilder<TableInvoice> builder);
    }
}
