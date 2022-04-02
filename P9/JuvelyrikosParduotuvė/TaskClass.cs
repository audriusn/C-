using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuvelyrikosParduotuvė
{
    static class TaskClass
    {
        /// <summary>
        /// Find rings who has max weight
        /// </summary>
        /// <param name="zied"></param>
        /// <returns></returns>
        public static double FindMaxWeight(List<Ziedas> zied)
        {
            double maxweight= zied[0].Weight; //mean least value
            for (int i = 0; i < zied.Count; i++)
            {
                if ((zied[i].Weight > maxweight))
                {
                    maxweight = zied[i].Weight;
                }
            }
            return maxweight;
        }
        /// <summary>
        /// Make a list of heaviest rings 
        /// </summary>
        /// <param name="zied"></param>
        /// <returns></returns>
        public static List<Ziedas> LowPriceWithFreezer(List<Ziedas> zied)
        {
            List<Ziedas> RingWeight = new List<Ziedas>();
            double topWeight = FindMaxWeight(zied);
            foreach (Ziedas ziedas in zied)
            {
                if (ziedas.Weight.Equals(topWeight) )
                {
                    RingWeight.Add(ziedas);
                }
            }
            return RingWeight;
        }
        /// <summary>
        /// Make a list of top praba rings
        /// </summary>
        /// <param name="zied"></param>
        /// <returns></returns>
        public static List<Ziedas> HightPrabaRing(List<Ziedas> zied)
        {
            List<Ziedas> RingWeight = new List<Ziedas>();
            foreach (Ziedas ziedas in zied)
            {
                if (ziedas.Praba  == 950 && ziedas.Metal == "Platina")
                {
                    RingWeight.Add(ziedas);
                }
                if (ziedas.Praba == 750 && ziedas.Metal == "Auksas")
                {
                    RingWeight.Add(ziedas);
                }
                if (ziedas.Praba == 925 && ziedas.Metal == "Sidabras")
                {
                    RingWeight.Add(ziedas);
                }
                if (ziedas.Praba == 850 && ziedas.Metal == "Paladis")
                {
                    RingWeight.Add(ziedas);
                }
            }
            return RingWeight;
        }
        /// <summary>
        /// Make a list of metal's
        /// </summary>
        /// <param name="Ziedai"></param>
        /// <returns></returns>
        public static List<string> FindMetal(List<Ziedas> Ziedai)
        {
            List<string> ziedai = new List<string>();
            foreach (Ziedas zied in Ziedai)
            {
                string metal = zied.Metal;
                if (!ziedai.Contains(metal)) //uses List Method Contains()
                {
                    ziedai.Add(metal);
                }
            }
            return ziedai;
        }
    }
}
