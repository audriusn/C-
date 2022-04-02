using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB
{
    internal class TaskClass
    {
        public static int dirMax(List<int> dirFilms)
        {
            int max = 0;
            foreach (int num in dirFilms)
                if (num > max)
                    max = num;
            return max;
        }
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
        public static FilmContainer RecomendedFilms (FilmContainer list1, FilmContainer list2)
        {
            FilmContainer recomendedMovie = new FilmContainer();
            
            for (int i = 0; i < list2.Count; i++)
                if(list1.Contains(list2.Get(i)))
                {
                    recomendedMovie.Add(list2.Get(i));
                }
            return recomendedMovie;
        }
       
    }
}
