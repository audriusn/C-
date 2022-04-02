using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB2
{
     class FilmRegister
    {
        private List<Film> Allfilms;
        public FilmRegister()
        {
            Allfilms = new List<Film>();
        }

        public FilmRegister(List<Film> Films)
        {
            Allfilms = new List<Film>();
            foreach (Film film in Films)
            {
                this.Allfilms.Add(film);
            }
        }
        public void Add(Film film)
        {
            Allfilms.Add(film);
        }
        public bool Contains(Film film)
        {
            return Allfilms.Contains(film);
        }
        public int FilmCount()
        {
            return this.Allfilms.Count;
        }
        public Film GetFilm(int index)
        {
            return this.Allfilms[index];
        }
        /// <summary>
        /// Find a max profit
        /// </summary>
        /// <returns></returns>
      public double FindMAxProfit()
        {
            double maxProfit = double.MinValue;
            foreach(Film film in this.Allfilms)
            {
                if(film.Profit > maxProfit)
                    maxProfit = film.Profit;
            }
            return maxProfit;
        }
        /// <summary>
        /// Make a list of genres
        /// </summary>
        /// <param name="genre"></param>
        /// <returns></returns>
        public List<string> filmTypes(List<string> genre)
        {
            foreach(Film film in this.Allfilms)
            {
                if(!genre.Contains(film.Genre))
                
                    genre.Add(film.Genre);
           
            }
            return genre;
        }
    }
}
