using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.GPMS
{
    public class OrderDto
    {
        public OrderDto()
        {
            DtoStatusNotes = new DtoStatusNotes();
        }
        public DtoStatusNotes DtoStatusNotes { get; set; }
        public DtoStatus DtoStatus { get; set; }


        public POMBo POMBo { get; set; }
        public PODBo PODBo { get; set; }
        public POSizeDBo POSizeDBo { get; set; }


    }
}
