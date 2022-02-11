using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;

namespace Spausdintuvai
{
    class Spausdintuvai
    {
        private string gamintojas;
        private string modelis;
        private double vienasLapas;
        private double duLapai;
        private double pirmasLapas;
        public Spausdintuvai(string gamintojas, string modelis, double vienasLapas, double duLapai, double pirmasLapas)
        {
            this.gamintojas = gamintojas;
            this.modelis = modelis;
            this.vienasLapas = vienasLapas;
            this.duLapai = duLapai;
            this.pirmasLapas = pirmasLapas;
        }
        public override string ToString()
        {
            string eilute;
            eilute = string.Format("{0,-8} {1, 12} {2, 17}  {3, 30} {4, 28}",
                gamintojas, modelis, vienasLapas, duLapai, pirmasLapas);
            return eilute;
        }
        public double ImtiVienasLapas() { return vienasLapas; }
        public double ImtiDuLapai() { return duLapai; }
        /// <summary>
        /// Tikrina ir grąžina True arba False ar turidvipusio spausdinimo galimybes.
        /// </summary>
        /// <param name="SP1"></param>
        /// <returns></returns>
        public static bool operator !(Spausdintuvai SP1)
        {
            if ((SP1.duLapai  == 0))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Lygina pagal gamintoja ir modeli abeceliškai
        /// </summary>
        /// <param name="sp1"></param>
        /// <param name="sp2"></param>
        /// <returns></returns>
        public static bool operator <=(Spausdintuvai sp1, Spausdintuvai sp2)
        {
            int p = String.Compare(sp1.gamintojas, sp2.gamintojas, StringComparison.CurrentCulture);
            int v = String.Compare(sp1.modelis, sp2.modelis, StringComparison.CurrentCulture);
            return (p < 0 || (p == 0 && v < 0));
        }
        public static bool operator >=(Spausdintuvai sp1, Spausdintuvai sp2)
        {
            int p = String.Compare(sp1.gamintojas, sp2.gamintojas, StringComparison.CurrentCulture);
            int v = String.Compare(sp1.modelis, sp2.modelis, StringComparison.CurrentCulture);
            return (p > 0 || (p == 0 && v > 0));
        }
    }
    class Parduotuve
    {
        const int CMax = 100;
        private Spausdintuvai[] SP;
        private int n;

        public Parduotuve()
        {
            n = 0;
            SP = new Spausdintuvai[CMax];
        }
        public int Imti() { return n; }

