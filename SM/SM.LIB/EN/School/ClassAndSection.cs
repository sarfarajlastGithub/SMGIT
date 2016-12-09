using SM.LIB.VM.Account.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LIB.EN.School
{
    public class ClassAndSection
    {
        public int Id { get; set; }
        public string SchoolId { get; set; }
        public SClass SClass { get; set; }
        public SSectionEnum SSection { get; set; }
    }
}
