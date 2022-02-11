using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;

namespace Bukletai
{
    class Bukletai
    {
        private string formatas;
        private double kaina;
        private int lapuSK;
        private int kiekis;
        public Bukletai(string formatas, double kaina, int lapuSK, int kiekis)
        {
            this.formatas = formatas;
            this.kaina = kaina;
            this.lapuSK = lapuSK;
            this.kiekis = kiekis;
        }
        public override string ToString()
        {
            string eilute;
            eilute = string.Format("{0,8} {1, 12} {2, 14}  {3, 14}",
                formatas, kaina, lapuSK, kiekis);
            return eilute;
        }
        public double Imtikaina() { return kaina; }
        public int ImtiLapuSK() { return lapuSK; }
        public int Imtikiekis() { return kiekis; }
        public double UzsakymoKaina()
        {
            return (kaina/500)*lapuSK * kiekis;
        }
        /// <summary>
        /// Tikrina ar užtenka 500 lapų užsakymui
        /// </summary>
        /// <param name="b1"></param>
        /// <returns></returns>
        public static bool operator !(Bukletai b1)
        {
            int blokas = 500;
            if ((b1.lapuSK * b1.kiekis) > blokas)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Rikuoja pagal Lapų skaičių ir kiekį
        /// </summary>
        /// <param name="b1"></param>
        /// <param name="b2"></param>
        /// <returns></returns>
        public static bool operator <=(Bukletai b1, Bukletai b2)
        {
            return (b1.ImtiLapuSK() > b2.ImtiLapuSK() || (b1.ImtiLapuSK() == b2.ImtiLapuSK() && b1.Imtikiekis() > b2.Imtikiekis()));
        }
        public static bool operator >=(Bukletai b1, Bukletai b2)
        {
            return (b1.ImtiLapuSK() < b2.ImtiLapuSK() || (b1.ImtiLapuSK() == b2.ImtiLapuSK() && b1.Imtikiekis() < b2.Imtikiekis()));
        }

    }
    class Uzsakymai
    {
        const int CMax = 100;
        private Bukletai[] buk;
        private int n;

        public Uzsakymai()
        {
            n = 0;
            buk = new Bukletai[CMax];
        }
        public int Imti() { return n; }

        public Bukletai Imti(int i) { return buk[i]; }
        public void Dėti(Bukletai ob) { buk[n++] = ob; }
        public void Rikiuoti()
        {
            for (int i = 0; i < n - 1; i++)
            {
                Bukletai min = buk[i];
                int im = i;
                for (int j = i + 1; j < n; j++)
                    if (buk[j] <= min)
                    {
                        min = buk[j];
                        im = j;
                    }
                buk[im] = buk[i];
                buk[i] = min;
            }
        }
    }
    internal class Program
        {
        const string CFd = "C:\\Users\\A&T\\Desktop\\BIT\\C#\\P7\\Bukletai\\bin\\Debug\\Duomenys.txt";
        const string CFr = "C:\\Users\\A&T\\Desktop\\BIT\\C#\\P7\\Bukletai\\bin\\Debug\\Rezultatai.txt";
        static void Main(string[] args)
            {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.Unicode;
            Uzsakymai bukletas = new Uzsakymai();
            Uzsakymai bukletas1 = new Uzsakymai();

            if (File.Exists(CFr))
                File.Delete(CFr);

            Skaityti(ref bukletas, CFd);
            Spausdinti(bukletas, CFr, "Bukletų užsakymai:");
            Spausdinti2(bukletas, CFr, "Bukletų užsakymai su užsakymo kaina:");

            Spausdinti3(bukletas, CFr, "Pigiausio užsakymo kaina:");
            Formuoti(bukletas, ref bukletas1);
            bukletas1.Rikiuoti();
            Spausdinti2(bukletas1, CFr, "Bukletų užsakymai su užsakymo kaina:");
            Console.WriteLine("Programa baigė darbą!");
        }

