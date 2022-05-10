using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Electrical_Device_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.Unicode;
            FridgeContainer allFridges = new FridgeContainer();
            OvenContainer allOvens = new OvenContainer();
            KettleContainer allKettles = new KettleContainer();

            DeviceContainer Shop1 = InOutClass.ReadDevices(@"Shop1.csv", allFridges, allOvens, allKettles);
            DeviceContainer Shop2 = InOutClass.ReadDevices(@"Shop2.csv", allFridges, allOvens, allKettles);
            DeviceContainer Shop3 = InOutClass.ReadDevices(@"Shop3.csv", allFridges, allOvens, allKettles);
            InOutClass.PrintDevices(Shop1);
            InOutClass.PrintDevices(Shop2);
            InOutClass.PrintDevices(Shop3);
            Console.WriteLine("");
            //Make and print fridge color list
            List<string> FridgeColorList = allFridges.FridgeColor(allFridges);
            Console.WriteLine("Refrigerator colors:");
            InOutClass.PrintColor(FridgeColorList);
            Console.WriteLine("");
            Console.WriteLine("");
            //Make and print kettle color list
            List<string> KettleColorList = allKettles.KettleColor(allKettles);
            Console.WriteLine("Kettle colors:");
            InOutClass.PrintColor(KettleColorList);
            Console.WriteLine("");
            //Find and print lowest price A+ energy class fridge
            FridgeContainer LowPriceAPlusFridge = allFridges.LowestPriceAPliusEnergyClass(allFridges);
            InOutClass.PrintFridgesPrice(LowPriceAPlusFridge);
            Console.WriteLine("");
            //Find and print lowest price A+ energy class oven
            OvenContainer LowPriceAPlusOven = allOvens.LowestPriceAPliusEnergyClassOven(allOvens);
            InOutClass.PrintOvenPrice(LowPriceAPlusOven);
            Console.WriteLine("");
            //Find and print lowest price A+ energy class kettle
            KettleContainer LowPriceAPlusKettle = allKettles.LowestPriceAPliusEnergyClassKettle(allKettles);
            InOutClass.PrintKettlePrice(LowPriceAPlusKettle);
            Console.WriteLine("");
            //Print fridges beetween 52 and 56 width to csv file
            FridgeContainer SizeLimit = allFridges.NormalSizeFridge(allFridges);
            SizeLimit.Sort(new DeviceComparatorByPrice());
            InOutClass.PrintFridgeToCSVFile("Visi.csv", SizeLimit);
            //Print devices who are in all shops to CSV file
            DeviceContainer AllShops = DeviceContainer.AllShops(Shop1, Shop2, Shop3);
            InOutClass.PrintDeviceToCSVFile("Visur.csv", AllShops);
            Console.WriteLine("");
            Console.WriteLine("It'a all done!");

        }
    }
}
