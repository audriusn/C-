using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentaiListMenu
{
     class Pazymys
    {
        public int Pazym { get; set; }
        public string PazZodr { get; set; }
        public Pazymys(int paz, string pazR)
        {
            this.Pazym = paz;
            this.PazZodr = pazR;
        }
        public override string ToString()
        {
            string eilute;
            eilute = string.Format("{0,2:d} {1,-15}", Pazym, PazZodr);
            return eilute;
        }
    }
}
