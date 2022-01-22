using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kelionės_kaina
{
    class Kelias
    {
        private string pav; //kelio pavadinimas
        private double ilgis; // kelios ilgis
        private int lgr;  // leistinas greitis

        public Kelias(string pav, double ilgis, int lgr)
        {
            this.pav = pav;
            this.ilgis = ilgis;
            this.lgr = lgr;
        }
        public void DėtiLeistGreitį(int lg) { lgr = lg; }
        public string ImtiPav() { return pav; }
        public double ImtiIlgį() { return ilgis; }
        public int ImtiLeistGreitį() { return lgr; }
    }
    class Auto
    {
        private string pav;
        private string degalai; 
        private double sąnaudos;  

        public Auto(string pav, string degalai, double sąnaudos)
        {
            this.pav = pav;
            this.degalai = degalai;
            this.sąnaudos = sąnaudos;
        }
        public string ImtiPav() { return pav; }
        public string ImtiDegalus() { return degalai; }
        public double ImtiSąnaudas() { return sąnaudos; }
    }
    class Degalai
    {
        
        private string tipas;
        private double kaina;

        public Degalai(string tipas, double kaina)
        { 
            this.tipas = tipas;
            this.kaina = kaina;
        }
        public string ImtiTipą() { return tipas; }
        public double ImtiKainą() { return kaina; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Kelias k1, k2, k3;
            k1 = new Kelias("Kaunas - Vilnius", 105.00, 110);
            k2 = new Kelias("Kaunas - Alytus", 65.6, 90);
            k3 = new Kelias("Vilnius - Panevėžys", 136.0, 120);
            Console.WriteLine("Keliai (pavadinimas,\t  ilgis,\t    leistinas greitis:)");
            Console.WriteLine("{0},\t {1,10:f2}, {2,15:d}", k1.ImtiPav(), k1.ImtiIlgį(), k1.ImtiLeistGreitį());
            Console.WriteLine("{0},\t {1,10:f2}, {2,15:d}", k2.ImtiPav(), k2.ImtiIlgį(), k2.ImtiLeistGreitį());
            Console.WriteLine("{0},\t {1,10:f2}, {2,15:d}", k3.ImtiPav(), k3.ImtiIlgį(), k3.ImtiLeistGreitį());
            Console.WriteLine();

            Auto a1, a2;
            a1 = new Auto("Opel Meriva", "Benzinas", 7.5);
            a2 = new Auto("VolksWagen Golf", "Dyzelinas", 6.3);
            Console.WriteLine("Automobiliai:");
            Console.WriteLine("{0},\t\t {1},\t {2,8:f2}", a1.ImtiPav(), a1.ImtiDegalus(), a1.ImtiSąnaudas());
            Console.WriteLine("{0},\t {1},\t {2,8:f2}\n", a2.ImtiPav(), a2.ImtiDegalus(), a2.ImtiSąnaudas());

            Degalai d1, d2;
            d1 = new Degalai("Benzinas", 1.38);
            d2 = new Degalai("Dyzelinas", 1.29);

            //double benzkaina, dyzkaina;
            //Console.Write("Kiek kainuoja 1 litras benzino? ");
            //benzkaina = double.Parse(Console.ReadLine());
            //Console.Write("Kiek kainuoja 1 litras dyzelino? ");
            //dyzkaina = double.Parse(Console.ReadLine());
            Console.WriteLine();

            double kaina1, kaina2;
            double atstumas = k1.ImtiIlgį() + k2.ImtiIlgį() + k3.ImtiIlgį();
            if (a1.ImtiDegalus() == d1.ImtiTipą())
                kaina1 = KelionėsKaina(atstumas, a1.ImtiSąnaudas(), d1.ImtiKainą());
            else
                kaina1 = KelionėsKaina(atstumas, a1.ImtiSąnaudas(), d2.ImtiKainą());
            if (a2.ImtiDegalus() == d1.ImtiTipą())
                kaina2 = KelionėsKaina(atstumas, a2.ImtiSąnaudas(), d1.ImtiKainą());
            else
                kaina2 = KelionėsKaina(atstumas, a2.ImtiSąnaudas(), d2.ImtiKainą());

            Console.WriteLine("Automobiliu {0} Iš Alytaus į Panevėžį nuvažiuosime už {1,7:f2} Eur", a1.ImtiPav(), kaina1);
            Console.WriteLine("Automobiliu {0} Iš Alytaus į Panevėžį nuvažiuosime už {1,7:f2} Eur\n", a2.ImtiPav(), kaina2);

            Console.WriteLine("Programa darbą baigė!");
            
        }
        static double KelionėsKaina (double atstumas, double sąnaudos, double litroKaina)
        {
            return (atstumas / 100) * sąnaudos * litroKaina;
        }
    }
}
