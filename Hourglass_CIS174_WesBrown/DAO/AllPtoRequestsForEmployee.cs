using Hourglass_CIS174_WesBrown.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hourglass_CIS174_WesBrown.DAO
{
    public class AllPtoRequestsForEmployee
    {
        public int employeeId { get; set; }
        public PtoRequest PtoRequest { get; set; }
        public IList<PtoRequest> ptoRequests { get; set; }
    }
}
