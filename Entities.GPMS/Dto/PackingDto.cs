using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.GPMS
{
    public class PackingDto
    {
        public PackingDto()
        {
            DtoStatusNotes = new DtoStatusNotes();
        }
        public DtoStatusNotes DtoStatusNotes { get; set; }
        public DtoStatus DtoStatus { get; set; }

        public PackingInstructionDBo PackingInstructionDBo { get; set; }
        public PackingInstructionMBo PackingInstructionMBo { get; set; }
        public PackingPlanDataBo PackingPlanDataBo { get; set; }

        public List<PackingInstructionDBo> PackingInstructionDList { get; set; }
        public List<PackingInstructionMBo> PackingInstructionMList { get; set; }
        public List<PackingPlanDataBo> PackingPlanDataList { get; set; }
        public DataTable DataTable { get; set; }


    }
}
