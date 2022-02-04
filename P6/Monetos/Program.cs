using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Monetos
{
    class Moneta
    {
        private string salis;
        private int nominalas;
        private double svoris;

        public Moneta(string salis, int nominalas, double svoris)
        {
            this.salis = salis;
            this.nominalas = nominalas;
            this.svoris = svoris;
        }
        public string ImtiSali() { return salis; }
        public int ImtiNominala() { return nominalas; }
        public double ImtiSvori() { return svoris; }

    }
    internal class Program
    {
        const int Cn = 100;
        const string CFd = "C:\\Users\\A&T\\Desktop\\BIT\\C#\\P6\\Monetos\\bin\\Debug\\Duomenys.txt";
        const string CFd1 = "C:\\Users\\A&T\\Desktop\\BIT\\C#\\P6\\Monetos\\bin\\Debug\\Duomenys2.txt";
        static void Main(string[] args)
        {
            Moneta[] M = new Moneta[Cn];
            string vardas;
            int n;

            // pasitikrinam ar nuskaito faila
            Skaityti(CFd, M, out n, out vardas);

            Console.WriteLine("Kolekcionierius: {0}\n", vardas);
            Console.WriteLine("Skirtingu monetu skaicius: {0}\n", n);
            Console.WriteLine("Kilmes salis:      Nominalas:       Svoris: ");
            for (int i = 0; i < n; i++)
                Console.WriteLine("{0,-12}         {1}            {2,5:f1}", M[i].ImtiSali(), M[i].ImtiNominala(), M[i].ImtiSvori());
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine();


            // Sunkiausia moneta
            double sunkiausia = SunkiausiaMoneta(M, n);
            Console.WriteLine("Sunkiausia moneta sveria: {0,5:f1} gramus", sunkiausia);
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine();

            // Monetu verte
            int verte1 = MonetuVerte(M, n);
            Console.WriteLine("Kolekcionieriaus '{0}' turimu monetu verte: {1} centai",vardas, verte1);
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine();

            Moneta[] M2 = new Moneta[Cn];
            string vardas2;
            int n2;

            // pasitikrinam ar nuskaito antra  faila
            Skaityti(CFd1, M2, out n2, out vardas2);

            Console.WriteLine("Kolekcionierius: {0}\n", vardas2);
            Console.WriteLine("Skirtingu monetu skaicius: {0}\n", n2);
            Console.WriteLine("Kilmes salis:      Nominalas:       Svoris: ");
            for (int i = 0; i < n2; i++)
                Console.WriteLine("{0,-12}         {1}             {2,5:f1}", M2[i].ImtiSali(), M2[i].ImtiNominala(), M2[i].ImtiSvori());
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine();

            //Kuris turi didesni nominala
            int did1=didNominalas(M, n);
            int did2=didNominalas(M2, n2);
            string maxNominalasSavininkas = DidesneMoneta(did1, did2, vardas, vardas2);
            Console.WriteLine("Didziausio moninalo moneta turi: {0}", maxNominalasSavininkas);
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine();


            // kuris turi didesne verte nominalais
            int verte2 = MonetuVerte(M2, n2);
            string turtingiausiasSavininkas = DidesneVerte(verte1, verte2, vardas, vardas2);
            Console.WriteLine("Didziausio moninalo moneta turi: {0}", turtingiausiasSavininkas);
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine();

            Moneta[] M1 = new Moneta[Cn];
            int nr;
            nr = 0;
            Formuoti(M, n, M1, ref nr);
            Formuoti(M2, n2, M1, ref nr);
            Console.WriteLine("Kilmes salis:      Nominalas:       Svoris: ");
            for (int i = 0; i < nr; i++)
                Console.WriteLine("{0,-12}        {1}              {2,5:f2}", M1[i].ImtiSali(), M1[i].ImtiNominala(), M1[i].ImtiSvori());

            Console.WriteLine();
            Console.WriteLine("Programa baigė darbą");
        }
      
      
        static void Skaityti(string fv, Moneta[] M, out int n, out string vardas)
        {
            string salis;
            int nominalas;
            double svoris;
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
                    salis = parts[0];
                    nominalas = int.Parse(parts[1]);
                    svoris = double.Parse(parts[2]);
                    M[i] = new Moneta(salis, nominalas, svoris);

                }
            }
        }
        // sunkiausios monetos paieska
        static double SunkiausiaMoneta(Moneta[] M, int n)
        {
            int k = 0;
            double sunkiausia;
            for (int i = 0; i < n; i++)
                if (M[i].ImtiSvori() > M[k].ImtiSvori())
                    k = i;
            sunkiausia = M[k].ImtiSvori();
            return sunkiausia;
        }
        // visu monetu verte
        static int MonetuVerte(Moneta[] M, int n)
        {
            int suma = 0;
            for (int i = 0; i < n; i++)
                suma = suma + M[i].ImtiNominala();
            return suma;
        }
        // didiausias nominalas
        static int didNominalas(Moneta[] M, int n)
        {
            int k = 0;
            int didN;
            for (int i = 0; i < n; i++)
                if (M[i].ImtiNominala() > M[k].ImtiNominala())
                    k = i;
            didN = M[k].ImtiNominala();
            return didN;
        }
        // didesnis nominalas
        static string DidesneMoneta(int did1, int did2, string vardas, string vardas2)
        {

            if (did1 > did2)
                return vardas;
            else
                return vardas2;
        }
        // didesnis verte nominalais
        static string DidesneVerte(int verte1, int verte2, string vardas, string vardas2)
        {

            if (verte1 > verte2)
                return vardas;
            else
                return vardas2;
        }
        static void Formuoti(Moneta[] M, int n, Moneta[] M1, ref int nr)
        {

            for (int i = 0; i < n; i++)
            {

                if (M[i].ImtiNominala()==1)
                {
                    M1[nr] = M[i];
                    nr++;
                }

            }
        }
    }
}
