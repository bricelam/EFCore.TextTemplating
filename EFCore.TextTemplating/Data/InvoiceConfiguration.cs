using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EFCore.TextTemplating.Models;

namespace EFCore.TextTemplating.Data
{
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.ToTable("Invoice");

            builder.Property(e => e.InvoiceId)
                .ValueGeneratedNever();

            builder.Property(e => e.BillingAddress)
                .HasColumnType("NVARCHAR(70)");

            builder.Property(e => e.BillingCity)
                .HasColumnType("NVARCHAR(40)");

            builder.Property(e => e.BillingCountry)
                .HasColumnType("NVARCHAR(40)");

            builder.Property(e => e.BillingPostalCode)
                .HasColumnType("NVARCHAR(10)");

            builder.Property(e => e.BillingState)
                .HasColumnType("NVARCHAR(40)");

            builder.Property(e => e.InvoiceDate)
                .HasColumnType("DATETIME");

            builder.Property(e => e.Total)
                .HasColumnType("NUMERIC(10,2)");

            builder.HasOne(d => d.Customer).WithMany(p => p.Invoices)
                .HasForeignKey(x => x.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull);

        }
    }
}
