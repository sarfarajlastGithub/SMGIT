using SM.LIB.EN.Fee;
using SM.LIB.EN.School;
using SM.LIB.EN.Student;
using SM.LIB.EN.Tenure;
using SM.LIB.VM.Account.Enums;
using SM.LIB.VM.Student.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SM.LIB.VM.Student
{
    public class StudentVM
    {
        public int Id { get; set; }
        public string StudentId { get; set; }
        public string SchoolId { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string DateOfBirthString { get; set; }
        public string PhotoLocation { get; set; }
        public SMFile smfile { get; set; }
        public string PreEduInfo { get; set; }
        public string GuardianName { get; set; }
        public string GuardianMobile { get; set; }
        public string GuardialEmail { get; set; }
        public Qualification GuardianQualification { get; set; }
        public string GuardianOcupation { get; set; }
        public Relation RelationWithGuardian { get; set; }
        public string MotherName { get; set; }
        public string MotherQualification { get; set; }
        public string MotherOcupation { get; set; }
        public Address Address { get; set; }

        [Remote("ExistTenureYear", "Account", HttpMethod = "POST", ErrorMessage = "Tenure Year is not set yet, Pleas Add tenure Year in profile Update .")]
        public TenureYear TenureYear { get; set; }

        [Remote("ExistClass", "Account", HttpMethod = "POST", ErrorMessage = "This Class is not set for the School, Add this class")]
        public SClass Stuclass { get; set; }

        [Remote("ExistSection", "Account", HttpMethod = "POST", ErrorMessage = "This section is not in the class OR Section Limit is over, Choose Another Section")]
        public SSectionEnum StuSection { get; set; }

        public bool IsActive { get; set; }

        public DateTime? AdmissioinDate { get; set; }

    }
}
