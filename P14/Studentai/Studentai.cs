using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentai
{
     class Studentai
    {
        /// <summary>
        /// KLasė (KONTEINERINĖ) studentų duomenims saugoti
        /// </summary>
        const int Cn = 500;             //studentų masyvo dydis
        private Studentas[] Stud;       //studentų objektų masybas
        public int Kiek { get; set; }   // savybė" studentų skaičius
        /// <summary>
        /// KLlasės kontruktorius: suteikia kintamiesiems reikšmes
        /// </summary>
        public Studentai()
        {
            Kiek = 0;
            Stud = new Studentas[Cn];
        }
        /// <summary>
        /// Grąžina nurodyto indekso studento objektą
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Studentas ImtiStudenta (int i)
        {
            return Stud[i];
        }
        public void DetiStudenta (Studentas stud)
        {
            Stud[Kiek++] = stud;
        }
    }
}
