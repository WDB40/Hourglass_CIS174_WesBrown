using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hourglass_CIS174_WesBrown.Entity
{
    public class ErrorLog
    {

        public int Id { get; set; }
        public string ResponseId { get; set; }
        public DateTime ErrorDateTime { get; set; }
        public string StatusCode { get; set; }
        public string ExceptionMessage { get; set; }
        public string StackTrace { get; set; }
    }
}
