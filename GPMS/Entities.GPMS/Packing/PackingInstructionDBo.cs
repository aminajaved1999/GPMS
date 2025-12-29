using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.GPMS
{
    public class PackingInstructionDBo
    {
        public int ID { get; set; }
        public int PackingInstructionMID { get; set; }
        public string ItemNo { get; set; }
        public string UPC { get; set; }
        public int UOMID { get; set; }
        public string Color { get; set; }
        public string Style { get; set; }
        public string Size { get; set; }
        public Nullable<int> SizePackPCsQty { get; set; }
        public string SequenceNo { get; set; }
        public string StoreNo { get; set; }
        public string DC { get; set; }
        public Nullable<System.DateTime> ScanDate { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
        public Nullable<int> UpdatedCount { get; set; }
        public string Notes { get; set; }
    }
}
