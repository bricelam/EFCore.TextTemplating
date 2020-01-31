using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EFCore.TextTemplating.Models;

namespace EFCore.TextTemplating.Data
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer");

            builder.Property(e => e.CustomerId)
                .ValueGeneratedNever();

            builder.Property(e => e.Address)
                .HasColumnType("NVARCHAR(70)");

            builder.Property(e => e.City)
                .HasColumnType("NVARCHAR(40)");

            builder.Property(e => e.Company)
                .HasColumnType("NVARCHAR(80)");

            builder.Property(e => e.Country)
                .HasColumnType("NVARCHAR(40)");

            builder.Property(e => e.Email)
                .HasColumnType("NVARCHAR(60)");

            builder.Property(e => e.Fax)
                .HasColumnType("NVARCHAR(24)");

            builder.Property(e => e.FirstName)
                .HasColumnType("NVARCHAR(40)");

            builder.Property(e => e.LastName)
                .HasColumnType("NVARCHAR(20)");

            builder.Property(e => e.Phone)
                .HasColumnType("NVARCHAR(24)");

            builder.Property(e => e.PostalCode)
                .HasColumnType("NVARCHAR(10)");

            builder.Property(e => e.State)
                .HasColumnType("NVARCHAR(40)");

            builder.HasOne(d => d.SupportRep).WithMany(p => p.Customers)
                .HasForeignKey(x => x.SupportRepId);

        }
    }
}
