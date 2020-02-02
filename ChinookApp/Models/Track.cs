using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChinookApp.Models
{
    public partial class Track
    {
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

        public decimal UnitPrice { get; set; }

        public virtual Album Album { get; set; }

        public virtual Genre Genre { get; set; }

        public virtual ICollection<InvoiceLine> InvoiceLines { get; } = new HashSet<InvoiceLine>();

        public virtual MediaType MediaType { get; set; }

        public virtual ICollection<PlaylistTrack> PlaylistTracks { get; } = new HashSet<PlaylistTrack>();

    }
}
