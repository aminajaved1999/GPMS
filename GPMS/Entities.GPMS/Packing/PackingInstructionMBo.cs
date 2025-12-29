using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.GPMS
{
    public class PackingInstructionMBo
    {
        public int ID { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public Nullable<int> OrderID { get; set; }
        public string PONo { get; set; }
        public string Status { get; set; }
        public string BoxBarcode { get; set; }
        public Nullable<decimal> CaseGrossWeight { get; set; }
        public Nullable<decimal> CaseCBM { get; set; }
        public string ContainerNo { get; set; }
        public Nullable<int> CartonSequence { get; set; }
        public string MarkFor { get; set; }
        public string StoreNo { get; set; }
        public string DC { get; set; }
        public string UsageIndicator { get; set; }
        public string UccPO { get; set; }
        public string UccDept { get; set; }
        public string UccStyle { get; set; }
        public string UccColor { get; set; }
        public string UccSize { get; set; }
        public string UccPartners { get; set; }
        public string UccType { get; set; }
        public string UccCoo { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
        public Nullable<int> UpdatedCount { get; set; }
        public string Notes { get; set; }
    }
}
