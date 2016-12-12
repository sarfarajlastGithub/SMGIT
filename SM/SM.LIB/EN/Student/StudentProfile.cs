using SM.LIB.VM;
using SM.LIB.VM.Student.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LIB.EN.Student
{
    public class StudentProfile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public string PhotoLocation { get; set; }
        public string PreEduInfo { get; set; }

        public string GuardianName { get; set; }
        public int GuardianMobile { get; set; }
        public Qualification GuardianQualification { get; set; }
        public string GuardianOcupation { get; set; }
        public Relation RelationWithGuardian { get; set; }
        public string MotherName { get; set; }
        public string MotherQualification { get; set; }
        public string MotherOcupation { get; set; }

        // guardian
    }
}
