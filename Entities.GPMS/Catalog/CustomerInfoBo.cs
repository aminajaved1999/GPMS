using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.GPMS
{
    public class CustomerInfoBo
    {
        public int ID { get; set; }
        public int CompanyID { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string ShortName { get; set; }
        public string PreFix { get; set; }
        public string Address { get; set; }
        public string BillingAddress { get; set; }
        public string PhoneNo { get; set; }
        public string EMail { get; set; }
        public string FAX { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
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
        public string SupplierNo { get; set; }
        public CompanyInfoBo CompanyInfoBo { get; set; }
        public List<POMBo> POMCollection { get; set; }
    }
}
