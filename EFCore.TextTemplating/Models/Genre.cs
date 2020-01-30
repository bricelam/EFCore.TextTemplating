using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFCore.TextTemplating.Models
{
    public partial class Genre
    {
        public long GenreId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Track> Track { get; } = new HashSet<Track>();

    }
}
