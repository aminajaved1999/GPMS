using Entities.GPMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.GPMS
{
    public class LogManager : DbBase
    {
        private static string clientIPAddress;
        public string ClientIPAddress
        {
            set { clientIPAddress = value; }
        }
        void AddLogUserActivity (Log4UserActivityBo pUserActivity)
        {
            try
            {
                var logUserAction = new MODEL.GPMS.Log4UserActivity();
                logUserAction.ActionByUserId = pUserActivity.ActionByUserId;
                logUserAction.Action = pUserActivity.Action;
                logUserAction.UserIpAddress = pUserActivity.UserIpAddress;
                logUserAction.MachineName = pUserActivity.MachineName;
                logUserAction.CreatedAt = DateTime.Now;
                EntitiesContext.Log4UserActivity.Add(logUserAction);
                EntitiesContext.SaveChanges();
            }
            catch { }
        }

        public void LogUserAction(string action,int pLoginUserId)
        {
            try
            {
                if (!string.IsNullOrEmpty(action))
                {
                    var userActivity = new Log4UserActivityBo();
                    userActivity.Action = action;
                    if (clientIPAddress != null)
                        userActivity.UserIpAddress = clientIPAddress;
                    else
                        userActivity.UserIpAddress = "0.0.0.0";
                    
                    userActivity.ActionByUserId = pLoginUserId;
                    AddLogUserActivity(userActivity);
                }
            }
            catch { }
        }

    }
}
