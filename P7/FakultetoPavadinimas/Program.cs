using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;


namespace FakultetoPavadinimas
{
    class Studentas
    {
        private string pavVrd;
        private string grupė;
        private int kiek;
        private ArrayList paž;

        public Studentas()
        {
            pavVrd = "";
            grupė = "";
            kiek = 0;
            paž = new ArrayList();
        }
 
        public void Dėti(string pavVrd, string grupė, int kiek, ArrayList pž)
        {
            this.pavVrd = pavVrd;
            this.kiek = kiek;
            this.grupė = grupė;
            foreach (int sk in pž)
                paž.Add(sk);
        }
        public string ImtiPav() { return grupė; }
        public override string ToString()
        {
            string eilute;
            eilute = string.Format("{0, -20} {1, -9} {2, -15}",
            pavVrd, grupė, kiek);
            foreach (int sk in paž)
                eilute = eilute + string.Format("{0, 3:d}", sk);
            return eilute;

        }
        /// <summary>
        ///  Operatorius ! grąžina true, jeigu bent vienas studentas yra grupėje "IFZ9/2"; false - kitais atvejais
        /// </summary>
        /// <param name="c1"></param>
        /// <returns></returns>
        public static bool operator !(Studentas c1)
        {
            string gr = "IFZ9/2";
            if (c1.grupė == gr)
                return true;
            else
                return false;
        }
        public static bool operator <=(Studentas st1, Studentas st2)
        {
            int p = String.Compare(st1.pavVrd, st2.pavVrd, StringComparison.CurrentCulture);
            int v = String.Compare(st1.grupė, st2.grupė, StringComparison.CurrentCulture);
            return (p < 0 || (p == 0 && v < 0));
        }
        public static bool operator >=(Studentas st1, Studentas st2)
        {
            int p = String.Compare(st1.grupė, st2.grupė, StringComparison.CurrentCulture);
            int v = String.Compare(st1.pavVrd, st2.pavVrd, StringComparison.CurrentCulture);
            return (p > 0 || (p == 0 && v > 0));
        }
        public double studentoVidurkis()
        {
            double sum = 0;
            double a = 0;
            foreach (int i in paž)
                sum = sum + i;
            a = sum / kiek;
            return a;
        }
    }
    class Fakultetas
    {
        const int CMax = 100;
        private Studentas[] St;
        private int n;

        public Fakultetas()
        {
            n = 0;
            St = new Studentas[CMax];
        }
        public int Imti() { return n; }
      
        public Studentas Imti(int i) { return St[i]; }
        public void Dėti(Studentas ob) { St[n++] = ob; }
        public void Rikiuoti()
        {
            for (int i = 0; i < n - 1; i++)
            {
                Studentas min = St[i];
                int im = i;
                for (int j = i + 1; j < n; j++)
                    if (St[j] <= min)
                    { // naudojamas užklotas operatorius <=
                        min = St[j];
                        im = j;
                    }
                St[im] = St[i];
                St[i] = min;
            }
        }
    }

    internal class Program
    {
        const string CFd = "C:\\Users\\A&T\\Desktop\\BIT\\C#\\P7\\FakultetoPavadinimas\\bin\\Debug\\Studentai.txt";
        const string CFr = "C:\\Users\\A&T\\Desktop\\BIT\\C#\\P7\\FakultetoPavadinimas\\bin\\Debug\\Rezultatai.txt";
        static void Main(string[] args)
        {
            Fakultetas grupes = new Fakultetas();
            Fakultetas grupes1 = new Fakultetas();
            Fakultetas grupes2 = new Fakultetas();
            
            if (File.Exists(CFr))
                File.Delete(CFr);
            Skaityti(ref grupes, CFd);
            Spausdinti(grupes, CFr, " Žiemos sesijos pažymių sąrašas:");

            Formuoti(grupes, ref grupes1, ref grupes2);
            grupes1.Rikiuoti();
            Spausdinti(grupes1, CFr,"Pirma gupė");
            grupes2.Rikiuoti();
            Spausdinti(grupes2, CFr, "Antra gupė");
            Spausdinti1(grupes1, CFr);
            Spausdinti1(grupes2, CFr);

            Console.WriteLine("Programa baigė darbą");
        }
        static void Skaityti(ref Fakultetas grupe, string fv)
        {
            string pavVrd, grupė;
            int kiek;
            string pav;
            ArrayList pz = new ArrayList();
            string[] lines = File.ReadAllLines(fv, Encoding.GetEncoding("UTF-8"));
            foreach (string line in lines)
            {
                string[] parts = line.Split(';');
                pavVrd = parts[0];
                grupė = parts[1];
                kiek = int.Parse(parts[2]);
                string[] eil = parts[3].Trim().Split(new[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries);
                pz.Clear();
                foreach (string eilute in eil)
                {
                    int aa = int.Parse(eilute);
                    pz.Add(aa);
                }
                Studentas stud = new Studentas();
                stud.Dėti(pavVrd, grupė, kiek, pz);
                grupe.Dėti(stud);
            }
        }
        static void Spausdinti(Fakultetas grupe, string fv, string antraštė)
        {
            string virsus =
            "------------------------------------------------------------------\r\n"
            + " Pavardė  Vardas     Grupė   Pažymių skaičius      Pažymiai \r\n"
            + "------------------------------------------------------------------";
            using (var fr = File.AppendText(fv))
            {
                fr.WriteLine(antraštė);
                fr.WriteLine(virsus);
                for (int i = 0; i < grupe.Imti(); i++)
                    fr.WriteLine("{0}", grupe.Imti(i).ToString());
                fr.WriteLine("-------------------------------------------------------------\r\n");
            }
        }
        static void Formuoti(Fakultetas D, ref Fakultetas R, ref Fakultetas S)
        {
            for (int i = 0; i < D.Imti(); i++)
                if (!D.Imti(i))
                    S.Dėti(D.Imti(i));
                else
                    R.Dėti(D.Imti(i));
        }

        static double GrupėsVidurkis(Fakultetas grupė)
        {
            double suma = 0;
            int kiek = 0;
            for (int i = 0; i < grupė.Imti(); i++)
            {
                suma += grupė.Imti(i).studentoVidurkis();
                kiek++;
            }
            return suma / kiek;
        }
        static void Spausdinti1(Fakultetas grupe, string fv)
        {
            string virsus =
            "-----------------------\r\n"
            + "  Grupė   Vidurkis \r\n"
            + "-----------------------";
            using (var fr = File.AppendText(fv))
            {
                fr.WriteLine(virsus);
               
                    fr.WriteLine("{0}       {1,2:f2} ",grupe.Imti(0).ImtiPav(), GrupėsVidurkis(grupe));
                fr.WriteLine("------------------------\r\n");
            }
        }
       
    }
}