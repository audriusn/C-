using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electrical_Device_Shop
{
    internal class DeviceComparatorByPrice : DeviceComparator
    {
        public override int Compare(Device a, Device b)
        {
            int PriceCompare = a.Price.CompareTo(b.Price);
            if (PriceCompare == 0)
            {
                return a.Brand.CompareTo(b.Brand);
            }
            else
            {
                return PriceCompare;
            }
        }
    }
}
