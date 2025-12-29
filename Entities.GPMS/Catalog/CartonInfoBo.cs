using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.GPMS
{
    public class CartonInfoBo
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public string CartonCode { get; set; }
        public string CartonName { get; set; }
        public decimal Length { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public decimal CBM { get; set; }
        public int LengthUomID { get; set; }
        public int WidthUomID { get; set; }
        public int HeightUomID { get; set; }
        public int WeightUomID { get; set; }
        public int CBMUomID { get; set; }
        public int Priority { get; set; }
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
    }
}
