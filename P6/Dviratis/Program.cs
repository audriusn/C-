using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Dviratis
{
    class Dviratis
    {
        private int metai;
        private double kaina;

        public Dviratis(int metai, double kaina)
        {
            this.metai = metai;
            this.kaina = kaina;
        }
        public int ImtiMetus() { return metai; }
        public double ImtiKaina() { return kaina; }
    }
internal class Program
    {
        const int Cn = 100;
        const string CFd = "C:\\Users\\A&T\\Desktop\\BIT\\C#\\P6\\Dviratis\\bin\\Debug\\Duom.txt";
        static void Main(string[] args)
        {
            Dviratis[] D = new Dviratis[Cn];
            int n;
            int am;
            Skaityti(CFd, D, out n, out am);
            // kontrolinio spausdinimo sakiniai tikrinti ar nuskaito faila
            Console.WriteLine("Dviraciu kiekis {0}\n", n);
            Console.WriteLine("Pagaminimo metai         Kaina");
            for (int i = 0; i < n; i++)
                Console.WriteLine("       {0}            {1,7:f2}", D[i].ImtiMetus(), D[i].ImtiKaina());

            // Tinkami naudoti dviraciai
            int kiekTinka;
            double sumaTinka;
            Pinigai(D, n, 0, am, 2015, out kiekTinka, out sumaTinka);
            Console.WriteLine("Tinkami naudoti:{0,3:d}   {1,7:f2}", kiekTinka, sumaTinka);


            int kiekNetinka;
            double sumaNetinka;
            //Netinkami naudoti dviraciai, kuriu amzius didelis
            //t.y intervale nuo m iki begalybes (pvz:. 1000 metu)
            Pinigai(D, n, am+1, 1000, 2015, out kiekNetinka,out sumaNetinka);
            Console.WriteLine("Netinkami naudoti:{0,3:d}   {1,7:f2}", kiekNetinka, sumaNetinka);

            double vidurkisTinka = Vidurkis(D, n, 2015, 0, am);
            if (vidurkisTinka > 0)
                Console.WriteLine("Tinkamu naudoti dviraciu vidutis amzius:   {0, 7:f2}", vidurkisTinka);
            else Console.WriteLine("Tinkamu naudoti dviraciu nera");

            double vidurkisNetinka = Vidurkis(D, n, 2015, am + 1, 1000);
            if (vidurkisNetinka > 0)
                Console.WriteLine("Netinkamu naudoti dviraciu vidutinis amzius:  {0, 7:f2}\n", vidurkisNetinka);
            else
                Console.WriteLine("Netinkamu naudoti dviraciu nera");

            // Programos papildymas
            int sumMetai;
            double sumVerte;
            Pinigai(D, n, 0, 1000, 2015, out sumMetai, out sumVerte);
            Console.WriteLine("Visu dviraciu pinigine verte: {0,7:f2}",sumVerte);
            double visuVidurkis = Vidurkis(D, n, 2015, 0, 1000);
            Console.WriteLine("Visu dviraciu vidutis amzius: {0,7:f2}", visuVidurkis);

            int kiek2012;
            double sum2012;
            Pinigai(D, n, 0, 0, 2012, out kiek2012, out sum2012);
            Console.WriteLine("2012 metais pagamintu dviraciu yra {0,3:d}, ir ju vidutinis amzius yra {1,7:f2}", kiek2012, Vidurkis(D,n, 2015,3,3));

           
            Pinigai(D, n, 0, 0, 1000, out kiek2012, out sum2012);
            Console.WriteLine("1000 metais pagamintu dviraciu yra {0,3:d}, ir ju vidutinis amzius yra {1,7:f2}", kiek2012, Vidurkis(D, n, 2015, 1015, 2015));


            Console.WriteLine("Programa baigė darbą");
        }
        //Metodas nuskaitantis duomenu faila
        static void Skaityti(string fv, Dviratis[] D, out int n, out int m)
        {
            int metai;
            double kaina;
            using (StreamReader reader = new StreamReader(fv))
            {
                string line;
                line = reader.ReadLine();
                string[] parts;
                m = int.Parse(line);
                line = reader.ReadLine();
                n = int.Parse(line);
                for (int i = 0; i < n; i++)
                {
                    line = reader.ReadLine();
                    parts = line.Split(';');
                    metai = int.Parse(parts[0]);
                    kaina = double.Parse(parts[1]);
                    D[i] = new Dviratis(metai, kaina);

                }
            }
        }
        // Metodas skaiciuojantis tinkamo amziaus dviraciu suma ir kieki

        // D - dviraciu duomenys
        // n - dviraciu skaicius
        // amPr - amziaus intervalo prazia
        // amPb - amziaus intervalo pabaiga
        // metai - metai, kuriu atzvilgiu skaiciuojmas amzius
        // kiek -  dviraciu sk duotame intervale
        // suma  - duoto intervato pinigine verte
        static void Pinigai(Dviratis[] D, int n, int amPr, int amPb, int metai, out int kiek, out double suma)
        {
            kiek = 0;
            suma = 0.0;
            int amzius;
            for (int i= 0; i< n; i++)
            {
                amzius = metai - D[i].ImtiMetus();
                if ((amPr<=amzius) && (amzius<=amPb))
                {
                    suma= suma + D[i].ImtiKaina();
                    kiek++;
                }
            }
        }
        //Metodas skaiciuojanti  nurodyto dviraciu amziaus intervalo vidurki
        // D - dviraciu duomenys
        // n - dviraciu skaicius
        // metai - metai, kuriu atzvilgiu skaiciuojmas amzius
        // amPr - amziaus intervalo prazia
        // amPb - amziaus intervalo pabaiga
   
        static double Vidurkis(Dviratis[] D, int n, int metai, int amPr, int amPb)
        {
            int kiek = 0;
            int suma = 0;
            int amzius;
            for (int i= 0;i< n; i++)
            {
                amzius = metai - D[i].ImtiMetus();
                if ((amPr<=amzius) && (amzius<=amPb))
                    {
                    suma = suma + amzius;
                    kiek++;
                }
            }
            if (kiek > 0) return (double)suma / kiek;
            return 0.0;
        }   
    }
}
