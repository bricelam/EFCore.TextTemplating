using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Chinook.Models;

namespace Chinook.Data
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable("Genre");

            builder.HasIndex(x => x.GenreId)
                .IsUnique();

            builder.Property(e => e.GenreId)
                .ValueGeneratedNever();

            builder.Property(e => e.Name)
                .HasColumnType("NVARCHAR(120)");

        }
    }
}
