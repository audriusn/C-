using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Globalization;

namespace IMDB
{
    static class InOutClass
    {
        /// <summary>
        /// Reading file
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static FilmContainer ReadFilms(string filename)
        {
            FilmContainer Films = new FilmContainer();
            StreamReader read = new StreamReader(filename);
            string Hname = read.ReadLine();
            Films.Hname = Hname;
            int birthYear = int.Parse(read.ReadLine());
            Films.birthYear = birthYear;
            string city = read.ReadLine();
            Films.city = city;
            string lines;
            while ((lines = read.ReadLine()) != null)
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
        public static void PrintFilms(FilmContainer films)
        {
            if (films.Count != 0)
            {
                Console.WriteLine("Movie list of: {0} {1} {2}", films.Hname, films.birthYear, films.city);
                Console.WriteLine(new string('-', 150));
                Console.WriteLine(" {0,-22} {1,-6}  {2,-10} {3,-35} {4,-18} {5,-15} {6,-15} {7:c}", "Name", "Year", "Type", "Company", "Director", "Actor", "Actor", "Profit");
                Console.WriteLine(new string('-', 150));
                for (int i = 0; i < films.Count; i++)
                {
                    Film film = films.Get(i);
                    Console.WriteLine(" {0,-22} {1,-6}  {2,-10} {3,-35} {4,-18} {5,-15} {6,-15} {7:c} ", film.Name, film.Year, film.Genre, film.Company, film.Director,
                        film.Actor1, film.Actor2, film.Profit);
                }
                Console.WriteLine(new string('-', 150));
            }
            else
                Console.WriteLine("Sorry, there are no data in file!!!");
        }
        public static void PrintFilms1(FilmContainer films)
        {
            if (films.Count != 0)
            {
                Console.WriteLine(new string('-', 150));
                Console.WriteLine(" {0,-22} {1,-6}  {2,-10} {3,-35} {4,-18} {5,-15} {6,-15} {7:c}", "Name", "Year", "Type", "Company", "Director", "Actor", "Actor", "Profit");
                Console.WriteLine(new string('-', 150));
                for (int i = 0; i < films.Count; i++)
                {
                    Film film = films.Get(i);
                    Console.WriteLine(" {0,-22} {1,-6}  {2,-10} {3,-35} {4,-18} {5,-15} {6,-15} {7:c} ", film.Name, film.Year, film.Genre, film.Company, film.Director,
                        film.Actor1, film.Actor2, film.Profit);
                }
                Console.WriteLine(new string('-', 150));
            }
            else
                Console.WriteLine("Sorry, there are no information about most earned money movie.");
        }
        public static void PrintDirectors(List<string> Directors, FilmContainer films )
        {
            Console.WriteLine("Favorite director of {0} is: ", films.Hname);
            if (Directors.Count != 0)
            {
                foreach (string director in Directors)
                {
                    Console.WriteLine(director);
                }
            }
            else
                Console.WriteLine("Sorry, there are no information that person have favorite director.");
        }

                /// <summary>
                /// Print both seen movie lists to CSV file
                /// </summary>
                /// <param name="fileName"></param>
                /// <param name="films"></param>
                public static void PrintFilmsToCSVFile(string fileName, FilmContainer films)
        {
            if (films.Count > 0)
            {
                string[] lines = new string[films.Count + 1];
                lines[0] = String.Format(" {0,-22}, {1,-6}, {2,-10}, {3,-35}, {4,-18}, {5,-15}, {6,-15}, {7:c}", "Name", "Year", "Type", "Company", "Director", "Actor", "Actor", "Profit");
                for (int i = 0; i < films.Count; i++)
                {
                    Film film = films.Get(i);
                    lines[i + 1] = String.Format(" {0,-22}, {1,-6},  {2,-10}, {3,-35}, {4,-18}, {5,-15}, {6,-15}, {7} ", film.Name, film.Year, film.Genre, film.Company, film.Director,
                            film.Actor1, film.Actor2, film.Profit);
                }
                File.WriteAllLines(fileName, lines, Encoding.UTF8);
            }
            else
                Console.WriteLine("The list of recomended films is empty.");
        }
        /// <summary>
        /// Print genre to CSV file
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="Genres"></param>
        public static void PrintGenreToCSVFile(string fileName, List<string> Genres)
        {
            if (Genres.Count() > 0)
            {

                string[] lines = new string[Genres.Count() + 1];
                lines[0] = String.Format(" {0}", "Genres:");
                for (int i = 0; i < Genres.Count(); i++)
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
