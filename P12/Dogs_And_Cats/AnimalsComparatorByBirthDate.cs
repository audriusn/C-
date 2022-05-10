using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dogs_And_Cats
{
    internal class AnimalsComparatorByBirthDate : AnimalsComparator
    {
        public override int Compare(Animal a, Animal b)
        {
            int birthCompare = a.BirthDate.CompareTo(b.BirthDate);
            if (birthCompare == 0)
            {
                return a.ID.CompareTo(b.ID);
            }
            else
            {
                return birthCompare;
            }
        }
    }
}
