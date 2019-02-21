using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sample.Models
{
    public partial class Artist
    {
        public long ArtistId { get; set; }

        public string Name { get; set; }

		public virtual ICollection<Album> Album { get; } = new HashSet<Album>();

    }
}
