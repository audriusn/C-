using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ObjektuRinkinaiSale
{
    class Kede
    {
        private string pav;
        private double plotas;
        private double kaina;

        public Kede(string pav, double plotas, double kaina)
        {
            this.pav = pav;
            this.kaina = kaina;
            this.plotas = plotas;
        }
        public string ImtiPav() { return pav; }
        public double ImtiPlota() { return plotas; }
        public double ImtiKaina() { return kaina; }

    }
    internal class Program
    {
        const int Cn = 100;
        const string CFd = "C:\\Users\\A&T\\Desktop\\BIT\\C#\\P6\\ObjektuRinkinaiSale\\bin\\Debug\\Duomenys.txt";
        const string CFd1 = "C:\\Users\\A&T\\Desktop\\BIT\\C#\\P6\\ObjektuRinkinaiSale\\bin\\Debug\\Duomenys2.txt";
        static void Main(string[] args)
        {

            Kede[] K = new Kede[Cn];
            string vardas;
            int n;
          
    
           
            Kede[] K2 = new Kede[Cn];
            string vardas2;
            int n2;
          
          
            // pasitikrinam ar nuskaito faila
            Skaityti(CFd, K, out n, out vardas);

            Console.WriteLine("Firma: {0}\n", vardas);
            Console.WriteLine("Skirtingu kedziu skaicius: {0}\n", n);
            Console.WriteLine("Kedes tipas      Plotas          Kaina ");
            for (int i = 0; i < n; i++)
                Console.WriteLine("{0,-12}     {1,5:f2}           {2,5:f2}", K[i].ImtiPav(), K[i].ImtiPlota(), K[i].ImtiKaina());
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine();

            // pasitikrinam ar nuskaito antra faila
            Skaityti(CFd1, K2, out n2, out vardas2);

            Console.WriteLine("Firma: {0}\n", vardas2);
            Console.WriteLine("Skirtingu kedziu skaicius: {0}\n", n2);
            Console.WriteLine("Kedes tipas      Plotas          Kaina ");
            for (int i = 0; i < n2; i++)
                Console.WriteLine("{0,-12}     {1,5:f2}           {2,5:f2}", K2[i].ImtiPav(), K2[i].ImtiPlota(), K2[i].ImtiKaina());
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine();


            // did plotas
            string MaxPlotas = DidPlotas(K, n);
            Console.WriteLine("Didžiausia plota turi: {0,5:f2}", MaxPlotas);
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine();

            // did kaina
            string MaxKaina = DidKaina(K, n);
            Console.WriteLine("Daugiausiai kainuoja: {0,5:f2}", MaxKaina);
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine();

            // surandame kuriame sarase yra brangiausia kede
            double kainaF1 = DidKaina1(K, n);
            double kainaF2 = DidKaina1(K2, n2);

            string BrangiauKede = DidesneKaina(kainaF1, kainaF2, vardas, vardas2);
            Console.WriteLine("Brangiausia kede parduoda imone: {0}", BrangiauKede);
            Console.WriteLine();

            double vidMin=  MinVidPlotas(K, n);
            double vidMax =  MaxVidPlotas(K, n);
            Console.WriteLine("Imones '{0}' vidutines kedes plotas yra tarp: {1,5:f3}  - {2,5:f3} m2", vardas, vidMin, vidMax);
            Console.WriteLine();

            double vidMin2 = MinVidPlotas(K2, n2);
            double vidMax2 = MaxVidPlotas(K2, n2);
            Console.WriteLine("Imones '{0}' vidutines kedes plotas yra tarp: {1,5:f3}  - {2,5:f3} m2", vardas2, vidMin2, vidMax2);
            Console.WriteLine();

            // formuojam nauja sarasa

            Kede[] KV = new Kede[Cn];
            int nr;
            nr = 0;
            Formuoti(K, n, KV, ref nr, vidMin, vidMax);
            Formuoti(K2, n2, KV, ref nr, vidMin2, vidMax2);
            Console.WriteLine("Kedes tipas      Plotas          Kaina ");
            for (int i = 0; i < nr; i++)
                Console.WriteLine("{0,-12}     {1,5:f2}           {2,5:f2}", KV[i].ImtiPav(), KV[i].ImtiPlota(), KV[i].ImtiKaina());

            Console.WriteLine();
            Console.WriteLine("Programa baigė darbą");
        }
        static void Skaityti(string fv, Kede[] K, out int n, out string vardas)
        {
            string pav;
            double plotas;
            double kaina;
            using (StreamReader reader = new StreamReader(fv))
            {
                string line;
                line = reader.ReadLine();
                string[] parts;
                vardas = line;
                line = reader.ReadLine();
                n = int.Parse(line);
                for (int i = 0; i < n; i++)
                {
                    line = reader.ReadLine();
                    parts = line.Split(';');
                    pav = parts[0];
                    plotas = double.Parse(parts[1]);
                    kaina = double.Parse(parts[2]);
                    K[i] = new Kede(pav, plotas, kaina);

                }
            }
        }
        //didžiausios kede plotas. 
        static string DidPlotas(Kede[] K, int n)
        {
            int k = 0;
            string MaxPlotas;
            for (int i = 0; i < n; i++)
                if (K[i].ImtiPlota() > K[k].ImtiPlota())
                    k = i;
            MaxPlotas = K[k].ImtiPav();
            return MaxPlotas;
        }
        //didžiausios kedes kaina. Grazina pavadinima
        static string DidKaina(Kede[] K, int n)
        {
            int k = 0;
            string MaxKaina ;
            double kaina;
            for (int i = 0; i < n; i++)
                if (K[i].ImtiKaina() > K[k].ImtiKaina())
                    k = i;
            MaxKaina = K[k].ImtiPav();
            kaina= K[k].ImtiKaina();
            return MaxKaina;
        }
        //didžiausios kedes kaina. Grazina kaina
        static double DidKaina1(Kede[] K, int n)
        {
            int k = 0;
            double kaina;
            for (int i = 0; i < n; i++)
                if (K[i].ImtiKaina() > K[k].ImtiKaina())
                    k = i;      
            kaina = K[k].ImtiKaina();
            return kaina;
        }
        // randam kuriame sarase yra brangiausia kede
        static string DidesneKaina(double kainaF1, double kainaF2, string vardas, string vardas2)
        {

            if (kainaF1 > kainaF2)
                return vardas;
            else
                return vardas2;
        }
        //didžiausios kedes kaina. Grazina kaina
        static double MinVidPlotas(Kede[] K, int n)
        {
            int k = 0;
            double minPlotas = 0;
            for (int i = 0; i < n; i++)
                minPlotas = minPlotas + K[i].ImtiPlota();
            k++;
            minPlotas = (minPlotas / n) -((minPlotas / n)*0.1);
            return minPlotas;
        }
        static double MaxVidPlotas(Kede[] K, int n)
        {
            int k = 0;
            double maxPlotas = 0;
            for (int i = 0; i < n; i++)
                maxPlotas = maxPlotas + K[i].ImtiPlota();
            k++;
            maxPlotas = (maxPlotas / n) + ((maxPlotas / n) * 0.1);
            return maxPlotas;
        }
        //suformuoti nauja sarasa
        static void Formuoti(Kede[] K, int n, Kede[] KV, ref int nr, double vidMin, double vidMax)
        {
           
            for (int i = 0; i < n; i++)
            {

                if (K[i].ImtiPlota() >= vidMin && K[i].ImtiPlota() <= vidMax)
                {
                    KV[nr] = K[i];
                    nr++;
                }
                
            }
        }
    }
}