        public Spausdintuvai Imti(int i) { return SP[i]; }
        public void Dėti(Spausdintuvai ob) { SP[n++] = ob; }
        public void Rikiuoti()
        {
            for (int i = 0; i < n - 1; i++)
            {
                Spausdintuvai min = SP[i];
                int im = i;
                for (int j = i + 1; j < n; j++)
                    if (SP[j] <= min)
                    {
                        min = SP[j];
                        im = j;
                    }
                SP[im] = SP[i];
                SP[i] = min;
            }
        }
    }
    internal class Program
    {
        const string CFd = "C:\\Users\\A&T\\Desktop\\BIT\\C#\\P7\\Spausdintuvai\\bin\\Debug\\Duomenys.txt";
        const string CFr = "C:\\Users\\A&T\\Desktop\\BIT\\C#\\P7\\Spausdintuvai\\bin\\Debug\\Rezultatai.txt";
        static void Main(string[] args)
        {

            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.Unicode;
            Parduotuve spausdintuvas = new Parduotuve();
            Parduotuve spausdintuvas1 = new Parduotuve();

            if (File.Exists(CFr))
                File.Delete(CFr);

            Skaityti(ref spausdintuvas, CFd);
            Spausdinti(spausdintuvas, CFr, "Spausdintuvų modeliai:");

            Spausdinti3(spausdintuvas, CFr, "");
            Spausdinti4(spausdintuvas, CFr, "Greičiausias spausdintuvas:");

            Formuoti(spausdintuvas, ref spausdintuvas1);
            spausdintuvas1.Rikiuoti();
            Spausdinti(spausdintuvas1, CFr, "Spausdintuvų modeliai su dvipusio spausdinimo galimybe:");

            Console.WriteLine("Programa baigė darbą!");
        }
        /// <summary>
        /// Nuskaito failą
        /// </summary>
        /// <param name="spausdintuvas"></param>
        /// <param name="fv"></param>
        static void Skaityti(ref Parduotuve spausdintuvas, string fv)
        {
            string gamintojas, modelis;
            double vienasLapas, duLapai, pirmasLapas;
            string[] lines = File.ReadAllLines(fv, Encoding.GetEncoding("UTF-8"));
            foreach (string line in lines)
            {
                string[] parts = line.Split(';');
                gamintojas = parts[0];
                modelis = parts[1];
                vienasLapas = double.Parse(parts[2]);
                duLapai = double.Parse(parts[3]);
                pirmasLapas = double.Parse(parts[4]);
                Spausdintuvai SP = new Spausdintuvai(gamintojas, modelis, vienasLapas, duLapai, pirmasLapas);
                spausdintuvas.Dėti(SP);
            }
        }
        /// <summary>
        /// Psausdina failo duomenis
        /// </summary>
        /// <param name="spausdintuvas"></param>
        /// <param name="fv"></param>
        /// <param name="antraštė"></param>
        static void Spausdinti(Parduotuve spausdintuvas, string fv, string antraštė)
        {
            string virsus =
            "---------------------------------------------------------------------------------------------------------------------\r\n"
            + " Gamintojas:   Medelis:  Vienpusio spausdinimo laikas  Dvipusio spausdinimo laikas  Pirmo lapo spausdinimo laikas    \r\n"
            + "                                  vnt/s:                          vnt/s:                       vnt/s:                \r\n"
            + "--------------------------------------------------------------------------------------------------------------------";
            using (var fr = File.AppendText(fv))
            {
                fr.WriteLine(antraštė);
                fr.WriteLine(virsus);
                for (int i = 0; i < spausdintuvas.Imti(); i++)
                    fr.WriteLine("{0}", spausdintuvas.Imti(i).ToString());
                fr.WriteLine("--------------------------------------------------------------------------------------------------------------------\r\n");
            }
        }
        /// <summary>
        /// Randa kiek gali spausdinti ant 2 pusius
        /// </summary>
        /// <param name="spausdintuvas"></param>
        /// <returns></returns>
        static int KiekGaliDvipus(Parduotuve spausdintuvas)
        {

            int kiek = 0;
            for (int i = 0; i < spausdintuvas.Imti(); i++)
            {
                if (spausdintuvas.Imti(i).ImtiDuLapai() != 0)
                    kiek++;
            }
            return kiek;
        }
        /// <summary>
        /// Spausdina dvipusius spausdintuvus
        /// </summary>
        /// <param name="spausdintuvas"></param>
        /// <param name="fv"></param>
        /// <param name="antraštė"></param>
        static void Spausdinti3(Parduotuve spausdintuvas, string fv, string antraštė)
        {

            using (var fr = File.AppendText(fv))
            {
                if (spausdintuvas.Imti() > 0)
                {
                    fr.WriteLine(antraštė);
                    fr.WriteLine(" Dvipusio spausdinimo galimybę turi {0} spausdintuvai", KiekGaliDvipus(spausdintuvas));
                    fr.WriteLine("---------------------------------------------------------------------\r\n");
                }
                else fr.WriteLine("Tokių spausdintuvų nėra");
            }
        }
        /// <summary>
        /// Randa greičiausio spausdinyuvo indeksa
        /// </summary>
        /// <param name="spausdintuvas"></param>
        /// <returns></returns>
        static int MaxGreitis(Parduotuve spausdintuvas)
        {
            int GreitIndex = 0;
            double greičiausiais = spausdintuvas.Imti(0).ImtiVienasLapas();
            for (int i = 0; i < spausdintuvas.Imti(); i++)
                if (greičiausiais > spausdintuvas.Imti(i).ImtiVienasLapas())
                {
                    greičiausiais = spausdintuvas.Imti(i).ImtiVienasLapas();
                    GreitIndex = i;
                }
            return GreitIndex;
        }
        /// <summary>
        /// Spausdina greičiausia spausdintuvą
        /// </summary>
        /// <param name="spausdintuvas"></param>
        /// <param name="fv"></param>
        /// <param name="antraštė"></param>
        static void Spausdinti4(Parduotuve spausdintuvas, string fv, string antraštė)
        {
            string virsus =
            "---------------------------------------------------------------------------------------------------------------------\r\n"
            + " Gamintojas:   Medelis:  Vienpusio spausdinimo laikas  Dvipusio spausdinimo laikas  Pirmo lapo spausdinimo laikas    \r\n"
            + "                                  vnt/s:                          vnt/s:                       vnt/s:                \r\n"
            + "--------------------------------------------------------------------------------------------------------------------";
            using (var fr = File.AppendText(fv))
            {
                fr.WriteLine(antraštė);
                fr.WriteLine(virsus);
                    fr.WriteLine("{0}", spausdintuvas.Imti(MaxGreitis(spausdintuvas)).ToString());
                fr.WriteLine("--------------------------------------------------------------------------------------------------------------------\r\n");
            }
        }
        /// <summary>
        /// Formuoja su dvipusio spausdinimo galimybe
        /// </summary>
        /// <param name="D"></param>
        /// <param name="R"></param>
        static void Formuoti(Parduotuve D, ref Parduotuve R)
        {
            for (int i = 0; i < D.Imti(); i++)
                if (!D.Imti(i))
                    ;
                else
                    R.Dėti(D.Imti(i));
        }
    }
}