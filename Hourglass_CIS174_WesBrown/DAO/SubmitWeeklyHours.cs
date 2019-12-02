using Hourglass_CIS174_WesBrown.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hourglass_CIS174_WesBrown.DAO
{
    public class SubmitWeeklyHours
    {
        public int Id { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [Required]
        [Display(Name = "Total Hours")]
        public double TotalHours { get; set; }


        public double RegularHours { get; set; }


        public double OvertimeHours { get; set; }

        [Required]
        [Display(Name = "PTO Hours")]
        public double PtoHours { get; set; }

        [Required]
        [Display(Name = "Week Start Date")]
        [DataType(DataType.Date)]
        public DateTime WeekStartDate { get; set; } = DateTime.Now;

        [Required]
        [Display(Name = "Week End Date")]
        [DataType(DataType.Date)]
        public DateTime WeekEndtDate { get; set; } = DateTime.Now;

        public bool Paid { get; set; }

        public bool IsDeleted { get; set; }
    }
}
