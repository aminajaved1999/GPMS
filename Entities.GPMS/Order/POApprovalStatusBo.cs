using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.GPMS
{
    public class POApprovalStatusBo
    {
        public int ID { get; set; }
        public Nullable<int> POMID { get; set; }
        public string Status { get; set; }
        public Nullable<int> StatusByID { get; set; }
        public string StatusBy { get; set; }
        public Nullable<System.DateTime> StatusAt { get; set; }
        public string Remarks { get; set; }
        public string Notes { get; set; }
    }
}
