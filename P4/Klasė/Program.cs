using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klasė
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
   
    class Program
    {
        static void Main(string[] args)
        {
            double sienosIlgis = 12.0,  // antras žingnis
                   sienosPlotis = 0.23, // antras žingnis
                   sienosAukštis = 3.00,
                   bokštoSkersmuo = 10.0,
                   bokštoAukštis = 15.0, 
                   sienosStoris = 3.00;

            Plyta p1;
            p1 = new Plyta(250, 120, 88);
            SpausdintiPlytą(p1);
            //Console.WriteLine("Plytos aukštis: {0,3:d} \nPlytos plotis: {1,4:d} \nPlytos ilgis: {2,5:d}",p1.ImtiAukštį(), p1.ImtiPLotį(), p1.ImtiIlgį()); 
            //int k1;
            //k1 = (int)(sienosIlgis * 1000 / p1.ImtiIlgį() *                         
            //    sienosPlotis * 1000 / p1.ImtiPLotį() *                               
            //    sienosAukštis * 1000 / p1.ImtiAukštį());                             
            Console.WriteLine("1-0 tipo plytų reikia: {0,6:d}\n ",  Bokštas(p1, bokštoSkersmuo, bokštoAukštis, sienosStoris));

            // trečias žingnis

            Plyta p2;                      
            p2 = new Plyta(240, 115, 71);
            SpausdintiPlytą(p2);
            //Console.WriteLine("Plytos aukštis: {0,3:d} \nPlytos plotis: {1,4:d} \nPlytos ilgis: {2,5:d}", p2.ImtiAukštį(), p2.ImtiPLotį(), p2.ImtiIlgį());
            //int k2;
            //k2 = (int)(sienosIlgis * 1000 / p2.ImtiIlgį() *                         
            //    sienosPlotis * 1000 / p2.ImtiPLotį() *                               
            //    sienosAukštis * 1000 / p2.ImtiAukštį());                            
            Console.WriteLine("2-0 tipo plytų reikia: {0,6:d}\n ", Bokštas(p2, bokštoSkersmuo, bokštoAukštis, sienosStoris));

            // penktas žingnis

            Plyta p3;                      
            p3 = new Plyta(240, 115, 61);
            SpausdintiPlytą(p3);
            //Console.WriteLine("Plytos aukštis: {0,3:d} \nPlytos plotis: {1,4:d} \nPlytos ilgis: {2,5:d}", p3.ImtiAukštį(), p3.ImtiPLotį(), p3.ImtiIlgį());  
            //int k3;
            //k3 = (int)(sienosIlgis * 1000 / p3.ImtiIlgį() *                          
            //    sienosPlotis * 1000 / p3.ImtiPLotį() *                               
            //    sienosAukštis * 1000 / p3.ImtiAukštį());                             
            Console.WriteLine("3-0 tipo plytų reikia: {0,6:d}\n ", Bokštas(p3, bokštoSkersmuo, bokštoAukštis, sienosStoris));
            Console.WriteLine("Programa baigė darbą!");
        }
        // ketvirtas žingnis
        static int VienaSiena(Plyta p, double sienosPlotis, double sienosIlgis, double sienosAukštis)     
        {
            return (int)(sienosIlgis * 1000 / p.ImtiIlgį() *                                             
                         sienosPlotis * 1000 / p.ImtiPLotį() *                                           
                         sienosAukštis * 1000 / p.ImtiAukštį());                                       
        }

        // Šeštas žingnis
        static void SpausdintiPlytą(Plyta p)
        {
            Console.WriteLine("Plytos aukštis: {0,3:d} \nPlytos plotis: {1,4:d} \nPlytos ilgis: {2,5:d}", p.ImtiAukštį(), p.ImtiPLotį(), p.ImtiIlgį());
        }

        static int Bokštas(Plyta p, double bokštoSkersmuo, double bokštoAukštis, double sienosStoris)
        {
        
            return (int)((bokštoSkersmuo * Math.PI*1000) / p.ImtiIlgį() * bokštoAukštis* 1000/ p.ImtiPLotį() * sienosStoris*1000 / p.ImtiAukštį());

                           
        }
    }

}
