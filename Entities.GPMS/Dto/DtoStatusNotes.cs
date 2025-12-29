using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.GPMS
{
    public class DtoStatusNotes
    {
        public DtoStatusNotes()
        {
            ExtraNotes = new List<string>();
        }
        public string Exception { get; set; }
        public string StackTrace { get; set; }
        public List<string> ExtraNotes { get; set; }
    }
}
