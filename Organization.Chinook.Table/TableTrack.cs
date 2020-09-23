namespace Organization.Chinook.Table
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Track")]
    public partial class TableTrack
    {
        [Key]
        public int TrackId { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        public int? AlbumId { get; set; }

        public int MediaTypeId { get; set; }

        public int? GenreId { get; set; }

        [StringLength(220)]
        public string Composer { get; set; }

        public int Milliseconds { get; set; }

        public int? Bytes { get; set; }

        [Column(TypeName = "numeric(10, 2)")]
        public decimal UnitPrice { get; set; }

        public virtual TableAlbum Album { get; set; }

        public virtual TableGenre Genre { get; set; }

        public virtual ICollection<TableInvoiceLine> InvoiceLine { get; } = new HashSet<TableInvoiceLine>();

        public virtual TableMediaType MediaType { get; set; }

        public virtual ICollection<TablePlaylistTrack> PlaylistTrack { get; } = new HashSet<TablePlaylistTrack>();

    }
}
