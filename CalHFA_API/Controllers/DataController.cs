using CalHFA_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                PurchaseReviewSuspenseCount = 4
            };

            return Ok(l);
        }
        // GET FOR COMPLIANCE
        [HttpGet("Compliance")]
        private ActionResult Compliance(string compliance)
        {
            return Ok(compliance);
        }

        [HttpGet("test")]
        public ActionResult test()
        {
            var x = new loanschemaContext();
            var loans = x.Loans.ToList();
            return Ok(loans);
        }
    }
}