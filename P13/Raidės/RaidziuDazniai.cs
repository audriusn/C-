using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raidės
{
     class RaidziuDazniai
    {
        private const int Cmax = 256;
        private int[] Rn; // Raidžių pasikartojimai
        public string eil { get; set; }
        public RaidziuDazniai()
        {
            eil = "";
            Rn = new int[Cmax];
            for (int i = 0; i < Cmax; i++)
                Rn[i] = 0;
        }
        public int Imti (char sim)
        {
            return Rn[sim];
        }
        public void kiek()
        {
            for (int i = 0;i < eil.Length;i++)
            {
                if (('a'<=eil[i] && eil[i] <='z') || ('A'<=eil[i] && eil[i] <= 'Z'))
                {
                    Rn[eil[i]]++;
                }
            }
        }
    }
}
