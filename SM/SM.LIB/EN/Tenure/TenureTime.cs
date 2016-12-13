using SM.LIB.EN.School;
using SM.LIB.VM.Account.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LIB.EN.Tenure
{
    public class TenureTime
    {
        public int Id { get; set; }

        [Required]
        public int SchoolProfileId { get; set; }

        public TenureYear TenureYearName { get; set; }

        public DateTime? TenureStartDate { get; set; }

        public DateTime? TenureEndDate { get; set; }

        public bool IsSet { get; set; }
    }
}
