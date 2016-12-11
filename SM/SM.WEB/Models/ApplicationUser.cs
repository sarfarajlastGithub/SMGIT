using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SM.LIB.EN.School;
using SM.LIB.VM.Account.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace SM.WEB.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string CPName { get; set; }
        public string CPPhone { get; set; }
        public SBoard Board { get; set; }
        public int TotalStudent { get; set; }
        public SchoolFType SchoolFType { get; set; }
        public SchoolGType SchoolGType { get; set; }
        public SClass SClass { get; set; }
        public SAddress SAddress { get; set; }
        public int SAddressId { get; set; }
        public DateTime RegistarDate { get; set; }
        public bool IsComplete { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public int SchoolPhoneNumber { get; set; }
        public DateTime? AnnulDateOfExam { get; set; }
        public Medium Medium { get; set; }
        public DateTime? EstablishedDate { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}