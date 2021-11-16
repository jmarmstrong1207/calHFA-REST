using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalHFA_API
{
    public class Loans
    {
        public int ComplianceReviewCount { get; set; }
        public String ComplianceReviewDate { get; set; }
        public int ComplianceReviewSuspenseCount { get; set; }
        public String ComplianceReviewSuspenseDate { get; set; }

        public int PurchaseReviewCount { get; set; }
        public String PurchaseReviewDate { get; set; }
        public int PurchaseReviewSuspenseCount { get; set; }
        public String PurchaseReviewSuspenseDate{ get; set; }
    }
}
