using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;

namespace Fakultetas
{
    class Studentas
    {
        private string pavardė, vardas, grupė; 
        private ArrayList paž; // pažymių masyvas
                             
        /** Pradiniai studento duomenys, išskyrus pažymius */
        public Studentas()
        {
            pavardė = "";
            vardas = "";
            grupė = "";
            paž = new ArrayList();
        }

        /// <summary>
        /// * Studento duomenų įrašymas
        /// </summary>
        /// <param name="pav"> nauja pavardės reikšmė</param>
        /// <param name="vard">nauja vardo reikšmė </param>
        /// <param name="grup">nauja grupės reikšmė</param>
        /// <param name="pž">- naujos pažymių reikšmės</param>
        public void Dėti(string pav, string vard, string grup, ArrayList pž)
        {
            pavardė = pav;
            vardas = vard;
            grupė = grup;
            foreach (int sk in pž)
                paž.Add(sk);
        }
        /// <summary>
        /// Spausdinimo metodas
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string eilute;
            eilute = string.Format("{0, -12} {1, -9} {2, -7}",
            pavardė, vardas, grupė);
            foreach (int sk in paž)
                eilute = eilute + string.Format("{0, 3:d}", sk);
            return eilute;
        }
        /// <summary>
        ///  Operatorius ! grąžina true, jeigu bent vienas pažymys yra mažesnis už 9; false - kitais atvejais
        /// </summary>
        /// <param name="c1"></param>
        /// <returns></returns>
        public static bool operator !(Studentas c1)
        {
            foreach (int sk in c1.paž)
            {
                if (sk < 9)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// Operatorius grąžina true, jeigu pavardė yra mažesnė už kitą pavardę, arba pavardės yra lygios,
        /// true, jeigu pavardė yra mažesnė už kitą pavardę, arba pavardės yra lygios,o vardas yra mažesnis už kitą vardą;
        /// </summary>
        /// <param name="st1"></param>
        /// <param name="st2"></param>
        /// <returns></returns>
        public static bool operator <=(Studentas st1, Studentas st2)
        {
            int p = String.Compare(st1.pavardė, st2.pavardė,
            StringComparison.CurrentCulture);
            int v = String.Compare(st1.vardas, st2.vardas,
            StringComparison.CurrentCulture);
            return (p < 0 || (p == 0 && v < 0));
        }
        /// <summary>
        /// Operatorius grąžina true, jeigu pavardė yra didesnė už kitą pavardę, arba pavardės yra lygios,
        /// o vardas yra didesnis už kitą vardą;  false - kitais atvejais.
        /// </summary>
        /// <param name="st1"></param>
        /// <param name="st2"></param>
        /// <returns></returns>
        public static bool operator >=(Studentas st1, Studentas st2)
        {
            int p = String.Compare(st1.pavardė, st2.pavardė,
            StringComparison.CurrentCulture);
            int v = String.Compare(st1.vardas, st2.vardas,
            StringComparison.CurrentCulture);
            return (p > 0 || (p == 0 && v > 0));
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

        /** Grąžina studentų skaičių */
        public int Imti() { return n; }

        /** Grąžina nurodyto indekso studento objektą
        @param i - studento indeksas */
        public Studentas Imti(int i) { return St[i]; }

        /** Padeda į studentų objektų masyvą naują studentą ir
        // masyvo dydį padidina vienetu
        @param ob - studento objektas */
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
        public void Salinti()
        {
            int i = 0;
            while (i < n)
            {
                if (!St[i])
                {
                    for (int j = i; j < n - 1; j++)
                        St[j] = St[j + 1];
                    n=n-1;
                }
                else i++;
            }
        }

    }

    internal class Program
    {
        const string CFd = "C:\\Users\\A&T\\Desktop\\BIT\\C#\\P7\\Fakultetas\\bin\\Debug\\Duomenys.txt";
        const string CFr = "C:\\Users\\A&T\\Desktop\\BIT\\C#\\P7\\Fakultetas\\bin\\Debug\\Rezultatai.txt";
        static void Main(string[] args)
        { 
                Fakultetas grupes = new Fakultetas();
                if (File.Exists(CFr))
                    File.Delete(CFr);
                Skaityti(ref grupes, CFd);
                Spausdinti(grupes, CFr, " Pradinis studentų sąrašas");


            Fakultetas grupes1 = new Fakultetas();
            Fakultetas grupes2 = new Fakultetas();

            Formuoti(grupes, ref grupes1, ref grupes2);
                if (grupes1.Imti() > 0)
                Spausdinti(grupes1, CFr, " Naujas studentų sąrašas");
                 else
                using (var fr = File.AppendText(CFr))
                {
                    fr.WriteLine("Tokių studentų nėra");
                }
            grupes1.Rikiuoti();
            Spausdinti(grupes1, CFr, " Rikuotas studentų sąrašas");


            grupes.Salinti();
            Spausdinti(grupes, CFr, " Šalintas studentų sąrašas");

            Console.WriteLine("Programa baigė darbą!");
        }
        static void Skaityti(ref Fakultetas grupe, string fv)
        {
            string pv, vrd, grp;
            ArrayList pz = new ArrayList();
            string[] lines = File.ReadAllLines(fv, Encoding.GetEncoding("UTF-8"));

            foreach (string line in lines)
            {
                string[] parts = line.Split(';');
                pv = parts[0].Trim();
                vrd = parts[1].Trim();
                grp = parts[2].Trim();
                // Toliau pažymiai
                string[] eil = parts[3].Trim().Split(new[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries);
                pz.Clear();
                foreach (string eilute in eil)
                {
                    int aa = int.Parse(eilute);
                    pz.Add(aa);
                }
                Studentas stud = new Studentas();
                stud.Dėti(pv, vrd, grp, pz);
                grupe.Dėti(stud);
            }
        }
        static void Spausdinti(Fakultetas grupe, string fv, string antraštė)
        {
            string virsus =
            "------------------------------------------\r\n"
            + " Pavardė    Vardas     Grupė     Pažymiai \r\n"
            + "------------------------------------------";
            using (var fr = File.AppendText(fv))
            {
                fr.WriteLine(antraštė);
                fr.WriteLine(virsus);
                for (int i = 0; i < grupe.Imti(); i++)
                    fr.WriteLine("{0}", grupe.Imti(i).ToString());
                fr.WriteLine("------------------------------------------\r\n");
            }
        }
        /// <summary>
        /// Iš pirmojo konteinerio atrenka į antrąjį konteinerį studentus, kurių įvertinimai yra 9 arba 10
        /// </summary>
        /// <param name="D">pirmasis studentų konteineris</param>
        /// <param name="R">antrasis studentų konteineris</param>
        static void Formuoti(Fakultetas D, ref Fakultetas R, ref Fakultetas S)
        {
            for (int i = 0; i < D.Imti(); i++)
                if (!D.Imti(i))
                    ;
                else
                    R.Dėti(D.Imti(i));
        }
       
    }
}

