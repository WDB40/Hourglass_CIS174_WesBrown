using Hourglass_CIS174_WesBrown.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hourglass_CIS174_WesBrown.Filters
{
    public class EmployeeExistsFilter : IActionFilter
    {
        private readonly EmployeeDataService employeeDataService;

        public EmployeeExistsFilter(EmployeeDataService dataService)
        {
            employeeDataService = dataService;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Intentionally left blank.
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            int id = (int) context.ActionArguments["id"];
            if (!employeeDataService.EmployeeExists(id))
            {
                context.Result = new BadRequestObjectResult("This employee does not exist.");
            }
        }
    }

    public class EmployeeExistsAttribute : TypeFilterAttribute
    {
        public EmployeeExistsAttribute() : base(typeof(EmployeeExistsFilter)) { }
    }
}
