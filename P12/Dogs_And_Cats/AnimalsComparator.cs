using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dogs_And_Cats
{
    public class AnimalsComparator
    {
        public virtual int Compare(Animal a, Animal b)
        {
            return a.CompareTo(b);
        }
    }
}
