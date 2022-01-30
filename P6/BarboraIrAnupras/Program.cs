using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BarboraIrAnupras
{
    class ValiutosKursai
    {
        private int pinigai;
        private int centai;
        private double kursas;


        public ValiutosKursai(int pinigai, int centai, double kursas)
        {
            this.pinigai = pinigai;
            this.centai = centai;
            this.kursas = kursas;

        }
        public int ImtiPinigus() { return pinigai; }
        public int ImtiCentus() { return centai; }
        public double ImtiKursas() { return kursas; }

    }
    internal class Program
    {
        const int Cn = 100;
        const string CFd1 = "C:\\Users\\A&T\\Desktop\\BIT\\C#\\P6\\BarboraIrAnupras\\bin\\Debug\\A.txt";
        const string CFd2 = "C:\\Users\\A&T\\Desktop\\BIT\\C#\\P6\\BarboraIrAnupras\\bin\\Debug\\B.txt";
        static void Main(string[] args)
        {

            ValiutosKursai[] VK1 = new ValiutosKursai[Cn];
            int n1;
            string vardas1;
            Skaityti(CFd1, VK1, out n1, out vardas1);
            double pinigaiEur1, centaiEur1;

            ValiutosKursai[] VK2 = new ValiutosKursai[Cn];
            int n2;
            string vardas2;
            Skaityti(CFd2, VK2, out n2, out vardas2);
            double pinigaiEur2, centaiEur2;

            // tikrininam ar nuskaito failus
            Console.WriteLine("Vardas: {0}\n", vardas1);
            Console.WriteLine("Turimu skirtingu valiutu skaicius: {0}\n", n1);
            Console.WriteLine("Pinigai         Centai        Valiutos Kursas ");
            for (int i = 0; i < n1; i++)
                Console.WriteLine("{0,-12}     {1}                {2}", VK1[i].ImtiPinigus(), VK1[i].ImtiCentus(), VK1[i].ImtiKursas());
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine();

            Console.WriteLine("Vardas: {0}\n", vardas2);
            Console.WriteLine("Turimu skirtingu valiutu skaicius: {0}\n", n2);
            Console.WriteLine("Pinigai         Centai        Valiutos Kursas ");
            for (int i = 0; i < n2; i++)
                Console.WriteLine("{0,-12}     {1}                {2}", VK2[i].ImtiPinigus(), VK2[i].ImtiCentus(), VK2[i].ImtiKursas());
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine();

            // Keiciam Barboros valiuta i eurus
            KeiciamIEurus(VK1, n1, out pinigaiEur1, out centaiEur1);
            Console.WriteLine("{0} turi {1} euru ir {2} euro centu", vardas1, pinigaiEur1, centaiEur1);
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine();

            // Keiciam Anupro valiuta i eurus
            KeiciamIEurus(VK2, n2, out pinigaiEur2, out centaiEur2);
            Console.WriteLine("{0} turi {1} euru ir {2} euro centu", vardas2, pinigaiEur2, centaiEur2);
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine();

            
            double totalEurzz = BendraiTuriEuru(pinigaiEur1, pinigaiEur2, centaiEur1, centaiEur2);
            double totalEurCentaizz = BendraiTuriEuroCentu(pinigaiEur1, pinigaiEur2, centaiEur1, centaiEur2); 
            Console.WriteLine("Viso Barboba ir Anupras turi {0} Euru ir {1} Euro centu.", totalEurzz, totalEurCentaizz);
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine();

        }
        static void Skaityti(string fv, ValiutosKursai[] VK, out int n, out string vardas)
        {
            int pinigai;
            int centai;
            double kursas;
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
                    pinigai = int.Parse(parts[0]);
                    centai = int.Parse(parts[1]);
                    kursas = double.Parse(parts[2]);
                    VK[i] = new ValiutosKursai(pinigai, centai, kursas);

                }
            }
        }
        static void KeiciamIEurus(ValiutosKursai[] VK, int n, out double pinigaiEur, out double centaiEur)
        {
            pinigaiEur = 0;
            centaiEur = 0;

            for (int i = 0; i < n; i++)
            {
                pinigaiEur = pinigaiEur + ((VK[i].ImtiPinigus() + (VK[i].ImtiCentus() / 100)) / VK[i].ImtiKursas());

            }
            centaiEur = Math.Floor((pinigaiEur % Math.Floor(pinigaiEur)) * 100);
            pinigaiEur = Math.Floor(pinigaiEur);
        }
        static double BendraiTuriEuru(double pinigaiEur1, double pinigaiEur2, double centaiEur1, double centaiEur2)
        {
           
            double totalEur = 0;
            double totalEurCentai = 0;
            totalEur = pinigaiEur1 + (centaiEur1 / 100) + pinigaiEur2 + (centaiEur2 / 100);
            totalEur = Math.Floor(totalEur);
            totalEurCentai = Math.Floor((totalEur % Math.Floor(totalEur)) * 100);
            return totalEur;
        }
        static double BendraiTuriEuroCentu(double pinigaiEur1, double pinigaiEur2, double centaiEur1, double centaiEur2)
        {

            double totalEur = 0;
            double totalEurCentai = 0;
            totalEur = pinigaiEur1 + (centaiEur1 / 100) + pinigaiEur2 + (centaiEur2 / 100);
            totalEurCentai = Math.Floor((totalEur % Math.Floor(totalEur)) * 100);
            return totalEurCentai;
        }
    }
}
