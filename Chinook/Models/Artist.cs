using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Chinook.Models
{
    public partial class Artist
    {
        public long ArtistId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Album> Albums { get; } = new HashSet<Album>();

    }
}
