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
        public SchoolFType schoolFType { get; set; }
        public SchoolGType schoolGType { get; set; }
        public SClass sClass { get; set; }
        public SAddress sAddress { get; set; }
        public int sAddressId { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}