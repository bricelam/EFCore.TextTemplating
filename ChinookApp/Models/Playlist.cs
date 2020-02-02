using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChinookApp.Models
{
    public partial class Playlist
    {
        public int PlaylistId { get; set; }

        [StringLength(120)]
        public string Name { get; set; }

        public virtual ICollection<PlaylistTrack> PlaylistTracks { get; } = new HashSet<PlaylistTrack>();

    }
}
