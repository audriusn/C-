using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Globalization;


namespace RefrigeratorsShop
{
    internal class InOutClass
    {
        /// <summary>
        /// Reading files and making registers
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static FridgeRegister ReadFridges(string filename)
        {
            FridgeRegister Fridges = new FridgeRegister();
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
        public static void PrintFridges(FridgeRegister fridge)
        {
            if (fridge.FridgeCount() != 0)
            {
                Console.WriteLine("{0} {1} {2}", fridge.ShopName, fridge.Address, fridge.PhoneNR);
                Console.WriteLine(new string('-', 100));
                Console.WriteLine(" {0,-13} {1,-8}  {2,-8} {3,-12} {4,-14} {5,-10} {6,-10} {7:c}", "Brand", "Model", "Volume", "EnergyClass", "Type", "Color", "Freezer", "Price");
                Console.WriteLine(new string('-', 100));
                for (int i = 0; i < fridge.FridgeCount(); i++)
                {
                    Console.WriteLine(" {0,-13} {1,-8}  {2,-8} {3,-12} {4,-14} {5,-10} {6,-10} {7:c} ", fridge.GetFridge(i).Brand, fridge.GetFridge(i).Model, fridge.GetFridge(i).Volume, fridge.GetFridge(i).EnergyClass, fridge.GetFridge(i).Type,
                        fridge.GetFridge(i).Color, fridge.GetFridge(i).Freezer, fridge.GetFridge(i).Price);
                }
                Console.WriteLine(new string('-', 100));
            }
            else
                Console.WriteLine("Sorry, there are no data in file!!!");
        }
        /// <summary>
        /// Printing lowest price fridges list aand them shops
        /// </summary>
        /// <param name="saldytuvai"></param>
        /// <param name="f1"></param>
        /// <param name="f2"></param>
        public static void PrintSaldytuvusList(List<Fridge> saldytuvai, FridgeRegister f1, FridgeRegister f2)
        {
            if (saldytuvai.Count() > 0)
            {
                Console.WriteLine(new string('-', 67));
                Console.WriteLine("Lowest price stationary refrigerator with freezer you can find in:");
                Console.WriteLine(new string('-', 67));
                Console.WriteLine(" {0,-13} {1,-8}  {2,-8} {3:c} {4,20}", "Brand", "Model", "Volume", "Price", "ShopName");
                Console.WriteLine(new string('-', 67));
                foreach (Fridge sald in saldytuvai)
                {
                    if (f1.Contains(sald) && f2.Contains(sald))                   
                        Console.WriteLine(" {0,-13} {1,-8}  {2,-8} {3:c} {4, 20} ", sald.Brand, sald.Model, sald.Volume, sald.Price, "Both shop");                   
                    if (f1.Contains(sald) && !f2.Contains(sald))                   
                        Console.WriteLine(" {0,-13} {1,-8}  {2,-8} {3:c} {4, 20} ", sald.Brand, sald.Model, sald.Volume, sald.Price, f1.ShopName);                  
                    else                  
                        Console.WriteLine(" {0,-13} {1,-8}  {2,-8} {3:c} {4, 20} ", sald.Brand, sald.Model, sald.Volume, sald.Price, f2.ShopName);                   
                }
                Console.WriteLine(new string('-', 67));
            }
            else
                Console.WriteLine("Sorry,the are no information about lowest price fridge with freezer!!!");
        }
        /// <summary>
        /// Printing one shop most expensive fridge brand
        /// </summary>
        /// <param name="fridge"></param>
        /// <param name="f1"></param>
        public static void PrintFridgesMostExpensive(FridgeRegister fridge, FridgeRegister f1)
        {
            if (fridge.FridgeCount() != 0)
            {
                Console.WriteLine(new string('-', 110));
                Console.WriteLine(" In shop: {0} Address: {1} Phone: {2}. Most expensive refrigerator brand is:", f1.ShopName, f1.Address, f1.PhoneNR);
                Console.WriteLine(new string('-', 110));
                for (int i = 0; i < fridge.FridgeCount(); i++)
                {
                    Console.WriteLine(" {0,-13}", fridge.GetFridge(i).Brand);
                }
                Console.WriteLine(new string('-', 110));
            }
            else
                Console.WriteLine("Sorry, there are no data about expensive fridge!!!");
        }
        /// <summary>
        /// Printing fridge register who are in both shops in CS file
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="fridge"></param>
        public static void PrintFridgeToCSVFile(string fileName, FridgeRegister fridge)
        {
            if (fridge.FridgeCount() > 0)
            {
                string[] lines = new string[fridge.FridgeCount() + 1];
                lines[0] = String.Format(" {0} {1} {2} {3} {4} {5} {6} {7}", "Brand", "Model", "Volume", "EnergyClass", "Type", "Color", "Freezer", "Price");
                for (int i = 0; i < fridge.FridgeCount(); i++)
                {
                    lines[i + 1] = String.Format(" {0} {1} {2} {3} {4} {5} {6} {7}", fridge.GetFridge(i).Brand, fridge.GetFridge(i).Model, fridge.GetFridge(i).Volume, fridge.GetFridge(i).EnergyClass, fridge.GetFridge(i).Type,
                        fridge.GetFridge(i).Color, fridge.GetFridge(i).Freezer, fridge.GetFridge(i).Price);
                }
                File.WriteAllLines(fileName, lines);
                Console.WriteLine("Information about fridges who are in both shops was printed in {0}.", fileName);
            }
            else
                Console.WriteLine("Sorry, the are no fridges who are in both shops.");
        }
    }
    
}
