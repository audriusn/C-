using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Prekes
{
    class Preke
    {
        private string pav;
        private double kaina;
        private int storis;

        public Preke(string pav, double kaina, int storis)
        {
            this.pav = pav;
            this.kaina = kaina;
            this.storis = storis;
        }
        public string ImtiPav() { return pav; }
        public double ImtiKaina() { return kaina; }
        public int ImtiStori() { return storis; }

    }
    internal class Program
    {
        const int Cn = 100;
        const string CFd = "C:\\Users\\A&T\\Desktop\\BIT\\C#\\P6\\Prekes\\bin\\Debug\\Duomenys.txt";
        const string CFd1 = "C:\\Users\\A&T\\Desktop\\BIT\\C#\\P6\\Prekes\\bin\\Debug\\Duomenys2.txt";
        static void Main(string[] args)
        {
            Preke[] P = new Preke[Cn];
            string pavadinimas;
            int n;

            Preke[] P2 = new Preke[Cn];
            string pavadinimas2;
            int n2;

            Skaityti(CFd, P, out n, out pavadinimas);
            Skaityti(CFd1, P2, out n2, out pavadinimas2);

            int minStoris1 = MinStoris(P, n);
            int minStoris2 = MinStoris(P2, n2);

            int maxStoris1 = MaxStoris(P, n);
            int maxStoris2 = MaxStoris(P2, n2);

            int minStorisTotal = MimMinStoris(minStoris1, minStoris2);
            int maxStorisTotal = MaxMaxStoris(maxStoris1, maxStoris2);

            double minKaina1 = MinKaina(P, n);
            double minKaina2 = MinKaina(P2, n2);

            double maxKaina1 = MaxKaina(P, n);
            double maxKaina2 = MaxKaina(P2, n2);

            double minKainaTotal = MimMinKaina(minKaina1, minKaina2);
            double maxKainaTotal = MaxMaxKaina(maxKaina1, maxKaina2);

            int a = 0;
            int b = 0;
            double c = 0;
            Console.WriteLine("Parduotuves gali pasiulyti siltinimo prekiu, kuriu storis nuo {0} cm iki {1} cm", minStorisTotal, maxStorisTotal);
            Console.WriteLine();
            Console.WriteLine("Iveskite minimalu Jusu poreikus atitinkacius medziagu stori:");
            a=int.Parse(Console.ReadLine());
            Console.WriteLine("Iveskite maksimalu Jusu poreikus atitinkacius medziagu stori:");
            b = int.Parse(Console.ReadLine());
            Console.WriteLine("Parduotuves gali pasiulyti siltinimo prekiu, kuriu kaina nuo {0} uz m2 iki {1} uz m2", minKainaTotal, maxKainaTotal);
            Console.WriteLine();
            Console.WriteLine("Iveskite maksimalia Jusu poreikus atitinkacia medziagu kaina:");
            c = int.Parse(Console.ReadLine());

            Preke[] Pr = new Preke[Cn];
            int nr;
            nr = 0;
            Formuoti(P, n, Pr, ref nr, a, b,c);
            Formuoti(P2, n2, Pr, ref nr, a, b, c);
            Console.WriteLine("Prekes pavadinimas      Kaina uz m2          Storis cm ");
            for (int i = 0; i < nr; i++)
                Console.WriteLine("{0,-12}             {1,5:f2}              {2,5:f2}", Pr[i].ImtiPav(), Pr[i].ImtiKaina(), Pr[i].ImtiStori());
        }
        static void Skaityti(string fv, Preke[] P, out int n, out string pavadinimas)
        {
            string pav;
            double kaina;
            int storis;
            using (StreamReader reader = new StreamReader(fv))
            {
                string line;
                line = reader.ReadLine();
                string[] parts;
                pavadinimas = line;
                line = reader.ReadLine();
                n = int.Parse(line);
                for (int i = 0; i < n; i++)
                {
                    line = reader.ReadLine();
                    parts = line.Split(';');
                    pav = parts[0];
                    kaina = double.Parse(parts[1]);
                    storis = int.Parse(parts[2]);
                    P[i] = new Preke(pav, kaina, storis);

                }
            }
        }
        /// <summary>
        /// Randa maziausia stori turincia preke
        /// </summary>
        /// <param name="P"></param>
        /// <param name="n"></param>
        /// <returns> </returns>
        static int MinStoris(Preke[] P, int n)
        {
            int k = 0;
            int ploniausia;
            for (int i = 0; i > n; i++)
                if (P[i].ImtiStori() > P[k].ImtiStori())
                    k = i;
            ploniausia = P[k].ImtiStori();
            return ploniausia;
        }
        /// <summary>
        /// Randa didziauia stori turincia preke
        /// </summary>
        /// <param name="P"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        static int MaxStoris(Preke[] P, int n)
        {
            int k = 0;
            int ploniausia;
            for (int i = 0; i < n; i++)
                if (P[i].ImtiStori() > P[k].ImtiStori())
                    k = i;
            ploniausia = P[k].ImtiStori();
            return ploniausia;
        }

        /// <summary>
        /// Randa kuriame faile maziauias storis
        /// </summary>
        /// <param name="minStoris1"></param>
        /// <param name="minStoris2"></param>
        /// <returns></returns>
        static int MimMinStoris(int minStoris1, int minStoris2)
        {

            if (minStoris1 < minStoris2)
                return minStoris1;
            else
                return minStoris2;
        }

        /// <summary>
        /// Randa kuriame faile didziausias storis
        /// </summary>
        /// <param name="maxStoris1"></param>
        /// <param name="maxStoris2"></param>
        /// <returns></returns>
        static int MaxMaxStoris(int maxStoris1, int maxStoris2)
        {

            if (maxStoris1 > maxStoris2)
                return maxStoris1;
            else
                return maxStoris2;
        }
        /// <summary>
        /// Rnada maziausia kaina sarase
        /// </summary>
        /// <param name="P"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        static double MinKaina(Preke[] P, int n)
        {
            int k = 0;
            double pigiausia;
            for (int i = 0; i > n; i++)
                if (P[i].ImtiKaina() > P[k].ImtiKaina())
                    k = i;
            pigiausia = P[k].ImtiKaina();
            return pigiausia;
        }
        /// <summary>
        /// Randa didziausia kaina sarase
        /// </summary>
        /// <param name="P"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        static double MaxKaina(Preke[] P, int n)
        {
            int k = 0;
            double brangiausia;
            for (int i = 0; i < n; i++)
                if (P[i].ImtiKaina() > P[k].ImtiKaina())
                    k = i;
            brangiausia = P[k].ImtiKaina();
            return brangiausia;
        }
        /// <summary>
        /// Randa kuriame faile yra maaziausia kaina
        /// </summary>
        /// <param name="minKaina1"></param>
        /// <param name="minKaina2"></param>
        /// <returns></returns>
        static double MimMinKaina(double minKaina1, double minKaina2)
        {

            if (minKaina1 < minKaina2)
                return minKaina1;
            else
                return minKaina2;
        }
        /// <summary>
        /// randa, kuriame faile yra didziausia kaina
        /// </summary>
        /// <param name="minKaina1"></param>
        /// <param name="minKaina2"></param>
        /// <returns></returns>
        static double MaxMaxKaina(double minKaina1, double minKaina2)
        {

            if (minKaina1 > minKaina2)
                return minKaina1;
            else
                return minKaina2;
        }

    /// <summary>
    /// Suforuomuoja nauja sarasa pagal vartotojo ivestus parametrus
    /// </summary>
    /// <param name="P"></param>
    /// <param name="n"></param>
    /// <param name="Pr"></param>
    /// <param name="nr"></param>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <param name="c"></param>
        static void Formuoti(Preke[] P, int n, Preke[] Pr, ref int nr, int a, int b, double c)
        {

            for (int i = 0; i < n; i++)
            {

                if (P[i].ImtiStori() >= a && P[i].ImtiStori() <= b && P[i].ImtiKaina()<= c)
                {
                    Pr[nr] = P[i];
                    nr++;
                }
                
            }
        }
    }
   
}
