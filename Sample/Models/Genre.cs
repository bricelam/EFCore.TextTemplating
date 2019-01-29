using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sample.Models
{
    public partial class Genre
    {
        public long GenreId { get; set; }
        public string Name { get; set; }
    }
}
