using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Globalization;

namespace JeweleryShop
{
    internal class InOutClass
    {
        /// <summary>
        /// Read file
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static JewelRegister ReadJewels(string filename)
        {
            JewelRegister Jewel = new JewelRegister();
            StreamReader read = new StreamReader(filename);
            string ShopName = read.ReadLine();
            string Address = read.ReadLine();
            string PhoneNR = read.ReadLine();
            Jewel.ShopName = ShopName;
            Jewel.Address = Address;
            Jewel.PhoneNR = PhoneNR;
            string lines;
            while ((lines = read.ReadLine()) != null)
            {
                string[] Values = lines.Split(',');
                string Manufacturer = Values[0];
                string Name = Values[1];
                string Metal = Values[2];
                double Weight = double.Parse(Values[3]);
                double Size = double.Parse(Values[4]);
                int Praba = int.Parse(Values[5]);
                int Price = int.Parse(Values[6]); ;
                Jewel jewels = new Jewel(Manufacturer, Name, Metal, Weight, Size, Praba, Price);
                if (!Jewel.Contains(jewels))
                {
                    Jewel.Add(jewels);
                }
            }
            return Jewel;
        }
        /// <summary>
        /// Print file data
        /// </summary>
        /// <param name="jevel"></param>
        public static void PrintJewel(JewelRegister jevel)
        {
            if (jevel.JewelCount() != 0)
            {
                Console.WriteLine("{0} {1} {2}", jevel.ShopName, jevel.Address, jevel.PhoneNR);
                Console.WriteLine(new string('-', 100));
                Console.WriteLine(" {0,-19} {1,-10}  {2,-10} {3,8} {4,8} {5,10} {6,15:c} ", "Manufacturer", "Name", "Metal", "Weight", "Size", "Praba", "Price");
                Console.WriteLine(new string('-', 100));
                for (int i = 0; i < jevel.JewelCount(); i++)
                {
                    Console.WriteLine(" {0,-19} {1,-10}  {2,-10} {3,8} {4,8} {5,10} {6,15:c}  ", jevel.GetJewel(i).Manufacturer, jevel.GetJewel(i).Name, jevel.GetJewel(i).Metal, jevel.GetJewel(i).Weight, jevel.GetJewel(i).Size,
                        jevel.GetJewel(i).Praba, jevel.GetJewel(i).Price);
                }
                Console.WriteLine(new string('-', 100));
            }
            else
                Console.WriteLine("Sorry, there are no data in file!!!");
        }
         /// <summary>
         /// Print lisy
         /// </summary>
         /// <param name="ziedai"></param>
        public static void PrintZiedus2(List<Jewel> ziedai)
        {
            if (ziedai.Count > 0)
            {
                Console.WriteLine(new string('-', 100));
                Console.WriteLine(" {0,-19} {1,-10}  {2,-10} {3,8} {4,8} {5,10} {6,15:c} ", "Manufacturer", "Name", "Metal", "Weight(gr)", "Size", "Praba", "Price");
                Console.WriteLine(new string('-', 100));
                foreach (Jewel zied in ziedai)
                {
                    Console.WriteLine(" {0,-19} {1,-10}  {2,-10} {3,8} {4,10} {5,10} {6,15:c}", zied.Manufacturer, zied.Name, zied.Metal, zied.Weight, zied.Size,
                        zied.Praba, zied.Price);
                }
            }
            else
                Console.WriteLine("Sorry, the are no rings with top praba");
            Console.WriteLine(new string('-', 100));
        }
        /// <summary>
        /// Print to CSV file
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="Jewels"></param>
        /// <param name="j1"></param>
        /// <param name="j2"></param>
        public static void PrintMetalsToCSVFile(string fileName, List<Jewel> Jewels, JewelRegister j1, JewelRegister j2)
        {
            if (Jewels.Count > 0)
            {
                string[] lines = new string[Jewels.Count + 1];
                lines[0] = String.Format("{0},{1},{2}, {3}, {4}, {5}", "Size", "Metal", "Praba", "Weight", "Price", "ShopName");
                for (int i = 0; i < Jewels.Count(); i++)
                {
                    if(j1.Contains(Jewels[i]) && j2.Contains(Jewels[i]))
                        lines[i+1] = String.Format("{0}, {1}, {2}, {3}, {4}, {5}", Jewels[i].Size, Jewels[i].Metal, Jewels[i].Praba, Jewels[i].Weight, Jewels[i].Price, "Both Shops");
                    if (j1.Contains(Jewels[i]) && !j2.Contains(Jewels[i]))
                        lines[i + 1] = String.Format("{0}, {1}, {2}, {3}, {4}, {5}", Jewels[i].Size, Jewels[i].Metal, Jewels[i].Praba, Jewels[i].Weight, Jewels[i].Price, j1.ShopName);
                    else
                        lines[i + 1] = String.Format("{0}, {1}, {2}, {3}, {4}, {5}", Jewels[i].Size, Jewels[i].Metal, Jewels[i].Praba, Jewels[i].Weight, Jewels[i].Price, j2.ShopName);
                }
                File.WriteAllLines(fileName, lines, Encoding.UTF8);
                Console.WriteLine("Information about rings who are 12 and 13 size and cost less than 300 are in file {0}.", fileName);
            }
            else
                Console.WriteLine("Sorry, the are no rigs in a list");

        }
    }
}
