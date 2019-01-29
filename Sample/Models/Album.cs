using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sample.Models
{
    public partial class Album
    {
        public long AlbumId { get; set; }
        public long ArtistId { get; set; }
        public string Title { get; set; }
    }
}
