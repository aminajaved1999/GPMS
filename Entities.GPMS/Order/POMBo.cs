using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.GPMS
{
    public class POMBo
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public string PONo { get; set; }
        public string OriginalPONo { get; set; }
        public System.DateTime POReceivedDate { get; set; }
        public int PaymentModeID { get; set; }
        public int TermID { get; set; }
        public int ShippingMethodID { get; set; }
        public int ShipmentTermID { get; set; }
        public int POFromID { get; set; }
        public int POTypeID { get; set; }
        public int POLevelID { get; set; }
        public int PackingTypeID { get; set; }
        public Nullable<System.DateTime> POStartDate { get; set; }
        public string POStatus { get; set; }
        public string GarmentDescription { get; set; }
        public string BillTo { get; set; }
        public string Season { get; set; }
        public Nullable<int> RivisionNo { get; set; }
        public Nullable<System.DateTime> LastRevisionDate { get; set; }
        public string ClosingDate { get; set; }
        public string ClosedBy { get; set; }
        public Nullable<System.DateTime> ShipDate { get; set; }
        public Nullable<System.DateTime> ShipRequestDate { get; set; }
        public string Description { get; set; }
        public Nullable<int> CreatedByID { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public Nullable<int> UpdatedByID { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
        public Nullable<int> UpdatedCount { get; set; }
        public string Notes { get; set; }
        public string ApprovedStatus { get; set; }
        public Nullable<System.DateTime> ApprovedAt { get; set; }
        public CustomerInfoBo CustomerInfoBo { get; set; }
        public PackingTypeBo PackingTypeBo { get; set; }
        public PaymentModeInfoBo PaymentModeInfoBo { get; set; }
        public List<PODBo> PODCollection { get; set; }
        public POFromBo POFormBo { get; set; }
        public POLevelBo POLevelBo { get; set; }
        public POTypeBo POTypeBo { get; set; }
        public ShipmentTermBo ShipmentTermBo { get; set; }
        public ShippingMethodBo ShippingMethodBo { get; set; }
        public TermInfoBo TermInfoBo { get; set; }
    }
}
