using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.GPMS
{
    public class GeneralAttributesClass
    {
        public int ID;
        public string Code;
        public string Name;
        public string Extra;
    }

    public enum GeneralPopupSelectionType
    {
        Select,
        Customer,
        Style,
        Size,
        Color

    }
}
