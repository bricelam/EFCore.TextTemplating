using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Chinook.Models
{
    public partial class Customer
    {
        public long CustomerId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string Company { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public string PostalCode { get; set; }

        public string Phone { get; set; }

        public string Fax { get; set; }

        [Required]
        public string Email { get; set; }

        public long? SupportRepId { get; set; }

        public virtual ICollection<Invoice> Invoices { get; } = new HashSet<Invoice>();

        public virtual Employee SupportRep { get; set; }

    }
}
