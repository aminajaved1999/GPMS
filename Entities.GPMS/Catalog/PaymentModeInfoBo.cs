using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.GPMS
{
    public class PaymentModeInfoBo
    {
        public int ID { get; set; }
        public string PaymentModeCode { get; set; }
        public string PaymentModeName { get; set; }
        public Nullable<int> Days { get; set; }
        public Nullable<int> PenaltyPercentage { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public Nullable<int> CreatedByID { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public Nullable<int> UpdatedByID { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
        public Nullable<int> UpdatedCount { get; set; }
        public string Notes { get; set; }
        public List<POMBo> POMCollection { get; set; }
    }
}
