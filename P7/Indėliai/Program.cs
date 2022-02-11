using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;

namespace Indėliai
{
    class Indėlis
    {
        private int pinigai;
        private int terminas;
        private double palukanos;
        private string variantas;
     

        public Indėlis(int pinigai, int terminas, double palukanos, string variantas)
        {
            this.pinigai = pinigai;
            this.terminas = terminas;
            this.palukanos = palukanos;
            this.variantas = variantas;
        }
        public override string ToString()
        {
            string eilute;
            eilute = string.Format("{0,12} {1, 10} mėn {2, 16} % {3, 20}",
                pinigai, terminas, palukanos, variantas);
            return eilute;
        }
        public int ImtiIndėli() { return pinigai; }
        public int ImtiTermina() { return terminas; }
        public double ImtiPalukanas() { return palukanos; }
        public string ImtiVarianta() { return variantas; }
        public static bool operator <=(Indėlis ind1, Indėlis ind2)
        {
            return (ind1.ImtiTermina() > ind2.ImtiTermina() || (ind1.ImtiTermina() == ind2.ImtiTermina() && ind1.ImtiIndėli() > ind2.ImtiIndėli()));
        }
        public static bool operator >=(Indėlis ind1, Indėlis ind2)
        {
            return (ind1.ImtiTermina() < ind2.ImtiTermina() || (ind1.ImtiTermina() == ind2.ImtiTermina() && ind1.ImtiIndėli() < ind2.ImtiIndėli()));
        }

    }
    class Bankas
    {
        const int CMax = 100;
        private Indėlis[] ind;
        private int n;

        public Bankas()
        {
            n = 0;
            ind = new Indėlis[CMax];
        }
        public int Imti() { return n; }

        public Indėlis Imti(int i) { return ind[i]; }
        public void Dėti(Indėlis ob) { ind[n++] = ob; }
        public void Rikiuoti()
        {
            for (int i = 0; i < n - 1; i++)
            {
                Indėlis min = ind[i];
                int im = i;
                for (int j = i + 1; j < n; j++)
                    if (ind[j] <= min)
                    {
                        min = ind[j];
                        im = j;
                    }
                ind[im] = ind[i];
                ind[i] = min;
            }
        }
    }
    internal class Program
    {
        const string CFd = "C:\\Users\\A&T\\Desktop\\BIT\\C#\\P7\\Indėliai\\bin\\Debug\\Duomenys.txt";
        const string CFr = "C:\\Users\\A&T\\Desktop\\BIT\\C#\\P7\\Indėliai\\bin\\Debug\\Rezultatai.txt";
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Bankas indėlis = new Bankas();
            Bankas indėlis1 = new Bankas();
            Bankas indėlis2 = new Bankas();

            if (File.Exists(CFr))
                File.Delete(CFr);

            Skaityti(ref indėlis, CFd);
            Spausdinti(indėlis, CFr, "Banke esančių indėlių sarašas:");

            int maxI = MaxInd(indėlis);
            Spausdinti2(indėlis, CFr);

            Spausdinti3(indėlis, CFr);

            string b;
            Console.WriteLine("Iveskite palūkamų skaičiavimo tipą");

            b = Console.ReadLine();

            Formuoti(indėlis, ref indėlis1, b);
            indėlis1.Rikiuoti();
            Spausdinti(indėlis1, CFr, " Pagal palūkanų skaičiavimo tipą:");

