using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFCore.TextTemplating.Models
{
    public partial class Album
    {
        public long AlbumId { get; set; }

        [Required]
        public string Title { get; set; }

        public long ArtistId { get; set; }

        public virtual Artist Artist { get; set; }

        public virtual ICollection<Track> Track { get; } = new HashSet<Track>();

    }
}
