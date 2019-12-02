using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hourglass_CIS174_WesBrown.Filters
{
    public class ValidateModelFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                Controller controller = context.Controller as Controller;
                var model = context.ActionArguments?.Count > 0
                    ? context.ActionArguments.First().Value
                    : null;

                context.Result = (IActionResult)controller?.View(model) ?? new BadRequestResult();
            }
            base.OnActionExecuting(context);
        }
    }
}
