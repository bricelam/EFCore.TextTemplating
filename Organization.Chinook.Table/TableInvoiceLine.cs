namespace Organization.Chinook.Table
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("InvoiceLine")]
    public partial class TableInvoiceLine
    {
        [Key]
        public int InvoiceLineId { get; set; }

        public int InvoiceId { get; set; }

        public int TrackId { get; set; }

        [Column(TypeName = "numeric(10, 2)")]
        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }

        public virtual TableInvoice Invoice { get; set; }

        public virtual TableTrack Track { get; set; }

    }
}
