using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electrical_Device_Shop
{
    public class DeviceComparator
    {
        public virtual int Compare(Device a, Device b)
        {
            return a.CompareTo(b);
        }
    }
}