            Console.WriteLine("Programa darbą baigė!");
        }
        static void Skaityti(ref Bankas indėlis, string fv)
        {
            int pinigai, terminas;
            double palukanos;
            string variantas;
            string[] lines = File.ReadAllLines(fv, Encoding.GetEncoding("UTF-8"));
            foreach (string line in lines)
            {
                string[] parts = line.Split(';');
                pinigai = int.Parse(parts[0]);
                terminas = int.Parse(parts[1]); 
                palukanos = double.Parse(parts[2]);
                variantas = parts[3];
                Indėlis ind = new Indėlis(pinigai, terminas, palukanos, variantas);
                indėlis.Dėti(ind);
            }
        }
        /// <summary>
        /// Spuasdina visus indėlius
        /// </summary>
        /// <param name="indėlis"></param>
        /// <param name="fv"></param>
        /// <param name="antraštė"></param>
        static void Spausdinti(Bankas indėlis, string fv, string antraštė)
        {
            string virsus =
            "------------------------------------------------------------------------------------\r\n"
            + " Indėlio suma:   Sutarties terminas   Palūkanų norma  Palūkanų skaičiavimo variantas:  \r\n"
            + "-----------------------------------------------------------------------------------";
            using (var fr = File.AppendText(fv))
            {
                fr.WriteLine(antraštė);
                fr.WriteLine(virsus);
                for (int i = 0; i < indėlis.Imti(); i++)
                    fr.WriteLine("{0}", indėlis.Imti(i).ToString());
                fr.WriteLine("-----------------------------------------------------------------------------------\r\n");
            }
        }
        /// <summary>
        /// Randa didziausia indeli
        /// </summary>
        /// <param name="pinigai"></param>
        /// <returns></returns>
        static int MaxInd(Bankas pinigai)
        {
            int k = 0;
            int max;
            for (int i = 0; i < pinigai.Imti(); i++)
                if (pinigai.Imti(i).ImtiIndėli() > pinigai.Imti(k).ImtiIndėli())
                    k = i;
            max = pinigai.Imti(k).ImtiIndėli();
            return max;
        }
        /// <summary>
        /// Spausdina diziausia indeli
        /// </summary>
        /// <param name="indėlis"></param>
        /// <param name="fv"></param>
        static void Spausdinti2(Bankas indėlis, string fv)
        {
            string virsus =
            "--------------------------------\r\n"
            + " Didžiausias indėlis banke:  \r\n"
            + "------------------------------";
            using (var fr = File.AppendText(fv))
            {

                fr.WriteLine(virsus);
                fr.WriteLine("  {0,6} Eurų ", MaxInd(indėlis));
                fr.WriteLine("--------------------------------\r\n");
            }
        }
        /// <summary>
        /// Spausdina banko mokejimo suma
        /// </summary>
        /// <param name="indėlis"></param>
        /// <param name="fv"></param>
        static void Spausdinti3(Bankas indėlis, string fv)
        {
            string virsus =
            "--------------------------------\r\n"
            + " Bankas turės išmokėti:  \r\n"
            + "------------------------------";
            using (var fr = File.AppendText(fv))
            {

                fr.WriteLine(virsus);
                fr.WriteLine("  {0, 3:f} Eurų ", Bankosuma(indėlis));
                fr.WriteLine("--------------------------------\r\n");
            }
        }
        /// <summary>
        /// Skaičiuoja kiek viso bankas turi išmokėti
        /// </summary>
        /// <param name="variantas"></param>
        /// <returns></returns>
        static double Bankosuma(Bankas variantas)
        {
            
            double a1=0, b1=0, c1 =0;
            double  sumA=0, sumB = 0, sumC = 0;
            
            for (int i = 0; i < variantas.Imti(); i++)
            {
                if (variantas.Imti(i).ImtiVarianta() == "a")
                {
                    a1 = variantas.Imti(i).ImtiIndėli() + (variantas.Imti(i).ImtiIndėli() * (variantas.Imti(i).ImtiPalukanas() / 100) * (variantas.Imti(i).ImtiTermina() / 12));
                    sumA = sumA + a1;
                }
                if (variantas.Imti(i).ImtiVarianta() == "b")
                {
                    b1 = variantas.Imti(i).ImtiIndėli();
                    for (int k = 0; k < variantas.Imti(i).ImtiTermina(); k++)
                    {
                        double palukB = (b1 * (variantas.Imti(i).ImtiPalukanas() / 100) / 12);
                        b1 = b1 + palukB;
                    }
                    sumB = sumB + b1;
                }
                if (variantas.Imti(i).ImtiVarianta() == "c")
                {
                    c1 = variantas.Imti(i).ImtiIndėli() * Math.Pow(1 + (variantas.Imti(i).ImtiPalukanas() / 100), (variantas.Imti(i).ImtiTermina() / 12));
                    sumC = sumC + c1;
                }
            }
            return sumA+sumB+sumC;
            
        }
        /// <summary>
        /// Formuoja pagal palukanu tipa
        /// </summary>
        /// <param name="indėlis"></param>
        /// <param name="indėlis1"></param>
        /// <param name="b"></param>
        static void Formuoti(Bankas indėlis, ref Bankas indėlis1, string b)
        {
            for (int i = 0; i < indėlis.Imti(); i++)
            {
                if (indėlis.Imti(i).ImtiVarianta() == b)
                    indėlis1.Dėti(indėlis.Imti(i));
            }
        }
    }
}
