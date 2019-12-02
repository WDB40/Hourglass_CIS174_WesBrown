using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hourglass_CIS174_WesBrown.BusinessLogic;
using Hourglass_CIS174_WesBrown.DAO;
using Hourglass_CIS174_WesBrown.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Hourglass_CIS174_WesBrown.Controllers
{
    [ErrorLog]
    [ValidateModelFilter]
    public class EmployeeController : Controller
    {

        private readonly EmployeeManager employeeManager;
        private readonly PtoManager ptoManager;
        private readonly HoursManager hoursManager;

        public EmployeeController(EmployeeManager eManager, PtoManager pManager, HoursManager hManager)
        {
            employeeManager = eManager;
            ptoManager = pManager;
            hoursManager = hManager;
        }

        public IActionResult Index()
        {
            AllEmployees model = new AllEmployees();
            model.Employees = employeeManager.GetAllEmployees();
            return View(model);
        }

        [HttpGet]
        public IActionResult CreatePTORequest(int id)
        {
            SubmitPTORequest model = new SubmitPTORequest();
            model.EmployeeId = id;
            return View(model);
        }

        [HttpPost]
        public IActionResult CreatePTORequest(SubmitPTORequest ptoRequest)
        {
            ptoManager.CreatePtoRequest(ptoRequest);
            return RedirectToAction("AllPtoRequestsForEmployee", new { id = ptoRequest.EmployeeId });
        }

        [HttpGet]
        public IActionResult AllPtoRequestsForEmployee(int id)
        {
            AllPtoRequestsForEmployee allPtoRequests = new AllPtoRequestsForEmployee();
            allPtoRequests.employeeId = id;
            allPtoRequests.ptoRequests = ptoManager.GetAllPtoRequestsForEmployee(id);

            return View(allPtoRequests);
        }

        public IActionResult DeleteRequest(int id)
        {
            ptoManager.DeletePtoRequest(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdatePtoRequest(int id)
        {
            SubmitPTORequest request = ptoManager.GetPtoRequest(id);
            return View(request);
        }

        [HttpPost]
        public IActionResult UpdatePtoRequest(SubmitPTORequest ptoRequest)
        {
            ptoManager.UpdatePtoRequest(ptoRequest);
            return RedirectToAction("AllPtoRequestsForEmployee", new { id = ptoRequest.EmployeeId });
        }

        [HttpGet]
        public IActionResult CreateWeeklyHours(int id)
        {
            SubmitWeeklyHours hours = new SubmitWeeklyHours();
            hours.EmployeeId = id;
            return View(hours);
        }

        [HttpPost]
        public IActionResult CreateWeeklyHours(SubmitWeeklyHours hours)
        {
            hoursManager.CreateWeeklyHours(hours);
            return RedirectToAction("AllWeeklyHoursForEmployee", new { id = hours.EmployeeId });
        }

        public IActionResult AllWeeklyHoursForEmployee(int id)
        {
            AllWeeklyHoursForEmployee allWeeklyHours = new AllWeeklyHoursForEmployee();
            allWeeklyHours.EmployeeId = id;
            allWeeklyHours.AllWeeklyHours = hoursManager.GetAllUnPaidWeeklyHoursForEmployee(id);

            return View(allWeeklyHours);
        }

        public IActionResult DeleteWeeklyHours(int id)
        {
            hoursManager.DeleteWeeklyHours(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateWeeklyHours(int id)
        {
            SubmitWeeklyHours hours = hoursManager.GetWeeklyHours(id);
            return View(hours);
        }

        public IActionResult UpdateWeeklyHours(SubmitWeeklyHours hours)
        {
            hoursManager.UpdateWeeklyHours(hours);
            return RedirectToAction("AllWeeklyHoursForEmployee", new { id = hours.EmployeeId });
        } 
    }
}