using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.GPMS
{
    public class PODBo
    {
        public int ID { get; set; }
        public int POMID { get; set; }
        public int StyleID { get; set; }
        public string Description { get; set; }
        public Nullable<int> CreatedByID { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public Nullable<int> UpdatedByID { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
        public Nullable<int> UpdatedCount { get; set; }
        public string Notes { get; set; }
        public StyleInfoBo StyleInfoBo { get; set; }
        public List<POSizeDBo> POSizeDCollection { get; set; }
        public POMBo POMBo { get; set; }
    }
}
