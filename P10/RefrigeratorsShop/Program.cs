using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefrigeratorsShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.Unicode;
            //Read file and print first candidates list
            FridgeRegister reg1 = InOutClass.ReadFridges(@"saldytuvai.csv");
            InOutClass.PrintFridges(reg1);
            Console.WriteLine();
            //Read file and print second candidates list
            FridgeRegister reg2 = InOutClass.ReadFridges(@"saldytuvai2.csv");
            InOutClass.PrintFridges(reg2);
            Console.WriteLine();
            //Making new filtered registers: Pastatomomas = Taip, Freezer = Taip.
            FridgeRegister list1 = reg1.FridgeWithFreezerAndStandable(reg1);
            FridgeRegister list2 = reg2.FridgeWithFreezerAndStandable(reg2);
            // Find and printe lowest price fridge
            int LowestPrice = TaskClass.FindLowPrice(list1, list2);
            List<Fridge> list3 = new List<Fridge>();
            TaskClass.LowestPrice(list3, list1, LowestPrice);
            TaskClass.LowestPrice(list3, list2, LowestPrice);
            InOutClass.PrintSaldytuvusList(list3, reg1, reg2);
            Console.WriteLine();
            Console.WriteLine();
            // Find ant print most exprensice fridge in shop 1
            int MaxPrice = reg1.FindMaxPrice();
            FridgeRegister MostExp = new FridgeRegister();
            FridgeRegister MostExp1 = TaskClass.MostExpensveFridge(MostExp, reg1, MaxPrice);
            Console.WriteLine();
            InOutClass.PrintFridgesMostExpensive(MostExp1, reg1);
            // Find ant print most exprensice fridge in shop 2
            int MaxPrice2 = reg2.FindMaxPrice();
            FridgeRegister MostExp2 = new FridgeRegister();
            FridgeRegister MostExp3 = TaskClass.MostExpensveFridge(MostExp2, reg2, MaxPrice2);  
            InOutClass.PrintFridgesMostExpensive(MostExp3, reg2);
            Console.WriteLine();
            // Find a fringes who are in both shops and print it to CSV file
            FridgeRegister BothShopLsit = TaskClass.BothShopList(reg1, reg2);
            InOutClass.PrintFridgeToCSVFile("Abi.csv", BothShopLsit);
            Console.WriteLine();
            Console.WriteLine("Program end all jobs!!");

        }
    }
}
