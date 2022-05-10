using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Electrical_Device_Shop
{
    static class InOutClass
    {
        public static DeviceContainer ReadDevices(string filename, FridgeContainer Fridges, OvenContainer Ovens, KettleContainer Kettles)
        {
            DeviceContainer Devices = new DeviceContainer();
            StreamReader read = new StreamReader(filename);
            string ShopName = read.ReadLine();
            string Address = read.ReadLine();
            string PhoneNR = read.ReadLine();
            Devices.ShopName = ShopName;
            Devices.Address = Address;
            Devices.PhoneNR = PhoneNR;
            string lines;
            while ((lines = read.ReadLine()) != null)
            {
                string[] Values = lines.Split(',');
                string type = Values[0];
                string Brand = Values[1];
                string Model = Values[2];
                string EnergyClass = Values[3];
                string Color = Values[4];
                int Price = int.Parse(Values[5]);
                switch (type)
                {
                    case "Fridge":
                        int Volume = int.Parse(Values[6]);                     
                        string Type = Values[7];                       
                        Mark Freezer;
                        Enum.TryParse(Values[8], out Freezer);
                        int Height = int.Parse(Values[9]);
                        int Width = int.Parse(Values[10]);
                        int Deep = int.Parse(Values[11]);
                        Fridge fridge = new Fridge(Brand, Model, EnergyClass ,Color, Price, Volume, Type, Freezer, Height, Width, Deep);                       
                        Devices.Add(fridge);                    
                        if (!Fridges.Contains(fridge))
                        {
                            Fridges.Add(fridge);
                        }
                        break;
                    case "Oven":
                        int Power = int.Parse(Values[6]);                      
                        int DifferentPrograms = int.Parse(Values[7]);
                        Oven oven = new Oven(Brand, Model, EnergyClass, Color, Price, Power, DifferentPrograms);                    
                         Devices.Add(oven);
                        if (!Ovens.Contains(oven))
                        {
                            Ovens.Add(oven);
                        }
                        break;
                    case "Kettle":
                        int Power1 = int.Parse(Values[6]);
                        double Volum = double.Parse(Values[7]);
                        Kettle kettle = new Kettle( Brand, Model, EnergyClass, Color, Price, Power1, Volum);                      
                        Devices.Add(kettle);                      
                        if (!Kettles.Contains(kettle))
                        {
                            Kettles.Add(kettle);
                        }
                        break;
                    default:
                        break; //unknown type
                }
            }
            return Devices;
        }
        public static void PrintDevices (DeviceContainer device)
        {
            if (device.Count != 0)
            {
                Console.WriteLine("{0} {1} {2}", device.ShopName, device.Address, device.PhoneNR);
                Console.WriteLine(new string('-', 150));
                Console.WriteLine(" {0,-13} | {1,-8} | {2,-8} | {3,7} | {4,11} | {5, 10} | {6, -13} | {7,7} | {8,6} | {9,5} | {10,5} | {11, 5} | {12,6}", "Brand", "Model", "EnergyClass", "Color", "Price", "Volume", "Type", "Freezer", "Height", "Width", "Deep", "Programs", "Power(Kw)");
                Console.WriteLine(new string('-', 150));
                for (int i = 0; i < device.Count; i++)
                {
                   
                    Console.WriteLine(device.Get(i).ToString());
                }
                Console.WriteLine(new string('-', 150));
            }
            else
                Console.WriteLine("Sorry, there are no data in file!!!");
        }
        public static void PrintFridges(KettleContainer device)
        {
            if (device.Count != 0)
            {
                Console.WriteLine(new string('-', 150));
                Console.WriteLine(" {0,-13} | {1,-8} | {2,-8} | {3,7} | {4,11} | {5, 10} | {6, -13} | {7,7} | {8,6} | {9,5} | {10,5} |", "Brand", "Model", "EnergyClass", "Color", "Price", "Volume", "Type", "Freezer", "Height", "Width", "Deep");
                Console.WriteLine(new string('-', 150));
                for (int i = 0; i < device.Count; i++)
                {

                    Console.WriteLine(device.Get(i).ToString());
                }
                Console.WriteLine(new string('-', 150));
            }
            else
                Console.WriteLine("Sorry, there are no data in file!!!");
        }
        public static void PrintColor(List<string> colors)
        {
            foreach (string color in colors)
            {
                Console.WriteLine(color);
            }
        }
        public static void PrintFridgesPrice(FridgeContainer fridge)
        {
            if (fridge.Count != 0)
            {
                Console.WriteLine("Lowest price A+ EnergyClass refrigerator is:");
                Console.WriteLine(new string('-', 129));
                Console.WriteLine("{0,-14} | {1,-8} | {2,-8} | {3,7} | {4,11} | {5, 10} | {6, -13} | {7,7} | {8,6} | {9,5} | {10,5} |", "Brand", "Model", "EnergyClass", "Color", "Price", "Volume", "Type", "Freezer", "Height", "Width", "Deep");
                Console.WriteLine(new string('-', 129));
                for (int i = 0; i < fridge.Count; i++)
                {
                    Fridge fr = fridge.Get(i);
                    Console.WriteLine("{0,-14} | {1,-8} | {2,-11} | {3,7} | {4,11:c} | {5,10} | {6,-13} | {7,7} | {8,6} | {9,5} | {10,5} |", fr.Brand, fr.Model, fr.EnergyClass, fr.Color,  fr.Price, fr.Volume, fr.Type, fr.Freezer,
                       fr.Height, fr.Width, fr.Deep );
                }
                Console.WriteLine(new string('-', 129));
            }
            else
                Console.WriteLine("Sorry, there are no information about A+ refrigerator prices!!!");
        }
        public static void PrintOvenPrice(OvenContainer oven)
        {
            if (oven.Count != 0)
            {
                Console.WriteLine("Lowest price A+ EnergyClass oven is:");
                Console.WriteLine(new string('-', 94));
                Console.WriteLine("{0,-14} | {1,-8} | {2,-8} | {3,7} | {4,11} | {5, 10} | {6, -13} |", "Brand", "Model", "EnergyClass", "Color", "Price", "Programs", "Power (Kw)");
                Console.WriteLine(new string('-', 94));
                for (int i = 0; i < oven.Count; i++)
                {
                    Oven ov = oven.Get(i);
                    Console.WriteLine("{0,-14} | {1,-8} | {2,-11} | {3,7} | {4,11:c} | {5,10} | {6,-13} |", ov.Brand, ov.Model, ov.EnergyClass, ov.Color, ov.Price, ov.DifferentPrograms, ov.Power);
                }
                Console.WriteLine(new string('-', 94));
            }
            else
                Console.WriteLine("Sorry, there are no information about A+ oven prices!!!");
        }
        public static void PrintKettlePrice(KettleContainer kettle)
        {
            if (kettle.Count != 0)
            {
                Console.WriteLine("Lowest price A+ EnergyClass kettle is:");
                Console.WriteLine(new string('-', 94));
                Console.WriteLine("{0,-14} | {1,-8} | {2,-8} | {3,7} | {4,11} | {5, 10} | {6,-13} |", "Brand", "Model", "EnergyClass", "Color", "Price", "Volume", "Power (Kw)");
                Console.WriteLine(new string('-', 94));
                for (int i = 0; i < kettle.Count; i++)
                {
                    Kettle kt = kettle.Get(i);
                    Console.WriteLine("{0,-14} | {1,-8} | {2,-11} | {3,7} | {4,11:c} | {5,10} | {6,-13} |", kt.Brand, kt.Model, kt.EnergyClass, kt.Color, kt.Price, kt.Volum, kt.Power1);
                }
                Console.WriteLine(new string('-', 94));
            }
            else
                Console.WriteLine("Sorry, there are no information about A+ kettle prices!!!");
        }
        public static void PrintFridgeToCSVFile(string fileName, FridgeContainer fridge)
        {
            if (fridge.Count > 0)
            {
                string[] lines = new string[fridge.Count + 1];
                lines[0] = String.Format(" {0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}", "Brand", "Model", "EnergyClass", "Color", "Price", "Volume", "Type", "Freezer", "Height", "Width", "Deep");
                for (int i = 0; i < fridge.Count; i++)
                {
                    lines[i + 1] = String.Format(" {0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}", fridge.Get(i).Brand, fridge.Get(i).Model,  fridge.Get(i).EnergyClass, fridge.Get(i).Color, fridge.Get(i).Price,
                        fridge.Get(i).Volume, fridge.Get(i).Type, fridge.Get(i).Freezer, fridge.Get(i).Height, fridge.Get(i).Width, fridge.Get(i).Deep);
                }
                File.WriteAllLines(fileName, lines, Encoding.UTF8);
                Console.WriteLine("Information about fridges was printed in {0}.", fileName);
            }
            else
                Console.WriteLine("Sorry, the are no fridges who are in both shops.");
        }
        public static void PrintDeviceToCSVFile(string fileName, DeviceContainer device)
        {
            if (device.Count > 0)
            {
                string[] lines = new string[device.Count + 1];
                lines[0] = String.Format(" {0}, {1}, {2}, {3}, {4}", "Brand", "Model", "EnergyClass", "Color", "Price");
                for (int i = 0; i < device.Count; i++)
                {
                    lines[i + 1] = String.Format(" {0}, {1}, {2}, {3}, {4}", device.Get(i).Brand, device.Get(i).Model, device.Get(i).EnergyClass, device.Get(i).Color, device.Get(i).Price);
                }
                File.WriteAllLines(fileName, lines, Encoding.UTF8);
                Console.WriteLine("Information about devices in all shops was printed in {0}.", fileName);
            }
            else
                Console.WriteLine("Sorry, the are no fridges who are in both shops.");
        }
    }
}
