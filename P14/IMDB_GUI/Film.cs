using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB_GUI
{
     class Film
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public string Type { get; set; }
        public string Company { get; set; }
        public string Director { get; set; }
        public string Actor1 { get; set; }
        public string Actor2 { get; set; }
        public int Profit { get; set; }


        public Film(string Name, int Year, string Type, string Company, string Director, string Actor1, string Actor2, int Profit)
        {
            this.Name = Name;
            this.Year = Year;
            this.Type = Type;
            this.Company = Company;
            this.Director = Director;
            this.Actor1 = Actor1;
            this.Actor2 = Actor2;
            this.Profit = Profit;

        }
        public override string ToString()
        {
            string eilute;
            eilute = string.Format("{0,-20} {1,2} {2} {3} {4} {5} {6} {7}", Name, Year, Type, Company, Director, Actor1, Actor2, Profit);
            return eilute;
        }
    }
}
