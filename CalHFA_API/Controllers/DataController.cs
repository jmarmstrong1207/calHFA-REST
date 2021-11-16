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
                ComplianceReviewSuspenseCount = 2,
                PurchaseReviewCount = 3,
                PurchaseReviewDate = "",
                PurchaseReviewSuspenseCount = 4,
            };
            MyStruct myStruct = loansInLine(510);

            l.PurchaseReviewCount = myStruct.count;
            l.PurchaseReviewDate = myStruct.date;

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

        public struct MyStruct
        {
            public int count;
            public String date;
        }

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

        //private MyStruct loansInLine(int statusCode)
        //{
        //    MyStruct retVal;

        //    retVal.count = 0;
        //    retVal.date = " ";

        //    var x = new loanschemaContext();
        //    var statuses = x.Loanstatuses.ToList();

        //    // Buscar fecha maxima
        //    foreach (var loansStatuses in statuses)
        //    {
        //        if (loansStatuses.StatusCode == statusCode)
        //        {
        //            retVal.count++;
        //            //loansStatuses.StatusDate
        //        }
        //    }
        //    return retVal;
        //}
    }
}
