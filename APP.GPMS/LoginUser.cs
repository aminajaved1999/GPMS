using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.GPMS
{
    public static class LoginUser
    {        
        public static string _userName = "TestUser";
        public static int _userID = 1;
        public static string _userCode = "Test";
        public static string _userFullName = "Test User";

        public static int AppUserCompanyAccessID = 0;
        public static int AppActionGroupID = 0;
        public static int AppMenuGroupID = 0;

        public static int CompanyID = 1;// { get; set; }

    }
    public static class App
    {
        public static string appVersion { get; set; } = "V 0.0.4";
    }
}
