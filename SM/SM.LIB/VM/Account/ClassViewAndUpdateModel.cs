using SM.LIB.VM.Account.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LIB.VM.Account
{
    public class ClassViewAndUpdateModel
    {
        public bool A { get; set; }

        public bool B { get; set; }

        public bool C { get; set; }

        public bool D { get; set; }

        public bool E { get; set; }

        public bool F { get; set; }

        public int SchoolProfileId { get; set; }

        public SClass ClassName { get; set; }

        public SSectionEnum SectionName { get; set; }

        public List<SClassVM> SClassList { get; set; }

    }
}
