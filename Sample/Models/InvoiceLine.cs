using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sample.Models
{
    public partial class InvoiceLine
    {
        public long InvoiceLineId { get; set; }

        public long InvoiceId { get; set; }

        public long TrackId { get; set; }

		[Required]
        public string UnitPrice { get; set; }

        public long Quantity { get; set; }

		public virtual Invoice Invoice { get; set; }

		public virtual Track Track { get; set; }

    }
}
