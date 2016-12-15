using SM.LIB.EN.School;
using SM.LIB.VM.Account.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LIB.VM.Account
{
    public class SchoolProfileModel
    {
        [Required]
        [Display(Name = "School Name")]
        public string SchoolName { get; set; }

        [Required]
        [Display(Name = "Stay Facility")]
        public SchoolFType SchoolFType { get; set; }

        [Required]
        [Display(Name = "School Type")]
        public SchoolGType SchoolGType { get; set; }

        [Required]
        [StringLength(6,ErrorMessage ="Digit has to be less then 7")]
        public string TotalStudents { get; set; }

        [Display(Name = "School Phone Number")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string SchoolPhoneNumber { get; set; }

        [Required]
        [Display(Name = "Email Id")]
        public string EmailId { get; set; }

        [Required]
        [Display(Name = "Contact Person Name")]
        public string CPName { get; set; }

        [Required]
        [Display(Name = "Contact Person Mobile")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string CPPhone { get; set; }

        [Required]
        public SBoard Board { get; set; }

        [Display(Name = "Month of Financial Year")]
        public string AnnulDateOfExam { get; set; }

        [Required]
        public Medium Medium { get; set; }

        [Display(Name = "Established Date")]
        public string EstablishedDate { get; set; }

        public IEnumerable<SClassVM> ClassAndSections { get; set; }
        public SClassVM ClassAndSection { get; set; }

        public SAddress SAddress { get; set; }

        public SClassPresentVM SClassPresentVM { get; set; }

        public SClass SClassEnum { get; set; }
        public SSectionEnum SSectionEnum { get; set; }


    }

}
