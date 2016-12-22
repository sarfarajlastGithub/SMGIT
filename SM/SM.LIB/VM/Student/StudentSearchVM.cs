using SM.LIB.VM.Account.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LIB.VM.Student
{
    public class StudentSearchVM
    {
        public string StudentProfileId { get; set; }

        public string StudentName { get; set; }

        public SClass StuClass { get; set; }

        public SSectionEnum StuSection { get; set; }

        public TenureYear TenureName { get; set; }

        public string StuClassString { get; set; }

        public string StuSectionString { get; set; }

        public string TenureNameString { get; set; }

        //public FeeAccount FeeAccount { get; set; }

        //public int FeeAccountId { get; set; }

        public bool IsActive { get; set; }

    }
}
