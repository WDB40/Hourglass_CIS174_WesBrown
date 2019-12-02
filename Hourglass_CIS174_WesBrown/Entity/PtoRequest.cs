using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hourglass_CIS174_WesBrown.Entity
{
    public class PtoRequest
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Requesting Employee")]
        public int EmployeeId { get; set; }

        [Required]
        [Display(Name = "Request Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime RequestDate { get; set; }

        [Required]
        public double RequestedHours { get; set; }

        public bool Approved { get; set; }

        public bool IsDeleted { get; set; }
    }
}
