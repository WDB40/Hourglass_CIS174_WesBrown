using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hourglass_CIS174_WesBrown.DAO
{
    public class ProcessPayment
    {
        public int Id { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [Required]
        public int WeeklyHoursId { get; set; }

    }
}
