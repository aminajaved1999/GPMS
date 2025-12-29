using System;
using System.Collections.Generic;
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
     
    }
}
