using SM.LIB.VM.Account.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LIB.VM.Account
{
    public class SClassVM
    {
        public SClass Name { get; set; }

        public IEnumerable<SSectionVM> ListOfSection { get; set; }
    }
}
