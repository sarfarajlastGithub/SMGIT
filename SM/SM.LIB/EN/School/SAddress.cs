using SM.LIB.VM.Account.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LIB.EN.School
{
    public class SAddress
    {
        public int Id { get; set; }
        public string AddL1 { get; set; }
        public string AddL2 { get; set; }
        public int Pin { get; set; }
        public City City { get; set; }
        public State state { get; set; }
    }
}
