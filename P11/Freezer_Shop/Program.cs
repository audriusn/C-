using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freezer_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.Unicode;
            //Read file and print first candidates list
            FridgeContainer cont1 = InOutClass.ReadFridges(@"saldytuvai.csv");
            InOutClass.PrintFridges(cont1);
            Console.WriteLine();
            //Read file and print second candidates list
            FridgeContainer cont2 = InOutClass.ReadFridges(@"saldytuvai2.csv");
            InOutClass.PrintFridges(cont2);
            Console.WriteLine();
            //Finds and print fridges volume
            List<int> vol = new List<int>();
            cont1.FindVolume(vol);
            cont2.FindVolume(vol);
            InOutClass.PrintVolume(vol);
            //Finds and print lowest price standing fridge with freezer
            FridgeContainer Filreted = new FridgeContainer();
            double minPrice = TaskClass.LowestPriceFrige(cont1, cont2);
            TaskClass.LowestPriceFrigeContainer(Filreted, cont1, minPrice);
            TaskClass.LowestPriceFrigeContainer(Filreted, cont2, minPrice);
            InOutClass.PrintSaldytuvusList(Filreted, cont1, cont2);

            //Finds and print A++ energy class and white color
            FridgeContainer TopEnergyClassWhite = new FridgeContainer();
            cont1.FIlteredFridgeByColorAndEnergy(TopEnergyClassWhite);
            cont2.FIlteredFridgeByColorAndEnergy(TopEnergyClassWhite);
            TopEnergyClassWhite.Sort();
            InOutClass.PrintFridgeToCSVFile("Baltieji.csv", TopEnergyClassWhite);

            FridgeContainer BothShop = TaskClass.BothShop(cont1, cont2);
            InOutClass.PrintFridgeToCSVFile("Abi.csv", BothShop);

            Console.WriteLine("It's all done!!");

        }
    }
}
