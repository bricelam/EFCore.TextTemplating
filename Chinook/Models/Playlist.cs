using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Chinook.Models
{
    public partial class Playlist
    {
        public long PlaylistId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<PlaylistTrack> PlaylistTracks { get; } = new HashSet<PlaylistTrack>();

    }
}
