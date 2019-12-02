using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hourglass_CIS174_WesBrown.Entity;
using Hourglass_CIS174_WesBrown.Filters;
using Hourglass_CIS174_WesBrown.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hourglass_CIS174_WesBrown.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ErrorLog]
    public class DisbursementController : ControllerBase
    {
        private readonly PaymentsDataService paymentsDataService;

        public DisbursementController(PaymentsDataService dataService)
        {
            paymentsDataService = dataService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAllDisbursements()
        {
            IList<Payment> allPayments = paymentsDataService.GetAllPayments();
            return Ok(allPayments);
        }

        [EmployeeExists]
        [HttpGet("GetFor/{id}")]
        public IActionResult GetForEmployee([FromRoute] int id)
        {
            IList<Payment> paymentsForEmployee = paymentsDataService.GetAllPaymentsForEmployee(id);
            return Ok(paymentsForEmployee);
        }
    }
}