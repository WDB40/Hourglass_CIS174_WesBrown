using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hourglass_CIS174_WesBrown.DAO
{
    public class EmployeeModifier
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
        [Display(Name = "Pay Rate")]
        public double PayRate { get; set; }

        [Required]
        [Display(Name = "Remaining PTO Hours")]
        public double RemainingPtoHours { get; set; }
        public bool IsDeleted { get; set; }
    }
}
