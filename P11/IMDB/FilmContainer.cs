using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB
{
        class FilmContainer
        {
            private Film[] films;
            public int Count { get; private set; }
            public FilmContainer(int capacity = 50)
            {
                this.films = new Film[capacity];
            }
            public string Hname { get; set; }
            public int birthYear { get; set; }
            public string city { get; set; }
        public void Add(Film film)
            {
                if (this.Count == this.Capacity) // container is full
                {
                    EnsureCapacity(this.Capacity * 2);
                }
                this.films[this.Count++] = film;
            }
            private int Capacity;
            private void EnsureCapacity(int minimumCapacity)
            {
                if (minimumCapacity > this.Capacity)
                {
                    Film[] temp = new Film[minimumCapacity];
                    for (int i = 0; i < this.Count; i++)
                    {
                        temp[i] = this.films[i];
                    }
                    this.Capacity = minimumCapacity;
                    this.films = temp;
                }
            }
            public Film Get(int index)
            {
                return this.films[index];
            }
            public bool Contains(Film film)
            {
                for (int i = 0; i < this.Count; i++)
                {
                    if (this.films[i].Equals(film))
                    {
                        return true;
                    }
                }
                return false;
            }

            public void Put(int index, Film film)
            {
                this.films[index] = film;
            }
            public void Insert(int index, Film film)
            {
                if (this.Count == this.Capacity)
                {
                    EnsureCapacity(Capacity * 2);
                }
                for (int i = Count + 1; i > index; i--)
                {
                    this.films[i] = this.films[i - 1];
                }
                this.films[index] = film;
                Count++;
            }
            public void RemoveAt(int index)
            {
                for (int i = index; i < Count; i++)
                {
                    this.films[i] = this.films[i + 1];
                }
                Count--;
            }
            public void Remove(Film film)
            {
                for (int i = 0; i < Count; i++)
                {
                    if (this.films[i].Name == film.Name)
                    {
                        RemoveAt(i);
                        return;
                    }
                }
            }
            public void Sort()
            {
                for (int i = 0; i < this.Count - 1; i++)
                {
                    Film film = this.films[i];
                    int im = i;
                    for (int j = i + 1; j < this.Count; j++)
                        if (this.films[j] <= film)
                        {
                            film = this.films[j];
                            im = j;
                        }
                    this.films[im] = this.films[i];
                    this.films[i] = film;
                }
            }
            public FilmContainer(FilmContainer container) : this()
            {
                for (int i = 0; i < container.Count; i++)
                {
                    this.Add(container.Get(i));
                }
            }
            public FilmContainer Intersect(FilmContainer other)
            {
            FilmContainer result = new FilmContainer();
                for (int i = 0; i < this.Count; i++)
                {
                    Film current = this.films[i];
                    if (other.Contains(current))
                    {
                        result.Add(current);
                    }
                }
                return result;
            }
        public static List<string> FindDirectors(FilmContainer films)
        {
            List<string> Directors = new List<string>();
            for (int i = 0; i < films.Count; i++)
            {
                string director = films.Get(i).Director;
                if (!Directors.Contains(director)) //uses List Method Contains()

                    Directors.Add(director);
            }
            return Directors;
        }
        public static List<int> CountDirectors(FilmContainer films)
        {
            List<string> Directors = FindDirectors(films);
            List<int> CountDirector = new List<int>();
            for (int i = 0; i < Directors.Count; i++)
            {
                int count = 0;
                for (int j = 0; j < films.Count; j++)
                {
                    if (Directors[i] == films.Get(j).Director)
                        count++;
                }
                CountDirector.Add(count);
            }
            return CountDirector;
        }
      

        public double FindMAxProfit(FilmContainer films)
        {
            double maxProfit = double.MinValue;
            for (int i = 0; i < films.Count; i++)
            {
                if (this.films[i].Profit > maxProfit)
                {
                    maxProfit = this.films[i].Profit;
                }
            }
            return maxProfit;
        }
        public static double FindMaxProfit(FilmContainer list1, FilmContainer list2)
        {
            double maxProfit = 0;
            if (list1.FindMAxProfit(list1) <= list2.FindMAxProfit(list2))

                maxProfit = list2.FindMAxProfit(list2);

            else
                maxProfit = list1.FindMAxProfit(list1);
            return maxProfit;
        }
        public static FilmContainer MaxProfit(FilmContainer Films, FilmContainer list1, double maxProfit)
        {
            FilmContainer film = new FilmContainer();

            for (int i = 0; i < list1.Count; i++)
            {
                if (maxProfit == list1.Get(i).Profit)
                    Films.Add(list1.Get(i));

            }
            return Films;
        }
        public List<string> filmTypes(FilmContainer Films)
        {
            List<string> Genre = new List<string>();
            for (int i = 0; i < Films.Count; i++)
            {
                if (!Genre.Contains(Films.Get(i).Genre))

                    Genre.Add(Films.Get(i).Genre);

            }
            return Genre;
        }
    }
}

