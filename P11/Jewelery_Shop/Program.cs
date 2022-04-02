using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewelery_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            //Read file and print first candidates list
            JewelContainer cont1 = InOutClass.ReadJewels(@"jewel.csv");
            InOutClass.PrintJewel(cont1);
            Console.WriteLine();
            //Read file and print second candidates list
            JewelContainer cont2 = InOutClass.ReadJewels(@"jewel2.csv");
            InOutClass.PrintJewel(cont2);
            Console.WriteLine();
            //Find top price of platina ring
            int maxPrice = TaskClass.FindMaxPIrce(cont1, cont2);
            JewelContainer cont3 = new JewelContainer();
            TaskClass.MostExpensveRigs(cont3, cont1, maxPrice);
            TaskClass.MostExpensveRigs(cont3, cont2, maxPrice);
            Console.WriteLine("Most expensive ring is:");
            InOutClass.PrintJewel1(cont3);
            Console.WriteLine();
            //Count how manu top praba rings are in shops
            int shop1 = TaskClass.TopPrabaRingCount(cont1);
            Console.WriteLine("Top praba rings in {0} are: {1}", cont1.ShopName, shop1);
            Console.WriteLine();
            int shop2 = TaskClass.TopPrabaRingCount(cont2);
            Console.WriteLine("Top praba rings in {0} are: {1}", cont2.ShopName, shop2);
            Console.WriteLine();
            //Print ring list to CSV file witch are in both shops
            JewelContainer BothShop = TaskClass.BothShop(cont1, cont2);
            InOutClass.PrintRingsToCSVFile("Visur.csv", BothShop);
            //Make a list of 12 and 13 size ring who cost less than 300 ant print it to CSV file
            JewelContainer SmallSizeLowPrice = new JewelContainer();
            TaskClass.LowestPriceSmallSize(SmallSizeLowPrice, cont1);
            TaskClass.LowestPriceSmallSize(SmallSizeLowPrice, cont2);
            Console.WriteLine();
            SmallSizeLowPrice.Sort();
            InOutClass.PrintRingsToCSVFile("Žiedai.csv", SmallSizeLowPrice);
            Console.WriteLine("It's all done!!!");
        }
    }
}
