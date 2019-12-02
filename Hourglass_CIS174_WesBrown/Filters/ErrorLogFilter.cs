using Hourglass_CIS174_WesBrown.Entity;
using Hourglass_CIS174_WesBrown.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hourglass_CIS174_WesBrown.Filters
{
    public class ErrorLogFilter : IExceptionFilter
    {

        private readonly ErrorLogDataService errorLogDataService;

        public ErrorLogFilter(ErrorLogDataService dataService)
        {
            errorLogDataService = dataService;
        }

        public void OnException(ExceptionContext context)
        {
            ErrorLog errorLog = new ErrorLog();
            errorLog.ResponseId = context.HttpContext.TraceIdentifier.ToString();
            errorLog.ErrorDateTime = DateTime.UtcNow;
            errorLog.StatusCode = context.HttpContext.Response.StatusCode.ToString();
            errorLog.ExceptionMessage = context.Exception.Message.ToString();
            errorLog.StackTrace = context.Exception.StackTrace.ToString();

            errorLogDataService.CreateErrorLog(errorLog);
        }
    }

    public class ErrorLogAttribute : TypeFilterAttribute
    {
        public ErrorLogAttribute() : base(typeof(ErrorLogFilter)) { }
    }
}
