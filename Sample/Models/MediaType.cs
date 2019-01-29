using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sample.Models
{
    public partial class MediaType
    {
        public long MediaTypeId { get; set; }
        public string Name { get; set; }
    }
}
