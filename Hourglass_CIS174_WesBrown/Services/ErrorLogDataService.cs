using Hourglass_CIS174_WesBrown.Data;
using Hourglass_CIS174_WesBrown.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hourglass_CIS174_WesBrown.Services
{
    public class ErrorLogDataService
    {
        private readonly HourglassDBContext _context;

        public ErrorLogDataService(HourglassDBContext context)
        {
            _context = context;
        }

        public void CreateErrorLog(ErrorLog errorLog)
        {
            _context.ErrorLogs.Add(errorLog);
            _context.SaveChanges();
        }
    }
}
