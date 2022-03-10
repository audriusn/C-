using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Globalization;

namespace TuristuInformacijosCentras
{

    static class TaskClass
    {
        /// <summary>
        /// Count how many museums have guide in Kaunas
        /// </summary>
        /// <param name="Museums">Museum List</param>
        /// <param name="Guide"> Guide Yes/NO</param>
        /// <param name="town">City</param>
        /// <returns></returns>
        public static int CountByGuide(List<Museum> Museums, Guide Guide, string town)
        {
            int count = 0;
            foreach (Museum museum in Museums)
            {
                if (museum.Guide.Equals(Guide) && museum.miestas.Equals(town))
                {
                    count++;
                }
            }
            return count;
        }
        /// <summary>
        /// Printing Kaunas museums with guide sum
        /// </summary>
        /// <param name="Museums">Museum List</param>
        public static void PrintCountByGuide( List<Museum> Museums)
        {
            string selectedCity = "Kaunas";
          
                if (CountByGuide(Museums, Guide.Taip, selectedCity) > 0)
                {
                   Console.WriteLine("Kaune yra {0} muziejais su gidais", CountByGuide(Museums, Guide.Taip, selectedCity));
                }
                else Console.WriteLine("Atsiprašome, bet Kaune muziejų su gidais nėra");
        }
        /// <summary>
        /// Count how many museums working on wednesday in Vilnius
        /// </summary>
        /// <param name="Museums">Museum List</param>
        /// <param name="treciadienis">Wednesday value</param>
        /// <param name="town">City</param>
        /// <returns></returns>
        public static int CountVLNOnWensday(List<Museum> Museums, int treciadienis, string town)
        {
            int count = 0;
            foreach (Museum museum in Museums)
            {

                if (museum.treciadienis.Equals(treciadienis) && museum.miestas.Equals(town))
                {
                    count++;
                }
            }
            return count;
        }
        /// <summary>
        /// Make a list with museums types working wednesday in Vilnius
        /// </summary>
        /// <param name="Museums">Museum List</param>
        /// <param name="treciadienis"> Wednesday value</param>
        /// <param name="town">City</param>
        /// <returns></returns>
        public static List<string> TypesVLNOnWensday(List<Museum> Museums, int treciadienis, string town)
        {      
            List<string> VLNtipai = new List<string>();
            foreach (Museum museum in Museums)
            {
                string tipas = museum.tipas;
                
                if (museum.treciadienis.Equals(treciadienis) && museum.miestas.Equals(town) && (!VLNtipai.Contains(tipas)))        
                    VLNtipai.Add(tipas);
            }
            return VLNtipai;
        }

        /// <summary>
        /// Filtering by City and more than 3 working days 
        /// </summary>
        /// <param name="Museums"></param>
        /// <param name="miestas"></param>
        /// <returns></returns>
        public static List<Museum> FilterByCity(List<Museum> Museums, string miestas)
        {
            List<Museum> Filtered = new List<Museum>();
            foreach (Museum museum in Museums)
            {    
                if (museum.miestas.Equals(miestas) && (museum.pirmadienis + museum.antradienis + museum.treciadienis + museum.ketvirtadienis + museum.penktadienis + museum.sestadienis + museum.sekmadienis) >=3) //uses string method Equals()
                {
                    Filtered.Add(museum);
                }
            }
            return Filtered;
        }
    }
}
