using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB
{
     class Film
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public string Company { get; set; }
        public string Director { get; set; }
        public string Actor1 { get; set; }
        public string Actor2 { get; set; }
        public int Profit { get; set; }


        public Film(string Name, int Year, string Genre, string Company, string Director, string Actor1, string Actor2, int Profit)
        {
            this.Name = Name;
            this.Year = Year;
            this.Genre = Genre;
            this.Company = Company;
            this.Director = Director;
            this.Actor1 = Actor1;
            this.Actor2 = Actor2;
            this.Profit = Profit;

        }
        public override bool Equals(object other)
        {
            return this.Name == ((Film)other).Name;
        }
        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }
        public static bool operator <=(Film first, Film second)
        {
            return first.Year < second.Year || first.Year == second.Year && first.Name == second.Name;
        }

        public static bool operator >=(Film first, Film second)
        {
            return first.Year > second.Year || first.Year == second.Year && first.Name == second.Name;
        }
    }
}
