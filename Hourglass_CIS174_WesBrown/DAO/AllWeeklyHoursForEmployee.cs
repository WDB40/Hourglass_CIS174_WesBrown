using Hourglass_CIS174_WesBrown.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hourglass_CIS174_WesBrown.DAO
{
    public class AllWeeklyHoursForEmployee
    {
        public int EmployeeId { get; set; }
        public WeeklyHours WeeklyHours { get; set; }
        public IList<WeeklyHours> AllWeeklyHours { get; set; }
    }
}
