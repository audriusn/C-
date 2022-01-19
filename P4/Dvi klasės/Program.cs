using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dvi_klasės
{
    class Plyta
    {
        private int ilgis,
                    plotis,
                    aukšis;
        public Plyta(int ilgis, int pločioReikšmė, int aukščioreikšmė)
        {
            this.ilgis = ilgis;
            plotis = pločioReikšmė;
            aukšis = aukščioreikšmė;

        }
        public int ImtiIlgį() { return ilgis; }
        public int ImtiPLotį() { return plotis; }
        public int ImtiAukštį() { return aukšis; }

    }

    class Siena
    {

        private double ilgis;
        private double plotis;
        private double aukštis;

        public Siena(double ilgis, double plotis, double aukštis)
        {
            this.ilgis = ilgis;
            this.plotis = plotis;
            this.aukštis = aukštis;
        }
        public double ImtiIlgį() { return ilgis; }
        public double ImtiPlotį() { return plotis; }
        public double ImtiAukštį() { return aukštis; }
    }
    class Bokstas
    {

        private double aukštis;
        private double skersmuo;
        private double storis;

        public Bokstas (double aukštis, double skersmuo, double storis)
        {
            this.aukštis = aukštis;
            this.skersmuo = skersmuo;
            this.storis = storis;
        }
        public double ImtiAukštį() { return aukštis; }
        public double ImtiSkermenį() { return skersmuo; }
        public double ImtiStorį() { return storis; }
    }

    class Program
    {
        static void Main(string[] args)
        {

            Plyta p1;
            p1 = new Plyta(250, 120, 88);
            Plyta p2;
            p2 = new Plyta(240, 115, 71);
            Plyta p3;
            p3 = new Plyta(240, 115, 61);

            Siena s1;
            s1 = new Siena(12.0, 0.23, 3.0);
            Siena s2;
            s2 = new Siena(6.0, 0.23, 3.0);
            Siena s3;
            s3 = new Siena(15.0, 0.23, 3.0);

            Bokstas b1;
            b1 = new Bokstas(10.0, 5.0, 1.0);


            Console.WriteLine();
            Console.WriteLine("Pirmojo tipo plytos:");
            SpausdintiPlytą(p1);
         
            Console.WriteLine();
            Console.WriteLine("1-ojo tipo plytų reikia: {0,6:d} \n", (4 * ReikiaPlytų(p1, s1)));
            Console.WriteLine();

            Console.WriteLine("Antrojo tipo plytos:");
            SpausdintiPlytą(p2);
            Console.WriteLine("2-ojo tipo plytų reikia: {0,6:d} \n", (4 * ReikiaPlytų(p2, s1)));
            Console.WriteLine();

            Console.WriteLine("Trečiojo tipo plytos:");
            SpausdintiPlytą(p3);
            Console.WriteLine("3-ojo tipo plytų reikia: {0,6:d} \n", (4 * ReikiaPlytų(p3, s1)));

            Console.WriteLine("--------------Skirtingų namo sienų skaičiavimai------------");

            Console.WriteLine();
            Console.WriteLine("Pirmojo tipo plytos:");
            SpausdintiPlytą(p1);

            Console.WriteLine();
            Console.WriteLine("1-ojo tipo plytų reikia: {0,6:d} \n", (2 * ReikiaPlytų(p1, s2)) + (2 * ReikiaPlytų(p1, s3)));
            Console.WriteLine();

            Console.WriteLine("Antrojo tipo plytos:");
            SpausdintiPlytą(p2);
            Console.WriteLine("2-ojo tipo plytų reikia: {0,6:d} \n", (2 * ReikiaPlytų(p2, s2)) + (2 * ReikiaPlytų(p2, s3)));
            Console.WriteLine();

            Console.WriteLine("Trečiojo tipo plytos:");
            SpausdintiPlytą(p3);
            Console.WriteLine("3-ojo tipo plytų reikia: {0,6:d} \n", (2 * ReikiaPlytų(p3, s2)) + (2 * ReikiaPlytų(p3, s3)));

            Console.WriteLine("--------------Pilies plytų  skaičiavimai------------");

            Console.WriteLine();
            Console.WriteLine("Pirmojo tipo plytos:");
            SpausdintiPlytą(p1);

            Console.WriteLine();
            Console.WriteLine("1-ojo tipo plytų reikia: {0,6:d} \n", (2 * ReikiaPlytų(p1, s2)) + (2 * ReikiaPlytų(p1, s3)) + (2*(bokstoPlytos(p1, b1))));
            Console.WriteLine();

            Console.WriteLine("Programa darbą baigė!");
        }

            static void SpausdintiPlytą(Plyta p)
            {
                Console.WriteLine("Plytos ilgis: {0,3:d} \nPlytos plotis: {1,4:d} \nPlytos aukštis: {2,5:d}", p.ImtiIlgį() , p.ImtiPLotį(), p.ImtiAukštį());
            }

            static void SpausdintiSieną(Siena s)
            {
            Console.WriteLine("Sienos ilgis:\t {0,6:f2} \nSienos plotis:\t {1,6:f2} \nSienos aukštis:\t{2,6:f2} \n", s.ImtiIlgį(), s.ImtiPlotį(), s.ImtiAukštį());
        }
        static int ReikiaPlytų(Plyta p, Siena s)
            {
            return (int)(s.ImtiIlgį() * 1000 / p.ImtiIlgį() *
              s.ImtiPlotį() * 1000 / p.ImtiPLotį() *
              s.ImtiAukštį() * 1000 / p.ImtiAukštį());
             }
        static int bokstoPlytos(Plyta p, Bokstas b)
        {
            return (int)((b.ImtiSkermenį() * Math.PI * 1000) / p.ImtiIlgį() * b.ImtiAukštį() * 1000 / p.ImtiPLotį() * b.ImtiStorį() * 1000 / p.ImtiAukštį());
        }
    }
    } 
 


