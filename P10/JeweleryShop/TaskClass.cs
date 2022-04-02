using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeweleryShop
{
    internal class TaskClass
    {
        /// <summary>
        /// Count top praba jewels
        /// </summary>
        /// <param name="Jewel"></param>
        /// <returns></returns>
        public static int TopPrabaRingCount (JewelRegister Jewel)
        {
            int Count = 0;
            for (int i = 0; i < Jewel.JewelCount(); i++)
            {
                if (Jewel.GetJewel(i).Metal == "Platina" && Jewel.GetJewel(i).Praba == 950)
                   Count++;
                if (Jewel.GetJewel(i).Metal == "Auksas" && Jewel.GetJewel(i).Praba == 750)
                    Count++;
                if (Jewel.GetJewel(i).Metal == "Sidabras" && Jewel.GetJewel(i).Praba == 925)
                    Count++;
                if (Jewel.GetJewel(i).Metal == "Paladis" && Jewel.GetJewel(i).Praba == 850)
                    Count++;
            }
            return Count;
        }
        /// <summary>
        /// Finf anr return max price from both shops
        /// </summary>
        /// <param name="reg1"></param>
        /// <param name="reg2"></param>
        /// <returns></returns>
        public static int FindMaxPIrce(JewelRegister reg1, JewelRegister reg2)
        {
            int maxProfit = 0;
            if (reg1.FindMaxPrice() <= reg2.FindMaxPrice())

                maxProfit = reg2.FindMaxPrice();

            else
                maxProfit = reg1.FindMaxPrice();
            return maxProfit;
        }
        /// <summary>
        /// Make a list of most expensive platina ring
        /// </summary>
        /// <param name="Jewel"></param>
        /// <param name="list1"></param>
        /// <param name="maxPrice"></param>
        /// <returns></returns>
        public static JewelRegister MostExpensvePlatinaRigs(JewelRegister Jewel, JewelRegister list1, int maxPrice)
        {
            for (int i = 0; i < list1.JewelCount(); i++)
            {
                if (maxPrice == list1.GetJewel(i).Price && list1.GetJewel(i).Metal == "Platina")
                    Jewel.Add(list1.GetJewel(i));

            }
            return Jewel;
        }
        /// <summary>
        /// Make a list of 12 and 13 size rings who const less than 300
        /// </summary>
        /// <param name="Jewel"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<Jewel> LowestPrice(List<Jewel> Jewel, JewelRegister list)
        {
            for (int i = 0; i < list.JewelCount(); i++)
            {
                if ((list.GetJewel(i).Size == 12 || list.GetJewel(i).Size == 13) && list.GetJewel(i).Price <= 300)
                    Jewel.Add(list.GetJewel(i));

            }
            return Jewel;
        }
    }
}
