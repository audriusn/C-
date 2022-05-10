using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ilgiausia_teksto_eilutė
{
    internal class Program
    {
        const string CFd = "C:\\Users\\A&T\\Desktop\\BIT\\C#\\P13\\Ilgiausia_teksto_eilutė\\bin\\Debug\\Tekstas.txt";
        const string CFr = "C:\\Users\\A&T\\Desktop\\BIT\\C#\\P13\\Ilgiausia_teksto_eilutė\\bin\\Debug\\rez.txt";
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            int nr;
            Skaityti(CFd, out nr);
            Console.WriteLine("Ilgiausios eilutės nr. {0.4:d}", nr+1);
            Console.WriteLine("Programa darbą baigė!");
        }
        static void Skaityti (string fv, out int nr)
        {
            string [] lines = File.ReadAllLines(fv, Encoding.GetEncoding(1257));
            int ilgis = 0;
            nr =0;
            int nreil = 0;
            foreach (string line in lines)
            {
                if(line.Length > ilgis)
                {
                    ilgis =line.Length;
                    nr = nreil;
                }
                nreil++;
            }
        }
    }
}
