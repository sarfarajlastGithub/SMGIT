using SM.LIB.EN.Fee;
using SM.LIB.EN.School;
using SM.LIB.EN.Tenure;
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
        public int SchoolProfileId { get; set; }

        public StudentProfile StudentProfile { get; set; }

        [Required]
        public int StudentProfileId { get; set; }

        public string StudentName { get; set; }

        public ClassAndSection SClass { get; set; }

        [Required]
        public int ClassAndSectionId { get; set; }

        public TenureTime TenureTime { get; set; }

        public int TenureTimeId { get; set; }

        public FeeAccount FeeAccount { get; set; }

        public int FeeAccountId { get; set; }

        public bool IsActive { get; set; }

    }
}
