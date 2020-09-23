namespace Organization.Chinook.Table
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Invoice")]
    public partial class TableInvoice
    {
        [Key]
        public int InvoiceId { get; set; }

        public int CustomerId { get; set; }

        [Column(TypeName = "datetime")]
        public DateTimeOffset InvoiceDate { get; set; }

        [StringLength(70)]
        public string BillingAddress { get; set; }

        [StringLength(40)]
        public string BillingCity { get; set; }

        [StringLength(40)]
        public string BillingState { get; set; }

        [StringLength(40)]
        public string BillingCountry { get; set; }

        [StringLength(10)]
        public string BillingPostalCode { get; set; }

        [Column(TypeName = "numeric(10, 2)")]
        public decimal Total { get; set; }

        public virtual TableCustomer Customer { get; set; }

        public virtual ICollection<TableInvoiceLine> InvoiceLine { get; } = new HashSet<TableInvoiceLine>();

    }
}
