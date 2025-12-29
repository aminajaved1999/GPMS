using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.GPMS
{
    public class PackingPlanDataBo
    {
        public int ID { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public string SourceFileName { get; set; }
        public string PONo { get; set; }
        public Nullable<int> GroupNo { get; set; }
        public Nullable<int> GroupCaseQty { get; set; }
        public Nullable<int> ItemQtyPerCase { get; set; }
        public string ItemNo { get; set; }
        public string StoreNo { get; set; }
        public string DC { get; set; }
        public string UccPartners { get; set; }
        public string UccType { get; set; }
        public string UccCoo { get; set; }
        public string Description { get; set; }
        public Nullable<int> CreatedByID { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public Nullable<int> UpdatedByID { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
        public Nullable<int> UpdatedCount { get; set; }
        public string Notes { get; set; }
    }
}
