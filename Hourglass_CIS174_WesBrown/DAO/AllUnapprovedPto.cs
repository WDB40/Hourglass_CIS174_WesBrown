using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hourglass_CIS174_WesBrown.DAO
{
    public class AllUnapprovedPto
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(25)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(25)]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Requested Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime RequestedDate { get; set; }
        public double RequestedHours { get; set; }
    }
}
