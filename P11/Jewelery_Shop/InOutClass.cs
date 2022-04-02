using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Globalization;


namespace Jewelery_Shop
{
        internal class InOutClass
        {        
            public static JewelContainer ReadJewels(string filename)
            {
                JewelContainer Jewel = new JewelContainer();
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
            public static void PrintJewel(JewelContainer jevel)
            {
                if (jevel.Count != 0)
                {
                    Console.WriteLine("{0} {1} {2}", jevel.ShopName, jevel.Address, jevel.PhoneNR);
                    Console.WriteLine(new string('-', 100));
                    Console.WriteLine(" {0,-19} {1,-10}  {2,-10} {3,8} {4,8} {5,10} {6,15:c} ", "Manufacturer", "Name", "Metal", "Weight", "Size", "Praba", "Price");
                    Console.WriteLine(new string('-', 100));
                    for (int i = 0; i < jevel.Count; i++)
                    {
                    Jewel jewels = jevel.Get(i);
                    Console.WriteLine(" {0,-19} {1,-10}  {2,-10} {3,8} {4,8} {5,10} {6,15:c}  ", jewels.Manufacturer, jewels.Name, jewels.Metal, jewels.Weight, jewels.Size,
                            jewels.Praba, jewels.Price);
                    }
                    Console.WriteLine(new string('-', 100));
                }
                else
                    Console.WriteLine("Sorry, there are no data in file!!!");
            }
        public static void PrintJewel1(JewelContainer jevel)
        {
            if (jevel.Count != 0)
            {
                Console.WriteLine(new string('-', 100));
                Console.WriteLine(" {0,-19} {1,-10}  {2,-10} {3,8} {4,8} {5,10} {6,15:c} ", "Manufacturer", "Name", "Metal", "Weight", "Size", "Praba", "Price");
                Console.WriteLine(new string('-', 100));
                for (int i = 0; i < jevel.Count; i++)
                {
                    Jewel jewels = jevel.Get(i);
                    Console.WriteLine(" {0,-19} {1,-10}  {2,-10} {3,8} {4,8} {5,10} {6,15:c}  ", jewels.Manufacturer, jewels.Name, jewels.Metal, jewels.Weight, jewels.Size,
                            jewels.Praba, jewels.Price);
                }
                Console.WriteLine(new string('-', 100));
            }
            else
                Console.WriteLine("Sorry, there are no information about most expensive rings!!!");
        }
            /// <summary>
            /// Print to CSV file
            /// </summary>
            /// <param name="fileName"></param>
            /// <param name="Jewels"></param>
            /// <param name="j1"></param>
            /// <param name="j2"></param>
           
        public static void PrintRingsToCSVFile(string fileName, JewelContainer jewel)
        {
            if (jewel.Count > 0)
            {
                string[] lines = new string[jewel.Count + 1];
                lines[0] = String.Format("{0}, {1}, {2}, {3}, {4}, {5}, {6} ", "Manufacturer", "Name", "Metal", "Weight", "Size", "Praba", "Price");
                for (int i = 0; i < jewel.Count; i++)
                {
                    lines[i + 1] = String.Format(" {0}, {1}, {2}, {3}, {4}, {5}, {6}", jewel.Get(i).Manufacturer, jewel.Get(i).Name, jewel.Get(i).Metal, jewel.Get(i).Weight, jewel.Get(i).Size,
                            jewel.Get(i).Praba, jewel.Get(i).Price);
                }
                File.WriteAllLines(fileName, lines, Encoding.UTF8);
                Console.WriteLine("Information about rigs was printed in {0}.", fileName);
            }
            else
                Console.WriteLine("Sorry, the are no rings who are in both shops.");
        }
    }
    }

