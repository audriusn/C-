using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuristuInformacijosCentras
{
     class Museum
    {
        public string pavadinimas { get; set; }
        public string miestas { get; set; }
        public string tipas { get; set; }
        public int pirmadienis { get; set; }
        public int antradienis { get; set; }
        public int treciadienis { get; set; }
        public int ketvirtadienis { get; set; }
        public int penktadienis { get; set; }
        public int sestadienis { get; set; }
        public int sekmadienis { get; set; }
        public double kaina { get; set; }
        public Guide Guide { get; set; }

        public Museum(string pavadinimas, string miestas, string tipas, int pirmadienis, int antradienis, int treciadienis, int ketvirtadienis,
            int penktadienis, int sestadienis, int sekmadienis, double kaina, Guide Guide)
        {
            this.pavadinimas = pavadinimas;
            this.miestas = miestas;
            this.tipas = tipas;
            this.pirmadienis = pirmadienis;
            this.antradienis = antradienis;
            this.treciadienis = treciadienis;
            this.ketvirtadienis = ketvirtadienis;
            this.penktadienis = penktadienis;
            this.sestadienis = sestadienis;
            this.sekmadienis = sekmadienis;
            this.kaina = kaina;
            this.Guide = Guide;
        }
        public override string ToString()
        {
            string eilute;
            eilute = string.Format("{0,-20} {1,2} {2} {3} {4} {5} {6} {7} {8} {9} {10} {11}", pavadinimas, miestas, tipas, pirmadienis, antradienis, treciadienis, ketvirtadienis, penktadienis, sestadienis,sekmadienis,kaina, Guide);
            return eilute;
        }
    }
}
