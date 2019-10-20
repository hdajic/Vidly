using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly_Movie_Store.Models.AccountViewModels
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Driving Licence")]
        public string DrivingLicence { get; set; }

        [Required]
        [StringLength(15)]
        public string Phone { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}