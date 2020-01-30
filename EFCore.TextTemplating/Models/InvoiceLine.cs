using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFCore.TextTemplating.Models
{
    public partial class InvoiceLine
    {
        public long InvoiceLineId { get; set; }

        public long InvoiceId { get; set; }

        public long TrackId { get; set; }

        [Required]
        public byte[] UnitPrice { get; set; }

        public long Quantity { get; set; }

        public virtual Invoice Invoice { get; set; }

        public virtual Track Track { get; set; }

    }
}
