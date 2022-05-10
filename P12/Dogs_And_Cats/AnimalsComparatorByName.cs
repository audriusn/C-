using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dogs_And_Cats
{
     class AnimalsComparatorByName : AnimalsComparator
    {
        public override int Compare(Animal a, Animal b)
        {
            int name = a.Name.CompareTo(b.Name);
            if (name == 0)
            {
                return a.ID.CompareTo(b.ID);
            }
            else
            {
                return name;
            }
        }
    }
}
