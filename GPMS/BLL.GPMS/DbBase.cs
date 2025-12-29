using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL.GPMS;


namespace BLL.GPMS
{
    public class DbBase
    {
        protected GPMSEntities EntitiesContext;
        public DbBase()
        {
            if (EntitiesContext == null)
            {
                EntitiesContext = new GPMSEntities();
            }

        }
    }
}
