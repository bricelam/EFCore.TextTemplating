using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFCore.TextTemplating.Models
{
    public partial class Track
    {
        public long TrackId { get; set; }

		[Required]
        public string Name { get; set; }

        public long? AlbumId { get; set; }

        public long MediaTypeId { get; set; }

        public long? GenreId { get; set; }

        public string Composer { get; set; }

        public long Milliseconds { get; set; }

        public long? Bytes { get; set; }

		[Required]
        public string UnitPrice { get; set; }

		public virtual Album Album { get; set; }

		public virtual Genre Genre { get; set; }

		public virtual ICollection<InvoiceLine> InvoiceLine { get; } = new HashSet<InvoiceLine>();

		public virtual MediaType MediaType { get; set; }

		public virtual ICollection<PlaylistTrack> PlaylistTrack { get; } = new HashSet<PlaylistTrack>();

    }
}
