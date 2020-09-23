namespace Organization.Chinook.Repository
{
    using DbChinook;
    using Microsoft.EntityFrameworkCore;
    using Table;

    /// <summary>
    /// DbChinookContext
    /// </summary>
    /// <inheritdoc />
    public partial class DbChinookContext : DbContext
    {
        /// <inheritdoc />
        protected DbChinookContext()
        {
        }

        /// <inheritdoc />
        public DbChinookContext(DbContextOptions<DbChinookContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Album(Album)
        /// </summary>
        public virtual DbSet<TableAlbum> Album { get; set; }

        /// <summary>
        /// Artist(Artist)
        /// </summary>
        public virtual DbSet<TableArtist> Artist { get; set; }

        /// <summary>
        /// Customer(Customer)
        /// </summary>
        public virtual DbSet<TableCustomer> Customer { get; set; }

        /// <summary>
        /// Employee(Employee)
        /// </summary>
        public virtual DbSet<TableEmployee> Employee { get; set; }

        /// <summary>
        /// Enum(Enum)
        /// </summary>
        public virtual DbSet<TableEnum> Enum { get; set; }

        /// <summary>
        /// Genre(Genre)
        /// </summary>
        public virtual DbSet<TableGenre> Genre { get; set; }

        /// <summary>
        /// Invoice(Invoice)
        /// </summary>
        public virtual DbSet<TableInvoice> Invoice { get; set; }

        /// <summary>
        /// InvoiceLine(InvoiceLine)
        /// </summary>
        public virtual DbSet<TableInvoiceLine> InvoiceLine { get; set; }

        /// <summary>
        /// MediaType(MediaType)
        /// </summary>
        public virtual DbSet<TableMediaType> MediaType { get; set; }

        /// <summary>
        /// Playlist(Playlist)
        /// </summary>
        public virtual DbSet<TablePlaylist> Playlist { get; set; }

        /// <summary>
        /// PlaylistTrack(PlaylistTrack)
        /// </summary>
        public virtual DbSet<TablePlaylistTrack> PlaylistTrack { get; set; }

        /// <summary>
        /// Track(Track)
        /// </summary>
        public virtual DbSet<TableTrack> Track { get; set; }

        /// <inheritdoc />
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#if DEBUG
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(local);Initial Catalog=ChinookDatabase");
#endif
            }
        }

        /// <inheritdoc />
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AlbumConfiguration());
            modelBuilder.ApplyConfiguration(new ArtistConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new EnumConfiguration());
            modelBuilder.ApplyConfiguration(new GenreConfiguration());
            modelBuilder.ApplyConfiguration(new InvoiceConfiguration());
            modelBuilder.ApplyConfiguration(new InvoiceLineConfiguration());
            modelBuilder.ApplyConfiguration(new MediaTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PlaylistConfiguration());
            modelBuilder.ApplyConfiguration(new PlaylistTrackConfiguration());
            modelBuilder.ApplyConfiguration(new TrackConfiguration());

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
