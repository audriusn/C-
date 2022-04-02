using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeweleryShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.Unicode;
            //Read file and print first candidates list
            JewelRegister reg1 = InOutClass.ReadJewels(@"jewel.csv");
            InOutClass.PrintJewel(reg1);
            Console.WriteLine();
            //Read file and print second candidates list
            JewelRegister reg2 = InOutClass.ReadJewels(@"jewel2.csv");
            InOutClass.PrintJewel(reg2);
            Console.WriteLine();
            //Count how manu top praba rings aare in shops
            int shop1 = TaskClass.TopPrabaRingCount(reg1);
            Console.WriteLine("Top praba rings in {0} are: {1}", reg1.ShopName, shop1);
            Console.WriteLine();
            int shop2 = TaskClass.TopPrabaRingCount(reg2);
            Console.WriteLine("Top praba rings in {0} are: {1}", reg2.ShopName, shop2);
            Console.WriteLine();
            //Find top price of platina ring
            int maxPrice = TaskClass.FindMaxPIrce(reg1, reg2);
            JewelRegister reg3 = new JewelRegister();
            TaskClass.MostExpensvePlatinaRigs(reg3, reg1, maxPrice);
            TaskClass.MostExpensvePlatinaRigs(reg3, reg2, maxPrice);
            Console.WriteLine("Most expensive platina ring is:");
            InOutClass.PrintJewel(reg3);
            //Make a list of 12 and 13 size ring who cost less than 300 ant print it to CSV file
            List<Jewel> SmallSizeLowPrice = new List<Jewel>();
            TaskClass.LowestPrice(SmallSizeLowPrice, reg1);
            TaskClass.LowestPrice(SmallSizeLowPrice, reg2);
            Console.WriteLine();
            InOutClass.PrintMetalsToCSVFile("Žiedai.CSV",SmallSizeLowPrice, reg1, reg2);
        }
    }
}
