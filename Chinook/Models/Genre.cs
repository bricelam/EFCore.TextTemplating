using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Chinook.Models
{
    public partial class Genre
    {
        public long GenreId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Track> Tracks { get; } = new HashSet<Track>();

    }
}
