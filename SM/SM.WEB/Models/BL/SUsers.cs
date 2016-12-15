using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SM.WEB.Models.BL
{
    public class SUsers
    {
        public static string GetCurrentUserId()
        {
            string cu = HttpContext.Current.User.Identity.GetUserId();
            return cu;
        }
    }
}