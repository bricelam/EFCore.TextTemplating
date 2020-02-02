using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChinookApp.Models
{
    public partial class Artist
    {
        public int ArtistId { get; set; }

        [StringLength(120)]
        public string Name { get; set; }

        public virtual ICollection<Album> Albums { get; } = new HashSet<Album>();

    }
}
