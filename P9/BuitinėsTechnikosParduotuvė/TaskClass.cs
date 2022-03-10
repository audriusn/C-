using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuitinėsTechnikosParduotuvė
{
    static class TaskClass
    {
    /// <summary>
    ///  Make a list of regrigerator types 
    /// </summary>
    /// <param name="Saldytuvai"></param>
    /// <returns></returns>
        public static List<string> FindTypes(List<Saldytuvas> Saldytuvai)
        {
            List<string> saldytuvai = new List<string>();
            foreach (Saldytuvas sald in Saldytuvai)
            {
                string tipas = sald.Type;
                if (!saldytuvai.Contains(tipas)) //uses List Method Contains()
                {
                    saldytuvai.Add(tipas);
                }
            }
            return saldytuvai;
        }
        /// <summary>
        /// Finds lowes refigerator price
        /// </summary>
        /// <param name="sald"></param>
        /// <returns></returns>
        public static int FindLowestPrice(List<Saldytuvas> sald)
        {
            int LowestPrice = sald[0].Price; //mean least value
            for (int i = 0; i < sald.Count; i++)
            {
                if ((sald[i].Price < LowestPrice))
                {
                    LowestPrice = sald[i].Price;
                }
            }
            return LowestPrice;
        }
     /// <summary>
     /// Make a list of lowest price, type = pastatomas, mark freerzer = Taip refrigerators
     /// </summary>
     /// <param name="sald"></param>
     /// <param name="Freezer"></param>
     /// <returns></returns>
        public static List<Saldytuvas> LowPriceWithFreezer(List<Saldytuvas> sald, Mark Freezer)
        {
            List<Saldytuvas> Filteredsaldytuvai = new List<Saldytuvas>();
            int LowestPrice = FindLowestPrice(sald);
            foreach (Saldytuvas saldytuvas in sald)
            {
                if (saldytuvas.Price.Equals(LowestPrice)  && saldytuvas.Freezer.Equals(Freezer) && saldytuvas.Type == "Pastatomas")
                {
                    Filteredsaldytuvai.Add(saldytuvas);
                }
            }
            return Filteredsaldytuvai;
        }
        /// <summary>
        /// Make a list of refrigerator color = Baltas, EbergyClas = A++
        /// </summary>
        /// <param name="Saldyt"></param>
        /// <returns></returns>
        public static List<Saldytuvas> RefrigetatorToCsv(List<Saldytuvas> Saldyt)
        {
            List<Saldytuvas> Refrig = new List<Saldytuvas>();
            foreach (Saldytuvas sald in Saldyt)
            {
                if (sald.Color == "Baltas" && sald.EnergyClass == "A++")
                    Refrig.Add(sald);
            }
            return Refrig;
        }

    }
}
