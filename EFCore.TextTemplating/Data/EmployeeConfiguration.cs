using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EFCore.TextTemplating.Models;

namespace EFCore.TextTemplating.Data
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee");

            builder.HasIndex(x => x.EmployeeId)
                .IsUnique();

            builder.Property(e => e.EmployeeId)
                .ValueGeneratedNever();

            builder.Property(e => e.Address)
                .HasColumnType("NVARCHAR(70)");

            builder.Property(e => e.BirthDate)
                .HasColumnType("DATETIME");

            builder.Property(e => e.City)
                .HasColumnType("NVARCHAR(40)");

            builder.Property(e => e.Country)
                .HasColumnType("NVARCHAR(40)");

            builder.Property(e => e.Email)
                .HasColumnType("NVARCHAR(60)");

            builder.Property(e => e.Fax)
                .HasColumnType("NVARCHAR(24)");

            builder.Property(e => e.FirstName)
                .HasColumnType("NVARCHAR(20)");

            builder.Property(e => e.HireDate)
                .HasColumnType("DATETIME");

            builder.Property(e => e.LastName)
                .HasColumnType("NVARCHAR(20)");

            builder.Property(e => e.Phone)
                .HasColumnType("NVARCHAR(24)");

            builder.Property(e => e.PostalCode)
                .HasColumnType("NVARCHAR(10)");

            builder.Property(e => e.State)
                .HasColumnType("NVARCHAR(40)");

            builder.Property(e => e.Title)
                .HasColumnType("NVARCHAR(30)");

            builder.HasOne(d => d.ReportsToNavigation).WithMany(p => p.InverseReportsToNavigation)
                .HasForeignKey(x => x.ReportsTo);

        }
    }
}
