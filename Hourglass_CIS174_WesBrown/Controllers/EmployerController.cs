using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Hourglass_CIS174_WesBrown.BusinessLogic;
using Hourglass_CIS174_WesBrown.DAO;
using Hourglass_CIS174_WesBrown.Entity;
using Hourglass_CIS174_WesBrown.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Hourglass_CIS174_WesBrown.Controllers
{
    [ErrorLog]
    [ValidateModelFilter]
    public class EmployerController : Controller
    {

        private readonly EmployeeManager employeeManager;
        private readonly PtoManager ptoManager;
        private readonly PaymentsManager paymentsManager;

        public EmployerController(EmployeeManager eManager, PtoManager pManager, PaymentsManager payManager)
        {
            employeeManager = eManager;
            ptoManager = pManager;
            paymentsManager = payManager;
        }

        public IActionResult Index()
        {
            AllEmployees model = new AllEmployees();
            model.Employees = employeeManager.GetAllEmployees();
            return View(model);
        }

        [HttpGet]
        public IActionResult CreateEmployee()
        {
            return View(new EmployeeModifier());
        }

        [HttpPost]
        public IActionResult CreateEmployee(EmployeeModifier employeeModifier)
        {
            if (!ModelState.IsValid)
            {
                return View(employeeModifier);
            }

            employeeManager.CreateEmployee(employeeModifier);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteEmployee(int id)
        {
            employeeManager.DeleteEmployee(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateEmployee(int id)
        {
            EmployeeModifier employeeModifier = employeeManager.GetEmployee(id);
            return View(employeeModifier);
        }

        public IActionResult UpdateEmployee(EmployeeModifier employeeModifier)
        {
            employeeManager.UpdateEmployee(employeeModifier);
            return RedirectToAction("Index");
        }

        public IActionResult ViewAllUnapprovedPto()
        {
            IList<AllUnapprovedPto> unapprovedPtos = ptoManager.GetAllNonApprovedPtoRequests();
            return View(unapprovedPtos);
        }

        public IActionResult ApprovePtoRequest(int id)
        {
            ptoManager.ApprovePTO(id);
            return RedirectToAction("ViewAllUnapprovedPto");
        }

        public IActionResult DenyPtoRequest(int id)
        {
            ptoManager.DenyPTO(id);
            return RedirectToAction("ViewAllUnapprovedPto");
        }

        public IActionResult ViewAllCompletedTimesheets()
        {
            IList<AllPayments> allPayments = paymentsManager.GetUnpaidTimesheets();
            return View(allPayments);
        }

        public IActionResult PayTimesheet(int id)
        {
            paymentsManager.CreatePayment(id);
            return RedirectToAction("ViewAllCompletedTimesheets");
        }
    }
}