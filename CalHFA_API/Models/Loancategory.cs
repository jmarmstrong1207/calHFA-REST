using System;
using System.Collections.Generic;

#nullable disable

namespace CalHFA_API.Models
{
    public partial class Loancategory
    {
        public Loancategory()
        {
            LoanTypes = new HashSet<LoanType>();
        }

        public int LoanCategoryId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<LoanType> LoanTypes { get; set; }
    }
}
