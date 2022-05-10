using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB
{
   
        public abstract class Record
        {
            public string Name { get; set; }
            public string Genre { get; set; }
            public string Studia { get; set; }
            public string Actor1 { get; set; }
            public string Actor2 { get; set; }



            public Record(string Name, string Genre, string Studia, string Actor1, string Actor2)
            {
                this.Name = Name;
                this.Genre = Genre;
                this.Studia = Studia;
                this.Actor1 = Actor1;
                this.Actor2 = Actor2;
            }
            public override string ToString()
            {
                string eilute;
                eilute = string.Format("{0,-8} {1, 12} {2, 17} {3, 15} {4, 15} ",
                    Name, Genre, Studia, Actor1, Actor2);
                return eilute;
            }
            public override bool Equals(object other)
            {
                {
                    return this.Name == ((Record)other).Name;
                }
            }
            public override int GetHashCode()
            {
                return this.Name.GetHashCode();
            }
            public int CompareTo(Record other)
            {
                int result = this.Name.CompareTo(other.Name);
                if (result == 0)
                {
                    return this.Name.CompareTo(other.Name);
                }
                return result;
            }
        }
}
