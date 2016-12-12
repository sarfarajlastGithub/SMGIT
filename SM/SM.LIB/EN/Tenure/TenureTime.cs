using SM.LIB.EN.School;
using SM.LIB.VM.Account.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LIB.EN.Tenure
{
    public class TenureTime
    {
        public int Id { get; set; }
        public SchoolProfile SchoolProfile { get; set; }
        public int SchoolProfileId { get; set; }
        public TenureYear TenureYearName { get; set; }
        public DateTime? TenureStartDate { get; set; }
        public DateTime? TenureEndDate { get; set; }
        public bool IsSet { get; set; }
    }
}
