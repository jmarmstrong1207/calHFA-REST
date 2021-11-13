using System;
using System.Collections.Generic;

#nullable disable

namespace CalHFA_API.Models
{
    public partial class Loan
    {
        public Loan()
        {
            Loanstatuses = new HashSet<Loanstatus>();
        }

        public int LoanId { get; set; }
        public int? LoanTypeId { get; set; }
        public int? LoanAmount { get; set; }
        public string AnnualIncome { get; set; }
        public string HouseholdCount { get; set; }
        public string DeliveryDate { get; set; }
        public string Lvratio { get; set; }
        public decimal? InterestRate { get; set; }
        public string Balance { get; set; }
        public int? InsCode { get; set; }
        public string InsurerNum { get; set; }
        public DateTime? ReservDateTime { get; set; }

        public virtual LoanType LoanType { get; set; }
        public virtual ICollection<Loanstatus> Loanstatuses { get; set; }
    }
}
