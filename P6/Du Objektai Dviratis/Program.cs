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
        

        public Dviratis( int metai, double kaina)
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
        const string CFd1 = "C:\\Users\\A&T\\Desktop\\BIT\\C#\\P6\\Du Objektai Dviratis\\bin\\Debug\\Duom1.txt";
        const string CFd2 = "C:\\Users\\A&T\\Desktop\\BIT\\C#\\P6\\Du Objektai Dviratis\\bin\\Debug\\Duom2.txt";
        static void Main(string[] args)
        {
            Dviratis[] D1 = new Dviratis[Cn];
            int n1;
            int am1;
            string pav1;
            Skaityti(CFd1, D1, out n1, out am1, out pav1);
            int kiekTinka1, kiekNetinka1;
            double sumaTinka1, sumaNetinka1, suma1;

            // Sukuriam papildoma objekta

            Dviratis[] D2 = new Dviratis[Cn];
            int n2;
            int am2;
            string pav2;
            Skaityti(CFd2, D2, out n2, out am2, out pav2);
            int kiekTinka2, kiekNetinka2;
            double sumaTinka2, sumaNetinka2, suma2;


            // tikrininam ar nuskaito failus
            Console.WriteLine("Dviraciu nuomos punktas: {0}\n", pav1);
            Console.WriteLine("Dviraciu kiekis {0}\n", n1);
            Console.WriteLine("Pagaminimo metai         Kaina");
            for (int i = 0; i < n1; i++)
                Console.WriteLine("       {0}            {1,7:f2}", D1[i].ImtiMetus(), D1[i].ImtiKaina());
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine();

            Console.WriteLine("Dviraciu nuomos punktas: {0}\n", pav2);
            Console.WriteLine("Dviraciu kiekis {0}\n", n2);
            Console.WriteLine("Pagaminimo metai         Kaina");
            for (int i = 0; i < n2; i++)
                Console.WriteLine("       {0}            {1,7:f2}", D2[i].ImtiMetus(), D2[i].ImtiKaina());
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine();

            // Tinkami naudoti dviraciai
            // 3 žingnis
            Pinigai(D1, n1, 0, am1, 2015, out kiekTinka1, out sumaTinka1);
            Pinigai(D2, n2, 0, am2, 2015, out kiekTinka2, out sumaTinka2);

            int totalTinka = kiekTinka1 + kiekTinka2;
            double totalKaina = sumaTinka1 + sumaTinka2;
            Console.WriteLine("Tinkami naudoti yra:{0,3:d} dviraciai. Jų verte lygi: {1,7:f2}", totalTinka, totalKaina);
            Console.WriteLine();

            double tinkamuAmzius1 = Vidurkis(D1, n1, 2015, 0, am1);
            double tinkamuAmzius2 = Vidurkis(D2, n2, 2015, 0, am2);
            double kiekTinkamu1 = DviraciuSkaicius(D1, n1, 2015, 0, am1);
            double kiekTinkamu2 = DviraciuSkaicius(D2, n2, 2015, 0, am2);
            Console.WriteLine("Tinkamu naudoti dvivačių vidutinis amžius yra: {0}", (tinkamuAmzius1+ tinkamuAmzius2) / (kiekTinkamu1+ kiekTinkamu2));
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------------------------------------------");
            //Netinkami naudoti dviraciai, kuriu amzius didelis

            Pinigai(D1, n1, am1 + 1, 1000, 2015, out kiekNetinka1, out sumaNetinka1);
            Pinigai(D2, n2, am2 + 1, 1000, 2015, out kiekNetinka2, out sumaNetinka2);

            int totalNeTinka = kiekNetinka1 + kiekNetinka2;
            double totalKainaNetinka = sumaNetinka1 + sumaNetinka2;
            Console.WriteLine("Netinkami naudoti:{0,3:d}  dviraciai. Jų verte lygi: {1,7:f2}", totalNeTinka, totalKainaNetinka);
            Console.WriteLine();


            double netinkamuAmzius1 = Vidurkis(D1, n1, 2015, am1 + 1, 1000);
            double netinkamuAmzius2 = Vidurkis(D2, n2, 2015, am2 + 1, 1000);
            double kiekNeTinkamu1 = DviraciuSkaicius(D1, n1, 2015, am1 + 1, 1000);
            double kiekNeTinkamu2 = DviraciuSkaicius(D2, n2, 2015, am2 + 1, 1000);
            Console.WriteLine("Netinkamu naudoti dvivačių vidutinis amžius yra: {0,6:f2}", (netinkamuAmzius1 + netinkamuAmzius2) / (kiekNeTinkamu1 + kiekNeTinkamu2));
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------------------------------------------");
            // 4 žingnis
            Console.WriteLine("Daugiau tinkamu naudoti dviraciu yra punkte:{0}", TinkamuNaudotiDviraciuKiekis(kiekTinka1, kiekTinka2, pav1, pav2));
            int kiek = 0;
            Pinigai1(D1, n1, out kiek, out suma1);
            Pinigai1(D2, n2, out kiek, out suma2);
            Console.WriteLine();
            Console.WriteLine("Didesne dviraciu verte turi nuomos punktas:{0}", DidesneVerte(suma1, suma2, pav1, pav2));
            Console.WriteLine();
            Console.WriteLine("Programa baigė darbą");
        }
        //Metodas nuskaitantis duomenu faila
        static void Skaityti(string fv, Dviratis[] D, out int n, out int m, out string pav)
        {
            int metai;
            double kaina;
            using (StreamReader reader = new StreamReader(fv))
            {
                string line;
                line = reader.ReadLine();
                string[] parts;
                pav = line;
                line = reader.ReadLine();
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
            for (int i = 0; i < n; i++)
            {
                amzius = metai - D[i].ImtiMetus();
                if ((amPr <= amzius) && (amzius <= amPb))
                {
                    suma = suma + D[i].ImtiKaina();
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
            for (int i = 0; i < n; i++)
            {
                amzius = metai - D[i].ImtiMetus();
                if ((amPr <= amzius) && (amzius <= amPb))
                {
                    suma = suma + amzius;
                    kiek++;
                }
            }
            if (kiek > 0) return (double)suma ;
            return 0.0;
        }
        static double DviraciuSkaicius(Dviratis[] D, int n, int metai, int amPr, int amPb)
        {
            int kiek = 0;
            int amzius;
            for (int i = 0; i < n; i++)
            {
                amzius = metai - D[i].ImtiMetus();
                if ((amPr <= amzius) && (amzius <= amPb))
                { 
                    kiek++;
                }
            }
            if (kiek > 0) return kiek;
            return 0.0;
        }
    
        static string TinkamuNaudotiDviraciuKiekis(int kiekTinka1, int kiekTinka2, string pav1, string pav2)
        {

            if (kiekTinka1 > kiekTinka2)
                return pav1;
            else
                return pav2;
        }
        static void Pinigai1(Dviratis[] D, int n, out int kiek, out double suma)
        {
            kiek = 0;
            suma = 0.0;
            for (int i = 0; i < n; i++)
            {
                suma = suma + D[i].ImtiKaina();
                kiek++;
            }
        }
        static string DidesneVerte(double  suma1, double suma2, string pav1, string pav2)
        {

            if (suma1 > suma2)
                return pav1;
            else
                return pav2;
        }
    }
}
