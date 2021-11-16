using CalHFA_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace CalHFA_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataController : Controller
    {
        // api/data/getLoans
        [HttpGet("getLoans")]
        public ActionResult getLoans()
        {
            // Example return
            Loans l = new()
            {
                ComplianceReviewCount = 1,
                ComplianceReviewDate = "",
                ComplianceReviewSuspenseCount = 2,
                ComplianceReviewSuspenseDate = "",
                PurchaseReviewCount = 3,
                PurchaseReviewDate = "",
                PurchaseReviewSuspenseCount = 4,
                PurchaseReviewSuspenseDate = "",
            };
            //ComplianceLoansInLine & ComplianceDate
            MyStructCompliance myStructCompliance = ComplianceInLine(410);

            l.ComplianceReviewCount = myStructCompliance.count;
            l.ComplianceReviewDate = myStructCompliance.date;
            //SuspenseLoansInLine & SuspenseDate
            MyStructComplianceSusp myStructComplianceSusp = ComplianceSuspInLine(422);

            l.ComplianceReviewSuspenseCount = myStructComplianceSusp.count;
            l.ComplianceReviewSuspenseDate = myStructComplianceSusp.date;
            //PostClosingLoansInLine & PostClosingDate
            MyStruct myStruct = loansInLine(510);

            l.PurchaseReviewCount = myStruct.count;
            l.PurchaseReviewDate = myStruct.date;
            //PostClosingSuspenseLoansInLine & PostClosingSuspenseDate
            MyStructSuspense myStructSuspense = suspenseInLine(522);

            l.PurchaseReviewSuspenseCount = myStructSuspense.count;
            l.PurchaseReviewSuspenseDate = myStructSuspense.date;

            return Ok(l);
        }
        [HttpGet("test")]
        public ActionResult test()
        {
            var x = new loanschemaContext();
             
            var statuses = x.Loanstatuses.ToList();

            return Ok();

        }
       //GET FOR COMPLIANCE 
       [HttpGet("Compliance")]
        private ActionResult Compliance(string compliance)
        {
            return Ok(compliance);
        }
        public struct MyStructCompliance
        {
            public int count;
            public String date;
        }
        //GET FOR COMPLIANCE
        private MyStructCompliance ComplianceInLine(int statusCode)
        {
            MyStructCompliance retVal;

            retVal.count = 0;
            retVal.date = " ";

            using (var context = new loanschemaContext())
            {
                #region FromSqlRaw
                var loans = context.Loanstatuses.FromSqlRaw("" +
                    "select * from loanstatus a " +
                    "where a.statusDate in (" +
                    "    select max(maxStatusDate) from(" +
                    "        select  c.loanid, max(c.statusDate) as maxStatusDate, max(c.StatusSequence) as maxSequence, count(1) from loanstatus c" +
                    "        where c.StatusCode = " + statusCode +
                    "        group by c.loanid" +
                    "    ) as b" +
                    ") and a.StatusCode = 410 "
                    ).ToList();

                retVal.count = loans.Count;
                retVal.date = loans[0].StatusDate.ToString();

                #endregion
            }
            return retVal;
        }
        public struct MyStructComplianceSusp
        {
            public int count;
            public String date;
        }
        //GET FOR COMPLIANCE SUSPENSE
        private MyStructComplianceSusp ComplianceSuspInLine(int statusCode)
        {
            MyStructComplianceSusp retVal;

            retVal.count = 0;
            retVal.date = " ";

            using (var context = new loanschemaContext())
            {
                #region FromSqlRaw
                var loans = context.Loanstatuses.FromSqlRaw("" +
                    "select * from loanstatus a " +
                    "where a.statusDate in (" +
                    "    select max(maxStatusDate) from(" +
                    "        select  c.loanid, max(c.statusDate) as maxStatusDate, max(c.StatusSequence) as maxSequence, count(1) from loanstatus c" +
                    "        where c.StatusCode = " + statusCode +
                    "        group by c.loanid" +
                    "    ) as b" +
                    ") and a.StatusCode = 422 "
                    ).ToList();

                retVal.count = loans.Count;
                retVal.date = loans[0].StatusDate.ToString();

                #endregion
            }
            return retVal;
        }
        public struct MyStruct
        {
            public int count;
            public String date;
        }
        //GET FOR POST CLOSING
        private MyStruct loansInLine(int statusCode)
        {
            MyStruct retVal;

            retVal.count = 0;
            retVal.date = " ";

            using (var context = new loanschemaContext())
            {
                #region FromSqlRaw
                var loans = context.Loanstatuses.FromSqlRaw("" +
                    "select * from loanstatus a " +
                    "where a.statusDate in (" +
                    "    select max(maxStatusDate) from(" +
                    "        select  c.loanid, max(c.statusDate) as maxStatusDate, max(c.StatusSequence) as maxSequence, count(1) from loanstatus c" +
                    "        where c.StatusCode = " + statusCode + 
                    "        group by c.loanid" +
                    "    ) as b" +
                    ") and a.StatusCode = 510 "
                    ).ToList();

                retVal.count = loans.Count;
                retVal.date = loans[0].StatusDate.ToString();

                #endregion
            }
            return retVal;
        }
        public struct MyStructSuspense
        {
            public int count;
            public String date;
        }
        //GET FOR POST CLOSING IN SUSPENSE
        private MyStructSuspense suspenseInLine(int statusCode)
        {
            MyStructSuspense retVal;

            retVal.count = 0;
            retVal.date = " ";

            using (var context = new loanschemaContext())
            {
                #region FromSqlRaw
                var loans = context.Loanstatuses.FromSqlRaw("" +
                    "select * from loanstatus a " +
                    "where a.statusDate in (" +
                    "    select max(maxStatusDate) from(" +
                    "        select  c.loanid, max(c.statusDate) as maxStatusDate, max(c.StatusSequence) as maxSequence, count(1) from loanstatus c" +
                    "        where c.StatusCode = " + statusCode +
                    "        group by c.loanid" +
                    "    ) as b" +
                    ") and a.StatusCode = 522 "
                    ).ToList();

                retVal.count = loans.Count;
                retVal.date = loans[0].StatusDate.ToString();

                #endregion
            }
            return retVal;
        }
    }
}
