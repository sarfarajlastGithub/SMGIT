using SM.LIB.VM.Account.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LIB.VM.Account
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name ="School Name")]
        public string Name { get; set; }

        [Required]
        public City City { get; set; }

        [Required]
        [Display(Name ="Board")]
        public SBoard Board { get; set; }

        [Required]
        [Display(Name ="No. of Student")]
        public int TotalStudent { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 4)]
        [Display(Name ="Contact Person Name")]
        public string CPName { get; set; }

        [Required]
        [Display(Name = "Contact Person Mobile Number")]
        public string CPPhone { get; set; }

    }
}
