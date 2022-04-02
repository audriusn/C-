using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Globalization;

namespace IMDB2
{
    static class InOutClass
    {
        /// <summary>
        /// Reading file
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static FilmRegister ReadFilms(string filename)
        {
            FilmRegister Films = new FilmRegister();
            StreamReader read = new StreamReader(filename);
            string Hname = read.ReadLine();
            int birthYear = int.Parse(read.ReadLine());
            string city = read.ReadLine();
            string lines;
            while((lines = read.ReadLine()) != null)
            {
                string[] Values = lines.Split(',');
                string Name = Values[0];
                int Year = int.Parse(Values[1]);
                string Genre = Values[2];
                string Company = Values[3];
                string Director = Values[4];
                string Actor1 = Values[5];
                string Actor2 = Values[6];
                int Profit = int.Parse(Values[7]);
                Film film = new Film(Name, Year, Genre, Company, Director, Actor1, Actor2, Profit);
                if (!Films.Contains(film))
                {
                    Films.Add(film);
                }
            }
            return Films;
        }
        /// <summary>
        /// Printing films list
        /// </summary>
        /// <param name="films"></param>
        public static void PrintFilms(FilmRegister films)
        {
            if (films.FilmCount() != 0)
            {
                Console.WriteLine(new string('-', 150));
            Console.WriteLine(" {0,-22} {1,-6}  {2,-10} {3,-35} {4,-18} {5,-15} {6,-15} {7:c}", "Name", "Year", "Type", "Company", "Director", "Actor", "Actor", "Profit");
            Console.WriteLine(new string('-', 150));
            for (int i = 0; i < films.FilmCount(); i++)
            {
                Console.WriteLine(" {0,-22} {1,-6}  {2,-10} {3,-35} {4,-18} {5,-15} {6,-15} {7:c} ", films.GetFilm(i).Name, films.GetFilm(i).Year, films.GetFilm(i).Genre, films.GetFilm(i).Company, films.GetFilm(i).Director,
                    films.GetFilm(i).Actor1, films.GetFilm(i).Actor2, films.GetFilm(i).Profit);
            }
            Console.WriteLine(new string('-', 150));
            }
            else
                Console.WriteLine("Sorry, there are no data in file!!!");
        }
        /// <summary>
        /// Print both seen movie list
        /// </summary>
        /// <param name="films"></param>
        public static void PrintFilmsSeenBoth(FilmRegister films)
        {
            if (films.FilmCount() != 0)
            {
                Console.WriteLine(new string('-', 150));
                Console.WriteLine(" {0,-22} {1,-6}  {2,-10} {3,-35} {4,-18} {5,-15} {6,-15} {7:c}", "Name", "Year", "Type", "Company", "Director", "Actor", "Actor", "Profit");
                Console.WriteLine(new string('-', 150));
                for (int i = 0; i < films.FilmCount(); i++)
                {
                    Console.WriteLine(" {0,-22} {1,-6}  {2,-10} {3,-35} {4,-18} {5,-15} {6,-15} {7:c} ", films.GetFilm(i).Name, films.GetFilm(i).Year, films.GetFilm(i).Genre, films.GetFilm(i).Company, films.GetFilm(i).Director,
                        films.GetFilm(i).Actor1, films.GetFilm(i).Actor2, films.GetFilm(i).Profit);
                }
                Console.WriteLine(new string('-', 150));
            }
            else
                Console.WriteLine("Sorry, there are films that they seen both");
        }
        /// <summary>
        /// Print both seen movie lists to CSV file
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="films"></param>
        public static void PrintFilmsToCSVFile(string fileName, FilmRegister films)
        {
            if (films.FilmCount() > 0)
            {
                string[] lines = new string[films.FilmCount() + 1];
            lines[0] = String.Format(" {0,-22} {1,-6}  {2,-10} {3,-35} {4,-18} {5,-15} {6,-15} {7:c}", "Name", "Year", "Type", "Company", "Director", "Actor", "Actor", "Profit");
            for (int i = 0; i < films.FilmCount(); i++)
            {
                lines[i + 1] = String.Format(" {0,-22} {1,-6}  {2,-10} {3,-35} {4,-18} {5,-15} {6,-15} {7} ", films.GetFilm(i).Name, films.GetFilm(i).Year, films.GetFilm(i).Genre, films.GetFilm(i).Company, films.GetFilm(i).Director,
                        films.GetFilm(i).Actor1, films.GetFilm(i).Actor2, films.GetFilm(i).Profit);
            }
            File.WriteAllLines(fileName, lines);
            }
            else
                Console.WriteLine("The list of films is empty.");
        }
        /// <summary>
        /// Print genre to CSV file
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="Genres"></param>
        public static void PrintGenreToCSVFile(string fileName, List <string> Genres ) 
        {
            if (Genres.Count() > 0)
            {

                string[] lines = new string[Genres.Count() + 1];
                lines[0] = String.Format(" {0}",  "Genres:");
                for (int i =0; i < Genres.Count(); i++)
                {
                    lines[i + 1] = String.Format(" {0} ", Genres[i]);
                }
                File.WriteAllLines(fileName, lines, Encoding.UTF8);
            }
            else
                Console.WriteLine("The list of genres is empty.");
        }

    }
   
}
