using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.GPMS
{
    public class POSizeDBo
    {
        public int ID { get; set; }
        public int PODID { get; set; }
        public int ColorID { get; set; }
        public int SizeID { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public Nullable<int> CreatedByID { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public Nullable<int> UpdatedByID { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
        public Nullable<int> UpdatedCount { get; set; }
        public string Notes { get; set; }
        public Nullable<int> ComboCode { get; set; }
        public Nullable<bool> IsPilotRun { get; set; }
        public string ItemNo { get; set; }

        public ColorInfoBo ColorInfoBo { get; set; }
        public PODBo PODBo { get; set; }
        public SizeInfoBo SizeInfoBo { get; set; }
    }
}
