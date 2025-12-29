using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.GPMS
{
    public class ColorInfoBo
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public string ColorCode { get; set; }
        public string ColorName { get; set; }
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
        public List<POSizeDBo> POSizeDCollection { get; set; }
    }
}
