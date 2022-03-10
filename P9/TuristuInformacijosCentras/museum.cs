using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

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
    }
}
