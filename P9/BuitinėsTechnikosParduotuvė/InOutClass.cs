using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Globalization;

namespace BuitinėsTechnikosParduotuvė
{
    internal class InOutClass
    {
        /// <summary>
        /// Read file
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static List<Saldytuvas> ReadSaldytuvas(string fileName)
        {
            List<Saldytuvas> sald = new List<Saldytuvas>();
            string[] Lines = File.ReadAllLines(fileName, Encoding.UTF8);
            foreach (string line in Lines)
            {
                string[] Values = line.Split(',');
                string Brand = Values[0];
                string Model = Values[1];
                int Volume = int.Parse(Values[2]);
                string EnergyClass = Values[3];
                string Type = Values[4];
                string Color = Values[5];
                Mark Freezer;
                Enum.TryParse(Values[6], out Freezer);
                int Price = int.Parse(Values[7]);

                Saldytuvas saldytuvai = new Saldytuvas(Brand, Model, Volume, EnergyClass, Type, Color, Freezer, Price);
                sald.Add(saldytuvai);
            }
            return sald;
        }
        /// <summary>
        /// Print all refrigerator list
        /// </summary>
        /// <param name="saldytuvai"></param>
        public static void PrintSaldytuvus(List<Saldytuvas> saldytuvai)
        {
            Console.WriteLine(new string('-', 100));
            Console.WriteLine(" {0,-13} {1,-8}  {2,-8} {3,-12} {4,-14} {5,-10} {6,-10} {7:c}", "Brand", "Model", "Volume", "EnergyClass", "Type", "Color", "Freezer", "Price");
            Console.WriteLine(new string('-', 100));
            foreach (Saldytuvas sald in saldytuvai)
            {
                Console.WriteLine(" {0,-13} {1,-8}  {2,-8} {3,-12} {4,-14} {5,-10} {6,-10} {7:c} ", sald.Brand, sald.Model, sald.Volume, sald.EnergyClass, sald.Type,
                    sald.Color, sald.Freezer, sald.Price);
            }
            Console.WriteLine(new string('-', 100));
        }
        /// <summary>
        /// Print to console all refrigerator types
        /// </summary>
        /// <param name="tipai"></param>
        public static void PrintTypes(List<string> tipai)
        {
            foreach (string tipas in tipai)
            {
                Console.WriteLine(tipas);
            }
        }
        /// <summary>
        /// Print lowest price refrigerators
        /// </summary>
        /// <param name="saldytuvai"></param>
        public static void PrintLowPriceWithFreezer(List<Saldytuvas> saldytuvai)
        {
            Console.WriteLine(new string('-', 50));
            Console.WriteLine(" {0,-13} {1,-8}  {2,-8} {3:c}", "Brand", "Model", "Volume", "Price");
            Console.WriteLine(new string('-', 50));
            foreach (Saldytuvas sald in saldytuvai)
            {
                Console.WriteLine(" {0,-13} {1,-8} {2,-8} {3:c} ", sald.Brand, sald.Model, sald.Volume, sald.Price);
            }
            Console.WriteLine(new string('-', 50));
        }
        /// <summary>
        /// Print filtered data to CSV file
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="Saldyt"></param>
        public static void PrintRefigeratorToCSVFile(string fileName, List<Saldytuvas> Saldyt)
        {
            if (Saldyt.Count > 0)
            {
                string[] lines = new string[Saldyt.Count + 1];
                lines[0] = String.Format("{0} {1}  {2} {3} {4} {5} {6} {7}", "Brand", "Model", "Volume", "EnergyClass", "Type", "Color", "Freezer", "Price"); ;
                for (int i = 0; i < Saldyt.Count; i++)
                {
                    lines[i + 1] = String.Format("{0};{1};{2};{3};{4};{5};{6};{7}", Saldyt[i].Brand, Saldyt[i].Model, Saldyt[i].Volume, Saldyt[i].EnergyClass, Saldyt[i].Type,
                     Saldyt[i].Color, Saldyt[i].Freezer, Saldyt[i].Price);

                }
                File.WriteAllLines(fileName, lines, Encoding.UTF8);
            }
            else
                Console.WriteLine("Sorry, thre are no refrigerator witch are white or have A++ Energy class");

        }
    }
}
