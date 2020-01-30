using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFCore.TextTemplating.Models
{
    public partial class Playlist
    {
        public long PlaylistId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<PlaylistTrack> PlaylistTrack { get; } = new HashSet<PlaylistTrack>();

    }
}
