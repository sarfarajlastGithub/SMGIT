using SM.LIB.VM.Account.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LIB.EN.School
{
    public class SAddress
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Address Line 1")]
        [StringLength(300, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 4)]
        public string AddL1 { get; set; }

        [Display(Name = "Address Line 2")]
        [StringLength(300, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        public string AddL2 { get; set; }

        [Required]
        [Display(Name = "Pin Code")]
        public int Pin { get; set; }

        [Required]
        public City City { get; set; }

        [Required]
        public State state { get; set; }
    }
}
