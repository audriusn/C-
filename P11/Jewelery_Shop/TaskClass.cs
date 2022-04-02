using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Globalization;

namespace Jewelery_Shop
{
    internal class TaskClass
    {
        public static int FindMaxPIrce(JewelContainer reg1, JewelContainer reg2)
        {
            int maxProfit = 0;
            if (reg1.FindMaxPrice() <= reg2.FindMaxPrice())

                maxProfit = reg2.FindMaxPrice();

            else
                maxProfit = reg1.FindMaxPrice();
            return maxProfit;
        }
        public static JewelContainer MostExpensveRigs(JewelContainer Jewel, JewelContainer list1, int maxPrice)
        {
            for (int i = 0; i < list1.Count; i++)
            {
                if (maxPrice == list1.Get(i).Price )
                    Jewel.Add(list1.Get(i));
            }
            return Jewel;
        }
        public static int TopPrabaRingCount(JewelContainer Jewel)
        {
            int Count = 0;
            for (int i = 0; i < Jewel.Count; i++)
            {
                if (Jewel.Get(i).Metal == "Platina" && Jewel.Get(i).Praba == 950)
                    Count++;
                if (Jewel.Get(i).Metal == "Auksas" && Jewel.Get(i).Praba == 750)
                    Count++;
                if (Jewel.Get(i).Metal == "Sidabras" && Jewel.Get(i).Praba == 925)
                    Count++;
                if (Jewel.Get(i).Metal == "Paladis" && Jewel.Get(i).Praba == 850)
                    Count++;
            }
            return Count;
        }
        public static JewelContainer BothShop(JewelContainer cont1, JewelContainer cont2)
        {
            JewelContainer BothShop = new JewelContainer();
            for (int i = 0; i < cont1.Count; i++)
            {
                if (cont2.Contains(cont1.Get(i)))
                {
                    BothShop.Add(cont1.Get(i));
                }
            }
            return BothShop;
        }
        public static JewelContainer LowestPriceSmallSize (JewelContainer Jewel, JewelContainer list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if ((list.Get(i).Size == 12 || list.Get(i).Size == 13) && list.Get(i).Price <= 300)
                    Jewel.Add(list.Get(i));
            }
            return Jewel;
        }
    }
}
