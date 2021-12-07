using CalHFA_API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

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
            //compliance loans in line, date and count
            MyStruct myStruct = loansInLine(410);
            l.ComplianceReviewCount = myStruct.count;
            l.ComplianceReviewDate = myStruct.date;

            //compliance loans in suspense, date and count
            myStruct = loansInLine(422);
            l.ComplianceReviewSuspenseCount = myStruct.count;
            l.ComplianceReviewSuspenseDate = myStruct.date;

            //purchase loans in line, date and count
            myStruct = loansInLine(510);
            l.PurchaseReviewCount = myStruct.count;
            l.PurchaseReviewDate = myStruct.date;

            //purchase loans in suspense, date and count
            myStruct = loansInLine(522);
            l.PurchaseReviewSuspenseCount = myStruct.count;
            l.PurchaseReviewSuspenseDate = myStruct.date;

            //add to cache
            Caching.Add(l.ComplianceReviewCount, l.ComplianceReviewDate);
            Caching.Add(l.ComplianceReviewSuspenseCount, l.ComplianceReviewSuspenseDate);
            Caching.Add(l.PurchaseReviewCount, l.PurchaseReviewDate);
            Caching.Add(l.PurchaseReviewSuspenseCount,l.PurchaseReviewSuspenseDate);

            //change values to cached values
            l.ComplianceReviewCount = Caching.GetCount(l.ComplianceReviewCount);
            l.ComplianceReviewDate = Caching.GetDate(l.ComplianceReviewDate);
            l.ComplianceReviewSuspenseCount = Caching.GetCount(l.ComplianceReviewSuspenseCount);
            l.ComplianceReviewSuspenseDate = Caching.GetDate(l.ComplianceReviewSuspenseDate);
            l.PurchaseReviewCount = Caching.GetCount(l.PurchaseReviewCount);
            l.PurchaseReviewDate = Caching.GetDate(l.PurchaseReviewDate);
            l.PurchaseReviewSuspenseCount = Caching.GetCount(l.PurchaseReviewSuspenseCount);
            l.PurchaseReviewSuspenseDate = Caching.GetDate(l.PurchaseReviewSuspenseDate);

            return Ok(l);
        }
        //creates a struct that will be in charge of storing the date for the loans and the count of the loans
        public struct MyStruct
        {
            public int count;
            public String date;
        }
        //get function for loans in line as well as the date
        private MyStruct loansInLine(int statusCode)
        {
            MyStruct retVal;

            retVal.count = 0;
            retVal.date = " ";

            using (var context = new loanschemaContext())
            {
                #region FromSqlRaw
                //query that uses the view created inside the data base
                var lonsInLine = context.LoansInLines.FromSqlRaw("" +
                     "select * from LoansInLine " +
                     "where StatusCode = " + statusCode + " " +
                     "order by StatusDate desc").ToList();

                if (lonsInLine.Count > 0)
                {
                    retVal.count = lonsInLine[0].CountLoans.Value;
                    retVal.date = lonsInLine[0].StatusDate.ToString();
                }
                #endregion
            }
            return retVal;
        }
    }
}
