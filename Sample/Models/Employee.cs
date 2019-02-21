using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sample.Models
{
    public partial class Employee
    {
        public long EmployeeId { get; set; }

		[Required]
        public string LastName { get; set; }

		[Required]
        public string FirstName { get; set; }

        public string Title { get; set; }

        public long? ReportsTo { get; set; }

        public string BirthDate { get; set; }

        public string HireDate { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public string PostalCode { get; set; }

        public string Phone { get; set; }

        public string Fax { get; set; }

        public string Email { get; set; }

		public virtual ICollection<Customer> Customer { get; } = new HashSet<Customer>();

		public virtual ICollection<Employee> InverseReportsToNavigation { get; } = new HashSet<Employee>();

		public virtual Employee ReportsToNavigation { get; set; }

    }
}
