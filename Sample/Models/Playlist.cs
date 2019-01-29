using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sample.Models
{
    public partial class Playlist
    {
        public long PlaylistId { get; set; }
        public string Name { get; set; }
    }
}
