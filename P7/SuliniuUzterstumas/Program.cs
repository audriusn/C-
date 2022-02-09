using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;

namespace SuliniuUzterstumas
{
    class Sulinys
    {
        private string adresas;
        private int Nr;
        private int gylis;
        private double skersmuo;
        private int kiekis;

        public Sulinys(string adresas,int Nr, int gylis, double skersmuo, int kiekis)
        {
            this.adresas = adresas;
            this.Nr = Nr;
            this.gylis = gylis;
            this.skersmuo = skersmuo;
            this.kiekis = kiekis;
        }  
        public override string ToString()
        {
            string eilute;
            eilute = string.Format("{0, -8} {1, 5} {2, 13} {3, 20} {4, 19}",
                adresas, Nr, gylis, skersmuo, kiekis);
            return eilute;
        }
        public string ImtiAdresa() { return adresas; } 
        public int ImtiGyli() { return gylis; }
        public int ImtiKieki() { return kiekis; }

        public static bool operator <=(Sulinys sul1, Sulinys sul2)
        {
            return (sul1.ImtiKieki() > sul2.ImtiKieki() || (sul1.ImtiKieki() == sul2.ImtiKieki() && sul1.ImtiGyli() < sul2.ImtiGyli()));
        }
        public static bool operator >=(Sulinys sul1, Sulinys sul2)
        {
            return (sul1.ImtiKieki() < sul2.ImtiKieki() || (sul1.ImtiKieki() == sul2.ImtiKieki() && sul1.ImtiGyli() > sul2.ImtiGyli()));
        }
    }  
    class Kaimas
    {
        const int CMax = 100;
        private Sulinys[] sul;
        private int n;

        public Kaimas()
        {
            n = 0;
            sul = new Sulinys[CMax];
        }
        public int Imti() { return n; }

        public Sulinys Imti(int i) { return sul[i]; }
        public void Dėti(Sulinys ob) { sul[n++] = ob; }
        public void Rikiuoti()
        {
            for (int i = 0; i < n - 1; i++)
            {
                Sulinys min = sul[i];
                int im = i;
                for (int j = i + 1; j < n; j++)
                    if (sul[j] <= min)
                    { 
                        min = sul[j];
                        im = j;
                    }
                sul[im] = sul[i];
                sul[i] = min;
            }
        }
    }
    internal class Program
    {
        const string CFd = "C:\\Users\\A&T\\Desktop\\BIT\\C#\\P7\\SuliniuUzterstumas\\bin\\Debug\\Duomenys.txt";
        const string CFr = "C:\\Users\\A&T\\Desktop\\BIT\\C#\\P7\\SuliniuUzterstumas\\bin\\Debug\\Rezultatai.txt";
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Kaimas sodybos = new Kaimas();
            Kaimas sodybos1 = new Kaimas();
            Kaimas sodybos2 = new Kaimas();
            if (File.Exists(CFr))
                File.Delete(CFr);

            Skaityti(ref sodybos, CFd);
            Spausdinti(sodybos, CFr, " Kaimo šulinių sąrašas:");

            int gylisSul = MaxGylis(sodybos);
            Spausdinti2(sodybos, CFr);

            // Įvedame ir nuskaitome leistiną nitratų kiekį
            int a;
            Console.WriteLine("Iveskite maksimalia leistiną nitratų kiekį:");
            a = int.Parse(Console.ReadLine());

            Formuoti(sodybos, ref sodybos1, a);
            Spausdinti(sodybos1, CFr, " Užteršti šuliniai:");

            // Įvedame ir nuskaitome gatvę 
            string b;
            Console.WriteLine("Iveskite gatvę:");
            
            b = Console.ReadLine();

            Formuoti2(sodybos, ref sodybos2, b);
            sodybos2.Rikiuoti();
            Spausdinti(sodybos2, CFr, " Pagal gatvę:");

