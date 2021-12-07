using System;
using System.Collections.Generic;

#nullable disable
//This is the view that allows us to call the joint tables
/*
 create view loansInLine as
    select
        b.statuscode, 
        min(b.statusdate) statusdate,
        count(1) as countLoans
    from loan a, loanstatus b, loan_type c
    where (b.loanid, b.statussequence) in (
      select 
        loanstatus.LoanID, max(loanstatus.StatusSequence)
      from 
        loan, loanstatus 
      where 
        loanstatus.LoanID = loan.LoanID
      group by loanstatus.LoanID
    ) and
    a.LoanTypeID = c.LoanTypeID and 
    a.loanid = b.loanId
    group by 
        loancategoryid, b.statuscode
    order by 
        loancategoryid asc;
 */
namespace CalHFA_API.Models
{
    public partial class LoansInLine
    {
        public int? StatusCode { get; set; }
        public DateTime? StatusDate { get; set; }
        public int? CountLoans { get; set; }

    }
}