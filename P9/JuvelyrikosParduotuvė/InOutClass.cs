using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Globalization;

namespace JuvelyrikosParduotuvė
{
    static class InOutClass
    {
        /// <summary>
        /// reading file
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static List<Ziedas> ReadZiedus(string fileName)
        {
            List<Ziedas> ziedai = new List<Ziedas>();
            string[] Lines = File.ReadAllLines(fileName, Encoding.UTF8);
            foreach (string line in Lines)
            {
                string[] Values = line.Split(',');
                string Manufacturer = Values[0];
                string Name = Values[1];
                string Metal = Values[2];
                double Weight =double.Parse(Values[3]);
                double Size = double.Parse(Values[4]);
                int Praba = int.Parse(Values[5]);           
                int Price = int.Parse(Values[6]);
                Ziedas zied = new Ziedas(Manufacturer, Name, Metal, Weight, Size, Praba, Price);
                ziedai.Add(zied);
            }
            return ziedai;
        }
        /// <summary>
        /// Printing  list from file
        /// </summary>
        /// <param name="ziedai"></param>
        public static void PrintZiedus(List<Ziedas> ziedai)
        {
            if (ziedai.Count > 0)
            {
                Console.WriteLine(new string('-', 100));
                Console.WriteLine(" {0,-19} {1,-10}  {2,-10} {3,8} {4,8} {5,10} {6,15:c} ", "Manufacturer", "Name", "Metal", "Weight(gr)", "Size", "Praba", "Price");
                Console.WriteLine(new string('-', 100));
                foreach (Ziedas zied in ziedai)
                {
                    Console.WriteLine(" {0,-19} {1,-10}  {2,-10} {3,8} {4,10} {5,10} {6,15:c}", zied.Manufacturer, zied.Name, zied.Metal, zied.Weight, zied.Size,
                        zied.Praba, zied.Price);
                }
            }
            else
                Console.WriteLine("Sorry, the are no item in a list");
            Console.WriteLine(new string('-', 100));
        }
        /// <summary>
        /// Printing heaviest rings list
        /// </summary>
        /// <param name="ziedai"></param>
        public static void PrintTopWeight(List<Ziedas> ziedai)
        {
            Console.WriteLine(new string('-', 80));
            Console.WriteLine("  {0,-10}  {1,-10} {2,8} {3,8} {4,10}  ",  "Name", "Metal", "Weight(gr)", "Size", "Praba");
            Console.WriteLine(new string('-', 80));
            foreach (Ziedas zied in ziedai)
            {
                Console.WriteLine(" {0,-10}  {1,-10} {2,8} {3,10} {4,10} ",  zied.Name, zied.Metal, zied.Weight, zied.Size,
                    zied.Praba);
            }
            Console.WriteLine(new string('-', 80));
        }
        /// <summary>
        /// Printing top praba rings
        /// </summary>
        /// <param name="ziedai"></param>
        public static void PrintZiedus2(List<Ziedas> ziedai)
        {
            if (ziedai.Count > 0)
            {
                Console.WriteLine(new string('-', 100));
                Console.WriteLine(" {0,-19} {1,-10}  {2,-10} {3,8} {4,8} {5,10} {6,15:c} ", "Manufacturer", "Name", "Metal", "Weight(gr)", "Size", "Praba", "Price");
                Console.WriteLine(new string('-', 100));
                foreach (Ziedas zied in ziedai)
                {
                    Console.WriteLine(" {0,-19} {1,-10}  {2,-10} {3,8} {4,10} {5,10} {6,15:c}", zied.Manufacturer, zied.Name, zied.Metal, zied.Weight, zied.Size,
                        zied.Praba, zied.Price);
                }
            }
            else
                Console.WriteLine("Sorry, the are no  rings with top praba");
            Console.WriteLine(new string('-', 100));
        }
        /// <summary>
        /// Printing a rigs metal list in CSV file
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="ziedai"></param>
        public static void PrintMetalsToCSVFile(string fileName, List<string> ziedai)
        {
            if (ziedai.Count > 0)
            {
                string[] lines = new string[ziedai.Count + 1];
                lines[0] = String.Format("{0}", "Metal:"); ;
                for (int i = 0; i < ziedai.Count; i++)
                {
                    lines[i + 1] = String.Format("{0}", ziedai[i]);
                }
                File.WriteAllLines(fileName, lines, Encoding.UTF8);
            }
            else
                Console.WriteLine("Sorry, the are no rigs in a list");

        }
    }
}
