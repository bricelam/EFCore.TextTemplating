using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Chinook.Models;

namespace Chinook.Data
{
    public class PlaylistConfiguration : IEntityTypeConfiguration<Playlist>
    {
        public void Configure(EntityTypeBuilder<Playlist> builder)
        {
            builder.ToTable("Playlist");

            builder.HasIndex(x => x.PlaylistId)
                .IsUnique();

            builder.Property(e => e.PlaylistId)
                .ValueGeneratedNever();

            builder.Property(e => e.Name)
                .HasColumnType("NVARCHAR(120)");

        }
    }
}