            Console.WriteLine("Programa darbą baigė!");
        }
        static void Skaityti(ref Kaimas sodybos, string fv)
        {
            string adresas;
            int gylis, kiekis,Nr;
            double skersmuo;

            string[] lines = File.ReadAllLines(fv, Encoding.GetEncoding("UTF-8"));
            foreach (string line in lines)
            {
                string[] parts = line.Split(';');
                adresas = parts[0];
                Nr = int.Parse(parts[1]);
                gylis = int.Parse(parts[2]);
                skersmuo = double.Parse(parts[3]);
                kiekis = int.Parse(parts[4]);
                Sulinys sul = new Sulinys(adresas, Nr, gylis, skersmuo, kiekis);              
                sodybos.Dėti(sul);
            }
        }
        /// <summary>
        /// Išspausdina sodybų sąrašą 
        /// </summary>
        /// <param name="sodybos"></param>
        /// <param name="fv"></param>
        /// <param name="antraštė"></param>
        static void Spausdinti(Kaimas sodybos, string fv, string antraštė)
        {
            string virsus =
            "-----------------------------------------------------------------------------\r\n"
            + " Gatvė  Namo Nr.   Sulinio gylis (m)   Šulinio skermuo (m)  Nitratų kiekis mg/l  \r\n"
            + "-----------------------------------------------------------------------------";
            using (var fr = File.AppendText(fv))
            {
                fr.WriteLine(antraštė);
                fr.WriteLine(virsus);
                for (int i = 0; i < sodybos.Imti(); i++)
                    fr.WriteLine("{0}", sodybos.Imti(i).ToString());
                fr.WriteLine("-----------------------------------------------------------------------------\r\n");
            }
        }
        /// <summary>
        /// Randa giliausia kaimo šulinį
        /// </summary>
        /// <param name="gylis"></param>
        /// <returns></returns>
        static int MaxGylis(Kaimas gylis)
        {
            int k = 0;
            int gyliausia;
            for (int i = 0; i < gylis.Imti(); i++)
                if (gylis.Imti(i).ImtiGyli() > gylis.Imti(k).ImtiGyli())
                    k = i;
            gyliausia = gylis.Imti(k).ImtiGyli();
            return gyliausia;
        }
        /// <summary>
        /// Spausdina giliausią šulinį turinčią sodybą
        /// </summary>
        /// <param name="sodybos"></param>
        /// <param name="fv"></param>

        static void Spausdinti2(Kaimas sodybos, string fv)
        {
            string virsus =
            "--------------------------------\r\n"
            + " Giliausias šulinys:  \r\n"
            + "------------------------------";
            using (var fr = File.AppendText(fv))
            {
                
                fr.WriteLine(virsus);
                fr.WriteLine("{0,4} metrų gylio", MaxGylis(sodybos));
                fr.WriteLine("--------------------------------\r\n");
            }
        }
        /// <summary>
        /// Randa sodybas, pagal kurios turi didesnį užteštumo  lygi nei įvesta
        /// </summary>
        /// <param name="sodybos"></param>
        /// <param name="sodybos1"></param>
        /// <param name="a"></param>
        static void Formuoti(Kaimas sodybos, ref Kaimas sodybos1, int a)
        {
            for (int i = 0; i < sodybos.Imti(); i++)
            {
                if (sodybos.Imti(i).ImtiKieki() > a)
                    sodybos1.Dėti(sodybos.Imti(i));
            }
        }
        /// <summary>
        /// Randa sodybas pagal gatvės pavadinimą
        /// </summary>
        /// <param name="sodybos"></param>
        /// <param name="sodybos2"></param>
        /// <param name="b"></param>
        static void Formuoti2(Kaimas sodybos, ref Kaimas sodybos2, string b)
        {
            for (int i = 0; i < sodybos.Imti(); i++)
            {
                if (sodybos.Imti(i).ImtiAdresa() == b)
                    sodybos2.Dėti(sodybos.Imti(i));                
            }
        }

    }
}