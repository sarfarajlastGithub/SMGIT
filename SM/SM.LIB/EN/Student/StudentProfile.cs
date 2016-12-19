using SM.LIB.EN.School;
using SM.LIB.VM;
using SM.LIB.VM.Student.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LIB.EN.Student
{
    public class StudentProfile
    {
        public int Id { get; set; }
        public string StudentId { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public virtual ICollection<SMFile> Files { get; set; }
        public int FileId { get; set; }
        public string PhotoLocation { get; set; }
        public string PreEduInfo { get; set; }

        public string GuardianName { get; set; }
        public string GuardianMobile { get; set; }
        public string GuardialEmail { get; set; }
        public Qualification GuardianQualification { get; set; }
        public string GuardianOcupation { get; set; }
        public Relation RelationWithGuardian { get; set; }
        public Address Address { get; set; }
        [Required]
        public int AddressId { get; set; }
        public string MotherName { get; set; }
        public string MotherQualification { get; set; }
        public string MotherOcupation { get; set; }


        // guardian
    }
}
