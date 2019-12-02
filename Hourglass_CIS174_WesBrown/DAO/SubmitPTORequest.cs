using Hourglass_CIS174_WesBrown.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hourglass_CIS174_WesBrown.DAO
{
    public class SubmitPTORequest
    {
        public int Id { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [Required]
        [Display(Name = "Request Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime RequestDate { get; set; }

        [Required]
        [Range(0,8)]
        public double RequestedHours { get; set; }

        public bool Approved { get; set; }

        public bool IsDeleted { get; set; }
    }
}
