using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Vidly2.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Driving License")]
        public string DrivingLicense { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Phone")]
        public string Phone { get; set; }
    }
}
