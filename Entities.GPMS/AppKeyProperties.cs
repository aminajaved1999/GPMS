using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.GPMS
{
    public static class AppKeyProperties
    {
        /// <summary>
        /// PO Approval Status -> 
        /// A (Approved),
        /// P (Posted),
        /// D (Rejected)
        /// </summary>
        public static class POApprovalStatus
        {
            public static string Approved { get { return "A"; } } // Approved
            public static string Posted { get { return "P"; } } // Posted
            public static string Rejected { get { return "D"; } } // Rejected
        }
    }
}
