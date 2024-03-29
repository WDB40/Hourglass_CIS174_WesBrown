﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hourglass_CIS174_WesBrown.Entity
{
    public class WeeklyHours
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
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime WeekStartDate { get; set; }

        [Required]
        [Display(Name = "Week End Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime WeekEndtDate { get; set; }

        public bool Paid { get; set; }

        public bool IsDeleted { get; set; }
    }
}
