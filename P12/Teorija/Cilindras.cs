using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teorija
{
     class Cilindras : Apskritimas
    {
        public double Aukstine { get; private set; }
        public Cilindras() : base() // konstruktorius be parametrų
        {
            Aukstine = 1;
        }
        public Cilindras(double r, double h) : base(r) // konstruktorius su parametrais
        {
            Aukstine = h;
        }
        public double Turis()
        {
            return Plotas() * Aukstine;
        }
        public override string ToString() // vietoj Metodo spausdinti()
        {
            return string.Format("{0} aukštinė = {1, 6:f2}", base.ToString(), Aukstine);
        }
    }
}
