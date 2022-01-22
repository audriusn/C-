using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sale
{
    class Kede
    {
        private int ilgis; //kėdės ilgis 
        private int plotis; // kėdės plotis
        private int aukštis; // kėdės aukštis

        public Kede(int ilgis, int plotis, int aukštis)
        {
            this.ilgis = ilgis;
            this.plotis = plotis;
            this.aukštis = aukštis;
        }

        public int ImtiIlgį() { return ilgis; }
        public int  ImtiPlotį() { return plotis; }
        public int ImtiAukštį() { return aukštis; }
    }
    class Sale
    {
        private double ilgis; //salės ilgis 
        private double plotis; // salės plotis
       
        public Sale (double ilgis, double plotis)
        {
            this.ilgis = ilgis;
            this.plotis = plotis;
        }
        public void DėtiSalėsIlgį(double ilgis) { this.ilgis = ilgis; }   
        public void DėtiSalėsPlotį(double plotis) { this.plotis = plotis; }    
        public double ImtiIlgį() { return ilgis; }
        public double ImtiPlotį() { return plotis; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            
            Kede k1, k2, k3;
            // Suvedam kėdžių ilgius, pločius ir aukščius
            Console.WriteLine("Įveskite pirmos kėdės ilgį, plotį ir aukštį centimetrais: ");
            k1 = new Kede(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
            Console.WriteLine("Įveskite antros  kėdės ilgį, plotį ir aukštį centimetrais: ");
            k2 = new Kede(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
            Console.WriteLine("Įveskite trečios kėdės ilgį, plotį ir aukštį centimetrais: ");
            k3 = new Kede(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));

            Sale s1;
            s1 = new Sale(20, 30);
           
            Console.Clear();

            Console.WriteLine("Pirmos kėdės:\n Ilgis: {0}cm \n Plotis: {1}cm\n Aukštis: {2}cm", k1.ImtiIlgį(), k1.ImtiPlotį(),k1.ImtiAukštį());
            Console.WriteLine();
            Console.WriteLine("Antros kėdės:\n Ilgis: {0}cm \n Plotis: {1}cm\n Aukštis: {2}cm", k2.ImtiIlgį(), k2.ImtiPlotį(), k2.ImtiAukštį());
            Console.WriteLine();
            Console.WriteLine("Trečios kėdės:\n Ilgis: {0}cm \n Plotis: {1}cm\n Aukštis: {2}cm", k3.ImtiIlgį(), k3.ImtiPlotį(), k3.ImtiAukštį());
            Console.WriteLine();
            Console.WriteLine("Salės:\n Ilgis: {0}m \n Plotis: {1}m", s1.ImtiIlgį(), s1.ImtiPlotį());


            int maxPlotas = KėdėsPlotas(k1.ImtiIlgį(), k1.ImtiPlotį());
            string didKede = "Pirma";
            if (maxPlotas < KėdėsPlotas(k2.ImtiIlgį(), k2.ImtiPlotį()))
            {
                maxPlotas = KėdėsPlotas(k2.ImtiIlgį(), k2.ImtiPlotį());
                didKede = "Antra";
            }
            if (maxPlotas < KėdėsPlotas(k3.ImtiIlgį(), k3.ImtiPlotį()))
            {
                maxPlotas = KėdėsPlotas(k3.ImtiIlgį(), k3.ImtiPlotį());
                didKede = "Trečia";
            }

            Console.WriteLine("Didžiausią plotą užima {0} kėdė ir jo plotas yra {1}cm2", didKede, maxPlotas);
            Console.WriteLine();

            double kedziuSk = 0;
            if( k1.ImtiAukštį()>=40 && k1.ImtiAukštį() <= 50)
            {
                kedziuSk =((SalėsPlotas(s1.ImtiIlgį(), s1.ImtiPlotį())) / KėdėsPlotasEilėms(k1.ImtiIlgį(), k1.ImtiPlotį()));
                Console.WriteLine("Pirmo tipo kėdžių galima sustatyti: {0}", kedziuSk);
            }
            else
                Console.WriteLine("Pirmo tipo kėdė neatitinka reikiamų kriterijų");
            if (k2.ImtiAukštį() >= 40 && k2.ImtiAukštį() <= 50)
            {
                kedziuSk = (SalėsPlotas(s1.ImtiIlgį(), s1.ImtiPlotį())  / KėdėsPlotasEilėms(k2.ImtiIlgį(), k2.ImtiPlotį()));
                Console.WriteLine("Antro tipo kėdžių galima sustatyti: {0}", kedziuSk);
            }
            else
                Console.WriteLine("Antro tipo kėdė neatitinka reikiamų kriterijų");

            if (k3.ImtiAukštį() >= 40 && k3.ImtiAukštį() <= 50)
            {
                kedziuSk = (SalėsPlotas(s1.ImtiIlgį(), s1.ImtiPlotį())  / KėdėsPlotasEilėms(k3.ImtiIlgį(), k3.ImtiPlotį()));
                Console.WriteLine("Trečio tipo kėdžių galima sustatyti: {0}", kedziuSk);
            }
            else
                Console.WriteLine("Trečio tipo kėdė neatitinka reikiamų kriterijų");

            //------ Skaičiuojame naujos salės parametrus
            Console.WriteLine();
            Console.WriteLine("Įveskite naujus salės  ilgį ir plotį metrais: Dabartinis ilgis: {0,3:f1},  Dabartinis plotis: {1,3:f1}", s1.ImtiIlgį(), s1.ImtiPlotį());
            Console.WriteLine();
            Console.WriteLine("Įveskite naują ilgį:");
            s1.DėtiSalėsIlgį(double.Parse(Console.ReadLine()));
            Console.WriteLine("Įveskite naują plotį:");
            s1.DėtiSalėsPlotį(double.Parse(Console.ReadLine()));
            double kedziuSk2 = 0;
            if (k1.ImtiAukštį() >= 40 && k1.ImtiAukštį() <= 50)
            {
                kedziuSk2 = Math.Floor((SalėsPlotas(s1.ImtiIlgį(), s1.ImtiPlotį()) / KėdėsPlotasEilėms(k1.ImtiIlgį(), k1.ImtiPlotį())));
                Console.WriteLine("Pirmo tipo kėdžių galima sustatyti: {0}", kedziuSk2);
            }
            else
                Console.WriteLine("Pirmo tipo kėdė neatitinka reikiamų kriterijų");
            if (k2.ImtiAukštį() >= 40 && k2.ImtiAukštį() <= 50)
            {
                kedziuSk2 = Math.Floor((SalėsPlotas(s1.ImtiIlgį(), s1.ImtiPlotį())  / KėdėsPlotasEilėms(k2.ImtiIlgį(), k2.ImtiPlotį())));
                Console.WriteLine("Antro tipo kėdžių galima sustatyti: {0}", kedziuSk2);
            }
            else
                Console.WriteLine("Antro tipo kėdė neatitinka reikiamų kriterijų");

            if (k3.ImtiAukštį() >= 40 && k3.ImtiAukštį() <= 50)
            {
                kedziuSk2 = Math.Floor((SalėsPlotas(s1.ImtiIlgį(), s1.ImtiPlotį())  / KėdėsPlotasEilėms(k3.ImtiIlgį(), k3.ImtiPlotį())));
                Console.WriteLine("Trečio tipo kėdžių galima sustatyti: {0}", kedziuSk2);
            }
            else
                Console.WriteLine("Trečio tipo kėdė neatitinka reikiamų kriterijų");
            Console.WriteLine();
            
            //--------- trumpinam salės ilgį
           int mazIlgis = 0;
            Console.WriteLine("Įveskite centimetrų skaičių kiek norite sumažinti salė ilgį: ");
            mazIlgis = int.Parse(Console.ReadLine());

            double minKede = Math.Floor((SalėsPlotas(s1.ImtiIlgį(), s1.ImtiPlotį()) / KėdėsPlotasEilėms(k1.ImtiIlgį(), k1.ImtiPlotį())));
            string kedesTipas= "Pirmo";
            if (minKede > Math.Floor((SalėsPlotas(s1.ImtiIlgį(), s1.ImtiPlotį()) / KėdėsPlotasEilėms(k2.ImtiIlgį(), k2.ImtiPlotį()))))
            {
                minKede = Math.Floor((SalėsPlotas(s1.ImtiIlgį(), s1.ImtiPlotį()) / KėdėsPlotasEilėms(k2.ImtiIlgį(), k2.ImtiPlotį())));
                kedesTipas = "Antro";
            }
            if (minKede > Math.Floor((SalėsPlotas(s1.ImtiIlgį(), s1.ImtiPlotį()) / KėdėsPlotasEilėms(k3.ImtiIlgį(), k3.ImtiPlotį()))))
            {
                minKede = Math.Floor((SalėsPlotas(s1.ImtiIlgį(), s1.ImtiPlotį()) / KėdėsPlotasEilėms(k3.ImtiIlgį(), k3.ImtiPlotį())));
                kedesTipas = "Trečio";
            }

            Console.WriteLine("Mažiausiai reikės {0} tipo kėdės", kedesTipas);
            Console.WriteLine();

        }
        // kėdės ploto skaičiavimas
        static int KėdėsPlotas(int Ilgis, int Plotis)
        {
            return Ilgis  * Plotis ;
        }
        static int KėdėsPlotasEilėms(int Ilgis, int Plotis)
        {
            return (Ilgis+30) * Plotis;
        }
        static double SalėsPlotas(double Ilgis, double Plotis)
        {
            return Math.Floor((Ilgis -3) * (Plotis-2)) *1000;
        }
        static double TrumpintasSalėsPlotas(double Ilgis, double Plotis,  int mazIlgis)
        {
            return Math.Floor(((Ilgis - 3)-(mazIlgis/100)) * (Plotis - 2)) * 1000;
        }
    }
}
