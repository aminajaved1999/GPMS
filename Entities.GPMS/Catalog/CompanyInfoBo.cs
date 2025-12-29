using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.GPMS
{
    public class CompanyInfoBo
    {

        public int ID { get; set; }
        public string CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public string ShortName { get; set; }
        public string DisplayName { get; set; }
        public string PreFix { get; set; }
        public string Email { get; set; }
        public string FAX { get; set; }
        public string WebURL { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public string PhoneNo { get; set; }
        public string LogoPath { get; set; }
        public string Description { get; set; }
        public string Since { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
        public Nullable<int> UpdatedCount { get; set; }
        public string Notes { get; set; }
        public int CreatedByID { get; set; }
        public int UpdatedByID { get; set; }
        public List<CustomerInfoBo> CustomerInfoCollection { get; set; }
        
    }
}
