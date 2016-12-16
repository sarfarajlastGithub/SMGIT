using SM.LIB.EN.Fee;
using SM.LIB.EN.School;
using SM.LIB.EN.Tenure;
using SM.LIB.VM.Account.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LIB.EN.Student
{
    public class StudentReg
    {
        public int Id { get; set; }

        public SchoolProfile SchoolProfile { get; set; }

        [Required]
        public string SchoolProfileId { get; set; }

        public StudentProfile StudentProfile { get; set; }

        [Required]
        public string StudentProfileId { get; set; }

        public string StudentName { get; set; }

        public SClass StuClass { get; set; }

        public SSectionEnum StuSection { get; set; }

        public TenureYear TenureYear { get; set; }

        //public FeeAccount FeeAccount { get; set; }

        //public int FeeAccountId { get; set; }

        public bool IsActive { get; set; }

        public DateTime? AdmissioinDate { get; set; }

    }
}
