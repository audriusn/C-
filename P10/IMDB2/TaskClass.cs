using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB2
{
    internal class TaskClass

    {
        /// <summary>
        /// Make a register of both seen movie list
        /// </summary>
        /// <param name="list1"></param>
        /// <param name="list2"></param>
        /// <returns></returns>
        public static FilmRegister SeenBoth(FilmRegister list1, FilmRegister list2)
        {
            FilmRegister seenBoth = new FilmRegister();
            for (int i = 0; i < list1.FilmCount(); i++)
            {
                for (int j = 0; j < list2.FilmCount(); j++)
                {
                    if (list1.GetFilm(i).Name == list1.GetFilm(j).Name && list1.GetFilm(i).Company == list1.GetFilm(j).Company && list1.GetFilm(i).Director == list1.GetFilm(j).Director)
                        seenBoth.Add(list1.GetFilm(i));
                }
            }
            return seenBoth;
        }

        /// <summary>
        /// Find a most earned money movie
        /// </summary>
        /// <param name="list1"></param>
        /// <param name="list2"></param>
        /// <returns></returns>
        public static double FindMaxProfit (FilmRegister list1, FilmRegister list2)
        {
            double maxProfit = 0;
            if (list1.FindMAxProfit() <= list2.FindMAxProfit())
            
                maxProfit = list2.FindMAxProfit();
            
            else
                maxProfit = list1.FindMAxProfit();
            return maxProfit;
        }
        /// <summary>
        /// Make a register of most earned films
        /// </summary>
        /// <param name="Films"></param>
        /// <param name="list1"></param>
        /// <param name="maxProfit"></param>
        /// <returns></returns>
        public static FilmRegister MaxProfit(FilmRegister Films, FilmRegister list1, double maxProfit)
        {
            FilmRegister film = new FilmRegister();

            for (int i = 0;i < list1.FilmCount();i++)
            {
                if (maxProfit == list1.GetFilm(i).Profit)
                    Films.Add(list1.GetFilm(i));

            }
            return Films;
        }
    }
}
