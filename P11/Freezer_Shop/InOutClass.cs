using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Globalization;


namespace Freezer_Shop
{
    internal class InOutClass
    {
        /// <summary>
        /// Reading files and making registers
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static FridgeContainer ReadFridges(string filename)
        {
            FridgeContainer Fridges = new FridgeContainer();
            StreamReader read = new StreamReader(filename);
            string ShopName = read.ReadLine();
            string Address = read.ReadLine();
            string PhoneNR = read.ReadLine();
            Fridges.ShopName = ShopName;
            Fridges.Address = Address;
            Fridges.PhoneNR = PhoneNR;
            string lines;
            while ((lines = read.ReadLine()) != null)
            {
                string[] Values = lines.Split(',');
                string Brand = Values[0];
                string Model = Values[1];
                int Volume = int.Parse(Values[2]);
                string EnergyClass = Values[3];
                string Type = Values[4];
                string Color = Values[5];
                Mark Freezer;
                Enum.TryParse(Values[6], out Freezer);
                int Price = int.Parse(Values[7]);
                Fridge fridge = new Fridge(Brand, Model, Volume, EnergyClass, Type, Color, Freezer, Price);
                if (!Fridges.Contains(fridge))
                {
                    Fridges.Add(fridge);
                }
            }
            return Fridges;
        }
        /// <summary>
        /// Printing information from file
        /// </summary>
        /// <param name="fridge"></param>
        public static void PrintFridges(FridgeContainer fridge)
        {
            if (fridge.Count != 0)
            {
                Console.WriteLine("{0} {1} {2}", fridge.ShopName, fridge.Address, fridge.PhoneNR);
                Console.WriteLine(new string('-', 100));
                Console.WriteLine(" {0,-13} {1,-8}  {2,-8} {3,-12} {4,-14} {5,-10} {6,-10} {7:c}", "Brand", "Model", "Volume", "EnergyClass", "Type", "Color", "Freezer", "Price");
                Console.WriteLine(new string('-', 100));
                for (int i = 0; i < fridge.Count; i++)
                {
                    Fridge fr = fridge.Get(i);
                    Console.WriteLine(" {0,-13} {1,-8}  {2,-8} {3,-12} {4,-14} {5,-10} {6,-10} {7:c} ", fr.Brand, fr.Model, fr.Volume, fr.EnergyClass, fr.Type,
                        fr.Color, fr.Freezer, fr.Price);
                }
                Console.WriteLine(new string('-', 100));
            }
            else
                Console.WriteLine("Sorry, there are no data in file!!!");
        }
        /// <summary>
        /// Printing fridges volume int list
        /// </summary>
        /// <param name="Volume"></param>
        public static void PrintVolume(List<int> Volume)
        {
            if (Volume.Count != 0)
            {
                Console.WriteLine(new string('-',40));
                Console.WriteLine("In shops are these volume refrigerator:");
                for (int i = 0; i < Volume.Count; i++)
                {
                    Console.WriteLine(" {0,-13}", Volume[i]);
                }
                Console.WriteLine(new string('-', 40));
            }
            else
                Console.WriteLine("Sorry, there are no data about expensive fridge!!!");
        }
        /// <summary>
        /// Printing lowest price fridges list aand them shops
        /// </summary>
        /// <param name="saldytuvai"></param>
        /// <param name="f1"></param>
        /// <param name="f2"></param>
        public static void PrintSaldytuvusList(FridgeContainer saldytuvai, FridgeContainer f1, FridgeContainer f2)
        {
            if (saldytuvai.Count > 0)
            {
                Console.WriteLine(new string('-', 67));
                Console.WriteLine("Lowest price stationary refrigerator with freezer you can find in:");
                Console.WriteLine(new string('-', 67));
                Console.WriteLine(" {0,-13} {1,-8}  {2,-8} {3:c} {4,20}", "Brand", "Model", "Volume", "Price", "ShopName");
                Console.WriteLine(new string('-', 67));
                for(int i = 0;i < saldytuvai.Count; i++)
                {
                    Fridge fr = saldytuvai.Get(i);
                    if (f1.Contains(saldytuvai.Get(i)) && f2.Contains(saldytuvai.Get(i)))
                        Console.WriteLine(" {0,-13} {1,-8}  {2,-8} {3:c} {4, 20} ", fr.Brand, fr.Model, fr.Volume, fr.Price, "Both shop");
                    else if (f1.Contains(fr))
                        Console.WriteLine(" {0,-13} {1,-8}  {2,-8} {3:c} {4, 20} ", fr.Brand, fr.Model, fr.Volume, fr.Price, f1.ShopName);
                    else
                        Console.WriteLine(" {0,-13} {1,-8}  {2,-8} {3:c} {4, 20} ", fr.Brand, fr.Model, fr.Volume, fr.Price, f2.ShopName);
                }
                Console.WriteLine(new string('-', 67));
            }
            else
                Console.WriteLine("Sorry,the are no information about lowest price fridge with freezer!!!");
        }
       
        /// <summary>
        /// Printing fridge register who are in both shops in CSV file
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="fridge"></param>
        public static void PrintFridgeToCSVFile(string fileName, FridgeContainer fridge)
        {
            if (fridge.Count > 0)
            {
                string[] lines = new string[fridge.Count + 1];
                lines[0] = String.Format(" {0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}", "Brand", "Model", "Volume", "EnergyClass", "Type", "Color", "Freezer", "Price");
                for (int i = 0; i < fridge.Count; i++)
                {
                    lines[i + 1] = String.Format(" {0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}", fridge.Get(i).Brand, fridge.Get(i).Model, fridge.Get(i).Volume, fridge.Get(i).EnergyClass, fridge.Get(i).Type,
                         fridge.Get(i).Color, fridge.Get(i).Freezer, fridge.Get(i).Price);
                }
                File.WriteAllLines(fileName, lines);
                Console.WriteLine("Information about fridges was printed in {0}.", fileName);
            }
            else
                Console.WriteLine("Sorry, the are no fridges who are in both shops.");
        }
    }
}
