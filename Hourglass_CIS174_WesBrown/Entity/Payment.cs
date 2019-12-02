using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hourglass_CIS174_WesBrown.Entity
{
    public class Payment
    {
        public int Id { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [Required]
        public int WeeklyHoursId { get; set; }

        [Required]
        public double PaymentAmount { get; set; }

        [Required]
        [Display(Name = "Payment Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime PaymentDate { get; set; }

        public bool IsDeleted { get; set; }
    }
}
