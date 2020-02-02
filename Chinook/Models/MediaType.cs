using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Chinook.Models
{
    public partial class MediaType
    {
        public long MediaTypeId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Track> Tracks { get; } = new HashSet<Track>();

    }
}
