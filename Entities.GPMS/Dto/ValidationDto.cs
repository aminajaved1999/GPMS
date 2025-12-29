using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.GPMS
{
    public class ValidationDto
    {
        public ValidationDto()
        {
            DtoStatusNotes = new DtoStatusNotes();
        }
        public DtoStatusNotes DtoStatusNotes { get; set; }
        public DtoStatus DtoStatus { get; set; }

        public bool? IsExist { get; set; }

    }
}
