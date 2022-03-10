using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB
{
    /// <summary>
    /// Find biggest profit
    /// </summary>
    static class TaskClass
    {
        public static int FindBigestProfit(List<Film> Fimls, int year)
        {
            int Maxprofit = Fimls[0].Profit; //mean least value
            for (int i = 1; i < Fimls.Count; i++)
            {       
                if (Fimls[i].Profit >= Maxprofit && Fimls[i].Year == year)
                {
                    Maxprofit = Fimls[i].Profit;
                }
            }
            return Maxprofit;
        }
        /// <summary>
        /// Make a list  for max profit
        /// </summary>
        /// <param name="Films"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public static List<Film> FindMax(List<Film> Films, int year)
        {
            List<Film> MaxProfit = new List<Film>();
            foreach (Film film in Films)
            {
                if (film.Year.Equals(year) && film.Profit.Equals(FindBigestProfit(Films, 2019)))
                {
                    MaxProfit.Add(film);
                }
            }
            return MaxProfit;
        }
        /// <summary>
        /// Make a list from directors
        /// </summary>
        /// <param name="Films"></param>
        /// <returns></returns>

        public static List<string> FindDirectors(List<Film> Films)
        {
            List<string> Directors = new List<string>();
            foreach (Film film in Films)
            {
                string director = film.Director;
                if (!Directors.Contains(director)) //uses List Method Contains()

                    Directors.Add(director);
            }
            return Directors;
        }
        /// <summary>
        /// Count a directors films
        /// </summary>
        /// <param name="Films"></param>
        /// <returns></returns>
        public static List<int> CountDirectors(List<Film> Films)
        {
            List <string> Directors = FindDirectors(Films);
            List<int> CountDirector = new List<int>();
            for (int i = 0; i < Directors.Count; i++)
            { 
                int count=0;
                foreach (Film film in Films)
                {   
                    if (Directors[i] == film.Director)      
                      count++;
                }
                CountDirector.Add(count);
            }
            return CountDirector;
        }
        /// <summary>
        /// Find a max number of film by director (return int)
        /// </summary>
        /// <param name="dirFilms"></param>
        /// <returns></returns>
        public static int dirMax(List<int> dirFilms)
        {
            int max = 0;
            foreach(int num in dirFilms)
                if(num> max)
                    max = num;
            return max;
        }
        /// <summary>
        /// Make a list of most film made directors
        /// </summary>
        /// <param name="Directors"></param>
        /// <param name="dirFilms"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static List<string> FindMaxCountDirector(List<string> Directors, List<int> dirFilms, int max)
        {
            List<string> MAXCountDirector = new List<string>();       
            for (int i = 0; i < Directors.Count; i++)
            {
                if (dirFilms[i] == max)               
                    MAXCountDirector.Add(Directors[i]);                       
            }  
            return MAXCountDirector;
        }
        public static  List<Film> NCageFimls(List<Film> Films)
        {
            List<Film>CageFilms = new List<Film>();
            foreach(Film film in Films)
            {
                if (film.Actor1 == "Nicolas Cage" || film.Actor2 == "Nicolas Cage")
                    CageFilms.Add(film);
            }
            return CageFilms;
        }

    }
}
