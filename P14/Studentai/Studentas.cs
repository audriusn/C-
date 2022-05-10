using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentai
{
     class Studentas
    {
        public string PavVrd { get; set; }
        public int Pazym { get; set; }

        public Studentas(string PavVrd, int Pazym)
        {
           this.PavVrd = PavVrd;
           this.Pazym = Pazym;
        }
        public override string ToString()
        {
            string eilute;
            eilute = string.Format("{0, -20}   {1,2}", PavVrd, Pazym);
            return eilute;
        }
    }
}
