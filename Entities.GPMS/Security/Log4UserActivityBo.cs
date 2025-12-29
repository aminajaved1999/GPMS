using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.GPMS 
{
    public class Log4UserActivityBo
    {
        public int Id { get; set; }
        public Nullable<int> ActionByUserId { get; set; }
        public string Action { get; set; }
        public string UserIpAddress { get; set; }
        public string BrowserName { get; set; }
        public string MachineName { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
    }
}
