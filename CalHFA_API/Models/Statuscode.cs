using System;
using System.Collections.Generic;

#nullable disable

namespace CalHFA_API.Models
{
    public partial class Statuscode
    {
        public Statuscode()
        {
            Loanstatuses = new HashSet<Loanstatus>();
        }

        public int StatusCode1 { get; set; }
        public string Description { get; set; }
        public string BusinessUnit { get; set; }
        public string NotesAndAssumptions { get; set; }
        public string ConversationCategoryId { get; set; }

        public virtual ICollection<Loanstatus> Loanstatuses { get; set; }
    }
}
