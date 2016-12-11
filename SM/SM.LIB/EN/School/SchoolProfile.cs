using SM.LIB.VM.Account.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LIB.EN.School
{
    public class SchoolProfile
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public SAddress SAddress { get; set; }
        public int SAddressId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string CPName { get; set; }
        public string CPPhone { get; set; }
        public SBoard Board { get; set; }
        public int TotalStudent { get; set; }
        public SchoolFType SchoolFType { get; set; }
        public SchoolGType SchoolGType { get; set; }
        public SClass SClass { get; set; }
        public DateTime RegistarDate { get; set; }
        public bool IsComplete { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public int SchoolPhoneNumber { get; set; }
        public DateTime AnnulDateOfExam { get; set; }
        public Medium Medium { get; set; }
        public DateTime EstablishedDate { get; set; }
    }
}
