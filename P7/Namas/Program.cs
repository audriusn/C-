using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Namas
{
    class Butas
    {
        private int nr;
        private double plotas;
        private int kambariai;
        private int kaina;
        private int telNr;

        public Butas(int nr, double plotas, int kambariai, int kaina, int telNr)
        {
            this.nr = nr;
            this.plotas = plotas;
            this.kambariai = kambariai;
            this.kaina = kaina;
            this.telNr = telNr;
        }
         public override string ToString()
        {
            string eilute;
            eilute = string.Format("{0,3} {1,10} {2, 5:d} {3, 14:d} {4, 13:d}", nr, plotas, kambariai, kaina, telNr);
            return eilute;
        }
       
        public int ImtiKambSk() { return kambariai; }
        public int ImtiKaina() { return kaina; }
 
    }
    class Namas
    {
        const int Cmaxi = 100;
        private Butas[] Butai;
        private int n;
        public Namas()
        {
            n = 0;
            Butai = new Butas[Cmaxi];
        }
       
        public Butas Imti(int i) { return Butai[i]; }

        public int Imti() { return n; }
        public void Dėti(Butas b) { Butai[n++] = b; }

    }
    internal class Program
    {
        const string CFd = "C:\\Users\\A&T\\Desktop\\BIT\\C#\\P7\\Namas\\bin\\Debug\\Duomenys.txt";
        static void Main(string[] args)
        {
            Namas namas = new Namas();
            Skaityti(ref namas, CFd);
            Spausdinti(namas);

            Namas namasN = new Namas();
            int kiek;
            Console.Write("Iveskite norimu kambariu skaičių: ");
            kiek = int.Parse(Console.ReadLine());

            int maxkaina;
            Console.WriteLine("Iveskite maksimalia kainą:");
            maxkaina = int.Parse(Console.ReadLine());
            Formuoti(namas, ref namasN, kiek, maxkaina);
            Spausdinti(namasN);
        }
        /// <summary>
        /// Nuskaito faila
        /// </summary>
        /// <param name="namas"></param>
        /// <param name="fv"></param>
        static void Skaityti(ref Namas namas, string fv)
        {
            int nr, kambariai, kaina, telNr,n;
            double plotas;
            string line;
            using (StreamReader reader = new StreamReader(fv))
            {
                n = int.Parse(reader.ReadLine());
                for (int i = 0; i < n; i++)
                {
                    line = reader.ReadLine();
                    string[] parts = line.Split(';');
                    nr = int.Parse(parts[0]);
                    plotas = double.Parse(parts[1]);
                    kambariai = int.Parse(parts[2]);
                    kaina = int.Parse(parts[3]);
                    telNr = int.Parse(parts[4]);
                    Butas b = new Butas(nr, plotas, kambariai, kaina, telNr);
                    namas.Dėti(b);
                }
            }
        }
        /// <summary>
        /// Spausdina sarasa
        /// </summary>
        /// <param name="namas"></param>
        static void Spausdinti(Namas namas)
        {

            string virsus = " Informacija apie parduodamus butus \r\n"
            + " ----------------------------------------------------- \r\n"
            + " Nr.   Plotas    KambSK      Kaina      Tel.Nr: \r\n"
            + " ----------------------------------------------------- ";
            Console.WriteLine(virsus);
            for (int i = 0; i < namas.Imti(); i++)
                Console.WriteLine("{0}", namas.Imti(i).ToString());
            Console.WriteLine(" --------------------------------------- \n\n");
        }
        /// <summary>
        /// Randa butus pagal nurodytus parametrus
        /// </summary>
        /// <param name="namas"></param>
        /// <param name="namasN"></param>
        /// <param name="kiek"></param>
        /// <param name="maxkaina"></param>
        static void Formuoti(Namas namas, ref Namas namasN, int kiek, int maxkaina)
        {
            for (int i = 0; i < namas.Imti(); i++)
            {
                if (namas.Imti(i).ImtiKambSk() == kiek && namas.Imti(i).ImtiKaina()< maxkaina)
                    namasN.Dėti(namas.Imti(i));             
            }
        }
    }
}
