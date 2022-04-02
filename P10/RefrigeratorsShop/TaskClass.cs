using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefrigeratorsShop
{
    internal class TaskClass
    {
        /// <summary>
        /// Find lowest price from both registers
        /// </summary>
        /// <param name="list1"></param>
        /// <param name="list2"></param>
        /// <returns></returns>
        public static int FindLowPrice(FridgeRegister list1, FridgeRegister list2)
        {
            int LowestPrice = 0;
            if (list1.FindLowestPrice() >= list2.FindLowestPrice())

                LowestPrice = list2.FindLowestPrice();

            else
                LowestPrice = list1.FindLowestPrice();
            return LowestPrice;
        }
        /// <summary>
        /// Making a list from both registers with lowest price fridges
        /// </summary>
        /// <param name="Fridge"></param>
        /// <param name="list1"></param>
        /// <param name="LowestPrice"></param>
        /// <returns></returns>
        public static List<Fridge> LowestPrice(List<Fridge> Fridge, FridgeRegister list1, int LowestPrice)
        {
            for (int i = 0; i < list1.FridgeCount(); i++)
            {
                if (LowestPrice == list1.GetFridge(i).Price)
                    Fridge.Add(list1.GetFridge(i));

            }
            return Fridge;
        }
     /// <summary>
     /// Makes registers 
     /// </summary>
     /// <param name="Fridge"></param>
     /// <param name="list1"></param>
     /// <param name="maxPrice"></param>
     /// <returns></returns>
        public static FridgeRegister MostExpensveFridge(FridgeRegister Fridge, FridgeRegister list1, int maxPrice)
        {
            for (int i = 0; i < list1.FridgeCount(); i++)
            {
                if (maxPrice == list1.GetFridge(i).Price)
                    Fridge.Add(list1.GetFridge(i));

            }
            return Fridge;
        }
        /// <summary>
        /// Make new register from both registers with fridges who are in both shops
        /// </summary>
        /// <param name="list1"></param>
        /// <param name="list2"></param>
        /// <returns></returns>
        public static FridgeRegister BothShopList(FridgeRegister list1, FridgeRegister list2)
        {
            FridgeRegister BothShopList = new FridgeRegister();
            for (int i = 0; i < list1.FridgeCount(); i++)
            {
                for (int j = 0; j < list2.FridgeCount(); j++)
                { 
                    if (list1.GetFridge(i).Brand == list2.GetFridge(j).Brand && list1.GetFridge(i).Model == list2.GetFridge(j).Model)
                    BothShopList.Add(list1.GetFridge(i));
                }
            }
            return BothShopList;
        }
    }
}
