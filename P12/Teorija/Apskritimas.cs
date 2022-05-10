using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teorija
{
     class Apskritimas : Object
    {
        public double Spindulys { get; private set; }
        public  Apskritimas() // konstruktorius be parametrų
        {
            Spindulys = 1;
        }
        public  Apskritimas(double r) // konstruktorius su parametru
        {
            Spindulys = r;
        }
        public double Plotas()
        {
            return 3.141592653589 * Spindulys * Spindulys;
        }
        public override string ToString() // vietoj Metodo spausdinti()
        {
            return string.Format(" spindulys = {0, 6:f2} ", Spindulys);
        }

    }
}
