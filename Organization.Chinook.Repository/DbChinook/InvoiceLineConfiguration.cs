namespace Organization.Chinook.Repository.DbChinook
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Table;

    public partial class InvoiceLineConfiguration : IEntityTypeConfiguration<TableInvoiceLine>
    {
        /// <summary>
        /// Configure
        /// </summary>
        public void Configure(EntityTypeBuilder<TableInvoiceLine> builder)
        {
            builder.HasIndex(x => x.InvoiceId)
                .HasName("IFK_InvoiceLineInvoiceId");

            builder.HasIndex(x => x.TrackId)
                .HasName("IFK_InvoiceLineTrackId");

            builder.HasOne(d => d.Invoice).WithMany(p => p.InvoiceLine)
                .HasForeignKey(x => x.InvoiceId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(d => d.Track).WithMany(p => p.InvoiceLine)
                .HasForeignKey(x => x.TrackId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            ConfigurePartial(builder);
        }

        partial void ConfigurePartial(EntityTypeBuilder<TableInvoiceLine> builder);
    }
}
