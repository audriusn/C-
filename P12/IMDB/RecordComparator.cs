using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB
{
    public class RecordComparator
    {
        public virtual int Compare(Record a, Record b)
        {
            return a.CompareTo(b);
        }
    }
}
