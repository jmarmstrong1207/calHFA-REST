using System;
using System.Collections.Generic;

#nullable disable

namespace CalHFA_API.Models
{
    public partial class Loanstatus
    {
        public int LoanStatusId { get; set; }
        public int? LoanId { get; set; }
        public int? StatusCode { get; set; }
        public string StatusDate { get; set; }
        public string LoginName { get; set; }
        public string LoginDate { get; set; }
        public int? StatusSequence { get; set; }

        public virtual Loan Loan { get; set; }
        public virtual Statuscode StatusCodeNavigation { get; set; }
    }
}
