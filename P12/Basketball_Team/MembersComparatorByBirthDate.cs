using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basketball_Team
{
    internal class MembersComparatorByBirthDate : MembersComparator
    {
        public override int Compare(Member a, Member b)
        {
            int birthCompare = a.BirthDate.CompareTo(b.BirthDate);
            if (birthCompare == 0)
            {
                return a.Name.CompareTo(b.Name);
            }
            else
            {
                return birthCompare;
            }
        }
    }
}
