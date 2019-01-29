using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sample.Models
{
    public partial class Invoice
    {
        public long InvoiceId { get; set; }
        public string BillingAddress { get; set; }
        public string BillingCity { get; set; }
        public string BillingCountry { get; set; }
        public string BillingPostalCode { get; set; }
        public string BillingState { get; set; }
        public long CustomerId { get; set; }
        public string InvoiceDate { get; set; }
        public string Total { get; set; }
    }
}
