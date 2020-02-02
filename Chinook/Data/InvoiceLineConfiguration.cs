using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Chinook.Models;

namespace Chinook.Data
{
    public class InvoiceLineConfiguration : IEntityTypeConfiguration<InvoiceLine>
    {
        public void Configure(EntityTypeBuilder<InvoiceLine> builder)
        {
            builder.ToTable("InvoiceLine");

            builder.HasIndex(x => x.InvoiceLineId)
                .IsUnique();

            builder.Property(e => e.InvoiceLineId)
                .ValueGeneratedNever();

            builder.Property(e => e.UnitPrice)
                .HasColumnType("NUMERIC(10,2)");

            builder.HasOne(d => d.Invoice).WithMany(p => p.InvoiceLines)
                .HasForeignKey(x => x.InvoiceId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(d => d.Track).WithMany(p => p.InvoiceLines)
                .HasForeignKey(x => x.TrackId)
                .OnDelete(DeleteBehavior.ClientSetNull);

        }
    }
}
