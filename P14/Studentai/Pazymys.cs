using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentai
{
     class Pazymys
    {
        public int Pazym { get; set; }      // savybė: pažymys (skaičius: 1..10)
        public string PazZodr { get; set; } // savybė: pažymio žodinė reikšmė
        /// <summary>
        /// Klasės konstruktorius: savybėms suteikia reikšmes.
        /// </summary>
        /// <param name="Pazym"></param>
        /// <param name="PazZodr"></param>
        public Pazymys(int Pazym, string PazZodr)
        {
            this.Pazym = Pazym;
            this.PazZodr = PazZodr;
        }
    }
}
