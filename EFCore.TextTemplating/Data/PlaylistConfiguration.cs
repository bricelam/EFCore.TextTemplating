using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EFCore.TextTemplating.Models;

namespace EFCore.TextTemplating.Data
{
    public class PlaylistConfiguration : IEntityTypeConfiguration<Playlist>
    {
        public void Configure(EntityTypeBuilder<Playlist> builder)
        {
            builder.ToTable("Playlist");

            builder.Property(e => e.PlaylistId)
                .ValueGeneratedNever();

            builder.Property(e => e.Name)
                .HasColumnType("NVARCHAR(120)");

        }
    }
}
