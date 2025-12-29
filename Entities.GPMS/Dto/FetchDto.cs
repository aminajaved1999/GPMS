using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.GPMS
{
    public class FetchDto
    {
        public FetchDto()
        {
            DtoStatusNotes = new DtoStatusNotes();
        }
        public List<CompanyInfoBo> CompanyInfoCollection { get; set; }
        public List<CustomerInfoBo> CustomerInfoCollection { get; set; }
        public List<StyleInfoBo> StyleInfoCollection { get; set; }
        public List<SizeInfoBo> SizeInfoCollection { get; set; }
        public List<ColorInfoBo> ColorInfoCollection { get; set; }
        public int TotalCount { get; set; }
        public int SelectedCount { get; set; }

        public List<BoardEntryKeyValue> BoardEntries { get; set; }
        public DtoStatusNotes DtoStatusNotes  { get; set; }
        public DtoStatus DtoStatus { get; set; }
    }
    public class BoardEntryKeyValue
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
    }
}
