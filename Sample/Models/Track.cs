using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sample.Models
{
    public partial class Track
    {
        public long TrackId { get; set; }
        public long? AlbumId { get; set; }
        public long? Bytes { get; set; }
        public string Composer { get; set; }
        public long? GenreId { get; set; }
        public long MediaTypeId { get; set; }
        public long Milliseconds { get; set; }
        public string Name { get; set; }
        public string UnitPrice { get; set; }
    }
}