        static void Skaityti(ref Uzsakymai bukletas, string fv)
        {
            string formatas;
            int lapuSK, kiekis;
            double kaina;
            string[] lines = File.ReadAllLines(fv, Encoding.GetEncoding("UTF-8"));
            foreach (string line in lines)
            {
                string[] parts = line.Split(';');
                formatas = parts[0];
                kaina = double.Parse(parts[1]);
                lapuSK = int.Parse(parts[2]);
                kiekis = int.Parse(parts[3]);
                Bukletai buk = new Bukletai(formatas, kaina, lapuSK, kiekis);
                bukletas.Dėti(buk);
            }
        }
        /// <summary>
        /// Spausdina failo duoemenis
        /// </summary>
        /// <param name="bukletas"></param>
        /// <param name="fv"></param>
        /// <param name="antraštė"></param>
        static void Spausdinti(Uzsakymai bukletas, string fv, string antraštė)
        {
            string virsus =
            "--------------------------------------------------------\r\n"
            + " Formatas:   500 lapų kaina:  Lapų skaičius:  Kiekis:  \r\n"
            + "------------------------------------------------------";
            using (var fr = File.AppendText(fv))
            {
                fr.WriteLine(antraštė);
                fr.WriteLine(virsus);
                for (int i = 0; i < bukletas.Imti(); i++)
                    fr.WriteLine("{0}", bukletas.Imti(i).ToString());
                fr.WriteLine("--------------------------------------------------------\r\n");
            }
        }
        /// <summary>
        /// Spausdina su užsakymo kaina
        /// </summary>
        /// <param name="bukletas"></param>
        /// <param name="fv"></param>
        /// <param name="antraštė"></param>
        static void Spausdinti2(Uzsakymai bukletas, string fv, string antraštė)
        {
            string virsus =
            "---------------------------------------------------------------------\r\n"
            + " Formatas:   500 lapų kaina:  Lapų skaičius:  Kiekis: Užsakymo kaina: \r\n"
            + "-------------------------------------------------------------------";
            using (var fr = File.AppendText(fv))
            {
                fr.WriteLine(antraštė);
                fr.WriteLine(virsus);
                for (int i = 0; i < bukletas.Imti(); i++)
                    fr.WriteLine("{0}  {1, 10:f2}", bukletas.Imti(i).ToString(), bukletas.Imti(i).UzsakymoKaina());
                fr.WriteLine("---------------------------------------------------------------------\r\n");
            }
        }
        /// <summary>
        /// Randa mažiausią kainą
        /// </summary>
        /// <param name="bukletas"></param>
        /// <returns></returns>
        static double MinKaina(Uzsakymai bukletas)
        {
            double maziausia = bukletas.Imti(0).UzsakymoKaina();
            for (int i = 0; i < bukletas.Imti(); i++)
             if (maziausia > bukletas.Imti(i).UzsakymoKaina())
                { 
                    maziausia = bukletas.Imti(i).UzsakymoKaina();
            }
            return maziausia;
        }
        /// <summary>
        /// Spausdina mažiausią kainą
        /// </summary>
        /// <param name="bukletas"></param>
        /// <param name="fv"></param>
        /// <param name="antraštė"></param>
        static void Spausdinti3(Uzsakymai bukletas, string fv, string antraštė)
        {
           
            using (var fr = File.AppendText(fv))
            {
                fr.WriteLine(antraštė);            
                    fr.WriteLine("{0} EUR",MinKaina(bukletas));
                fr.WriteLine("---------------------------------------------------------------------\r\n");
            }
        }
        /// <summary>
        /// Formuoja, kam užtenka 500 lapų popieriaus
        /// </summary>
        /// <param name="D"></param>
        /// <param name="R"></param>
        static void Formuoti(Uzsakymai D, ref Uzsakymai R )
        {
            for (int i = 0; i < D.Imti(); i++)
                if (!D.Imti(i))
                    ;
                else
                    R.Dėti(D.Imti(i));
        }
    }

 }
