using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Turistai
{
    class Turistai
    {
        private string vardas;
        private double eurai;


        public Turistai (string vardas, double eurai)
        {
            this.vardas = vardas;
            this.eurai = eurai;
           
        }
        public string ImtiVarda() { return vardas; }
        public double ImtiEurus() { return eurai; }
  
    }
    internal class Program
    {
        const int Cn = 100;
        const string CFd = "C:\\Users\\A&T\\Desktop\\BIT\\C#\\P6\\Turistai\\bin\\Debug\\Duomenys.txt";
        static void Main(string[] args)
        {
            Turistai[] T = new Turistai[Cn];
            int n;
            Skaityti(CFd, T, out n);

            // kontrolinio spausdinimo sakiniai tikrinti ar nuskaito faila
            Console.WriteLine("Turistu skaicius {0}\n", n);
            Console.WriteLine("Turisto vardas     Turimi Eurai");
            for (int i = 0; i < n; i++)
                Console.WriteLine("{0, -12}             {1,7:f2}", T[i].ImtiVarda(), T[i].ImtiEurus());

            Console.WriteLine();

            // Skaiciuojame kiek grupes turimus pinigus
            int grupesKiekis;
            double grupesEurai;
            Pinigai(T, n, out grupesKiekis,out grupesEurai);
            Console.WriteLine("Visa grupe turi: {0,7:f2}", grupesEurai);
            Console.WriteLine();

            //Skaiciuojame kiek vienam turistui tenka vidutiniskai
            double EuruVidurkis = Vidurkis(T, n, out grupesKiekis,out EuruVidurkis);
            Console.WriteLine("Vidutiniškai kiekvienas sutentas turi po: {0,7:f2}", EuruVidurkis);

            //Skaiciuojame islaidu suma
            double islaiduSum;
            IslaiduSuma(T, n, out grupesKiekis, out islaiduSum);
            Console.WriteLine("Išlaidu suma: {0,7:f2}", islaiduSum);


            Console.WriteLine("Programa baige darbą!");
        }
        //Metodas nuskaitantis duomenu faila
        // n- turistu skaicius
        static void Skaityti(string fv, Turistai[] T, out int n)
        {
            string vardas;
            double eurai;
            using (StreamReader reader = new StreamReader(fv))
            {
                string line;
                string[] parts;
                line = reader.ReadLine();
                n = int.Parse(line);
                for (int i = 0; i < n; i++)
                {
                    line = reader.ReadLine();
                    parts = line.Split(';');
                    vardas = parts[0];
                    eurai = double.Parse(parts[1]);
                    T[i] = new Turistai(vardas, eurai);

                }
            }
        }
        // Metodas skaiciuojanti pinigu suma
        static void Pinigai(Turistai[] T, int n, out int kiek, out double suma)
        {
            kiek = 0;
            suma = 0.0;
            for (int i = 0; i < n; i++)
            {
                    suma = suma + T[i].ImtiEurus();
                    kiek++;
                }
            }
        // Metodas skaiciuojantis pinigu vidurki
        static double Vidurkis(Turistai[] T, int n, out int kiek, out double suma)
        {
            kiek = 0;
            suma = 0;
            for (int i = 0; i < n; i++)
            {
                suma = suma + T[i].ImtiEurus();
                kiek++;
            }
            if (kiek > 0) return (double)suma / kiek;
            return 0.0;
        }
        //Metodas skaiciuojantis bendra turistu piginu suma išlaidoms
        static void IslaiduSuma(Turistai[] T, int n, out int kiek, out double suma)
        {
            kiek = 0;
            suma = 0;
            for (int i = 0; i < n; i++)
            {
                suma = suma + Math.Floor((T[i].ImtiEurus()/4));
                kiek++;
            }
        }
    }   
}

