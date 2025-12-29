using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.GPMS
{
    class CommonManager
    {
        public int IncrementUpdatedCount(int? UpdatedCount)
        {
            return UpdatedCount.Value + 1;
        }
    }
}
