using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChinookApp.Models
{
    public partial class MediaType
    {
        public int MediaTypeId { get; set; }

        [StringLength(120)]
        public string Name { get; set; }

        public virtual ICollection<Track> Tracks { get; } = new HashSet<Track>();

    }
}
