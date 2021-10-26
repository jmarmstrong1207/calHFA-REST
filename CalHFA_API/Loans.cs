using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalHFA_API
{
    public class Loans
    {
        public int ComplianceReviewCount { get; set; }
        public int ComplianceReviewSuspenseCount { get; set; }

        public int PurchaseReviewCount { get; set; }
        public int PurchaseReviewSuspenseCount { get; set; }
    }
}
