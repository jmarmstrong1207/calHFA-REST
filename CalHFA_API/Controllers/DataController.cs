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
    }
}
