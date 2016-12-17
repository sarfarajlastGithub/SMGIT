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

        public string StuClass { get; set; }

        public string StuSection { get; set; }

        public string TenureYear { get; set; }

        //public FeeAccount FeeAccount { get; set; }

        //public int FeeAccountId { get; set; }

        public bool IsActive { get; set; }


        //this is for load enum

        public SClass Sclass { get; set; }
        public SSectionEnum SSection { get; set; }
        public TenureYear TenureName { get; set; }

    }
}
