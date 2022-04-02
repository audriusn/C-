using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freezer_Shop
{
    internal class TaskClass
    {
       public static double LowestPriceFrige (FridgeContainer cont1, FridgeContainer cont2 )
        {
            double minPrice = 0;
            if (cont1.FindLowestPriceStandingFridge() <= cont2.FindLowestPriceStandingFridge())
                minPrice = cont1.FindLowestPriceStandingFridge();
            else
                minPrice = cont2.FindLowestPriceStandingFridge();
            return minPrice;
        }
        public static FridgeContainer LowestPriceFrigeContainer(FridgeContainer Filtered, FridgeContainer cont1, double minPrice)
        {
            for(int i = 0; i < cont1.Count; i++)
            {
                if(cont1.Get(i).Type == "Pastatomas" && cont1.Get(i).Freezer == Mark.TAIP && minPrice > cont1.Get(i).Price)
                {
                    if(!Filtered.Contains(cont1.Get(i)))
                        Filtered.Add(cont1.Get(i));
                }
            }
            return Filtered;
        }
        public static FridgeContainer BothShop (FridgeContainer cont1, FridgeContainer cont2)
        {
            FridgeContainer BothShop = new FridgeContainer();
            for (int i = 0;i < cont1.Count;i++)
            {
                if(cont2.Contains(cont1.Get(i)))
                {
                    BothShop.Add(cont1.Get(i));
                }
            }
            return BothShop;
        }
    }
}
