using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ChinookApp.Models;

namespace ChinookApp.Data
{
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.ToTable("Invoice");

            builder.Property(e => e.InvoiceDate)
                .HasColumnType("datetime");

            builder.Property(e => e.Total)
                .HasColumnType("numeric(10, 2)");

            builder.HasOne(d => d.Customer).WithMany(p => p.Invoices)
                .HasForeignKey(x => x.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull);

        }
    }
}
