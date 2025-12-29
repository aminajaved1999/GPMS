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
        public Nullable<int> ColorID { get; set; }
        public Nullable<int> StyleID { get; set; }
        public Nullable<int> SizeID { get; set; }
        public Nullable<int> ItemQtyPerCase { get; set; }
        public string SequenceNo { get; set; }
        public string StoreNo { get; set; }
        public string DC { get; set; }
        public Nullable<System.DateTime> ScanDate { get; set; }
        public string Description { get; set; }
        public Nullable<int> CreatedByID { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public Nullable<int> UpdatedByID { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
        public Nullable<int> UpdatedCount { get; set; }
        public string Notes { get; set; }
        public virtual ColorInfoBo ColorInfoBo { get; set; }
        public virtual PackingInstructionMBo PackingInstructionMBo { get; set; }
        public virtual SizeInfoBo SizeInfoBo { get; set; }
        public virtual StyleInfoBo StyleInfoBo { get; set; }

    }
}
