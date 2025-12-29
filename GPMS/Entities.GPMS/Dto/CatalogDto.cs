using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.GPMS
{
    public class CatalogDto
    {
        public CatalogDto()
        {
            DtoStatusNotes = new DtoStatusNotes();
        }
        public DtoStatusNotes DtoStatusNotes { get; set; }
        public DtoStatus DtoStatus { get; set; }


        public CartonInfoBo CartonInfoBo { get; set; }
        public ColorInfoBo ColorInfoBo { get; set; }
        public CompanyInfoBo CompanyInfoBo { get; set; }
        public CustomerInfoBo CustomerInfoBo { get; set; }
        public PackingInstructionDBo PackingInstructionDBo { get; set; }
        public PackingInstructionMBo PackingInstructionMBo { get; set; }
        public PackingPlanDataBo PackingPlanDataBo { get; set; }
        public PaymentModeInfoBo PaymentModeInfoBo { get; set; }
        public POMBo POMBo { get; set; }
        public SizeInfoBo SizeInfoBo { get; set; }
        public StyleInfoBo StyleInfoBo { get; set; }
        public TermInfoBo TermInfoBo { get; set; }
        public UOMBo UOMBo { get; set; }
        public UserInfoBo UserInfoBo { get; set; }
        public POTypeBo POTypeBo { get; set; }
        public POLevelBo POLevelBo { get; set; }
        public POFormBo POFormBo { get; set; }
        public PackingTypeBo PackingTypeBo { get; set; }
        public ShipmentTermBo ShipmentTermBo { get; set; }

        public List<CartonInfoBo> CartonInfoCollection { get; set; }
        public List<ColorInfoBo> ColorInfoCollection { get; set; }
        public List<CompanyInfoBo> CompanyInfoCollection { get; set; }
        public List<CustomerInfoBo> CustomerInfoCollection { get; set; }
        public List<PackingInstructionDBo> PackingInstructionDCollection { get; set; }
        public List<PackingInstructionMBo> PackingInstructionMCollection { get; set; }
        public List<PackingPlanDataBo> PackingPlanDataCollection { get; set; }
        public List<PaymentModeInfoBo> PaymentModeInfoCollection { get; set; }
        public List<POMBo> POMCollection { get; set; }
        public List<SizeInfoBo> SizeInfoCollection { get; set; }
        public List<StyleInfoBo> StyleInfoCollection { get; set; }
        public List<TermInfoBo> TermInfoCollection { get; set; }
        public List<UOMBo> UOMCollection { get; set; }
        public List<UserInfoBo> UserInfoCollection { get; set; }
        public List<POTypeBo> POTypeCollection { get; set; }
        public List<POLevelBo> POLevelCollection { get; set; }
        public List<POFormBo> POFormCollection { get; set; }
        public List<PackingTypeBo> PackingTypeCollection { get; set; }
        public List<ShipmentTermBo> ShipmentTermCollection { get; set; }

    }
}
