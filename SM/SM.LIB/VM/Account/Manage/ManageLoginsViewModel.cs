using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using Microsoft.Owin.Security;

namespace SM.LIB.VM.Account.Manage
{
    public class ManageLoginsViewModel
    {
        public IList<UserLoginInfo> CurrentLogins { get; set; }
        public IList<AuthenticationDescription> OtherLogins { get; set; }
    }
}
