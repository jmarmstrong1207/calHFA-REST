using System;
using System.Collections.Generic;

#nullable disable

namespace CalHFA_API.Models
{
    public partial class LoanType
    {
        public LoanType()
        {
            Loans = new HashSet<Loan>();
        }

        public int LoanTypeId { get; set; }
        public int? LoanCategoryId { get; set; }
        public string Description { get; set; }
        public string LongDescription { get; set; }
        public string Active { get; set; }
        public string ActiveEndDate { get; set; }
        public int? RateLockDays { get; set; }
        public string ActiveRates { get; set; }
        public int? LoanTypeCategory { get; set; }
        public int? SortOrder { get; set; }
        public int? ProductTypeId { get; set; }

        public virtual Loancategory LoanCategory { get; set; }
        public virtual ICollection<Loan> Loans { get; set; }
    }
}
