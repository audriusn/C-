using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dogs_And_Cats
{
     public class Vaccination
    {
        public int AnimalID { get; set; }
        public DateTime Date { get; set; }
        public Vaccination(int AnimalID, DateTime date)
        {
            this.AnimalID = AnimalID;
            this.Date = date;
        }
        public static bool operator <(Vaccination vaccination, DateTime date)
        {
            return vaccination.Date.CompareTo(date) < 0;
        }
        public static bool operator >(Vaccination vaccination, DateTime date)
        {
            return vaccination.Date.CompareTo(date) > 0;
        }
    }
}

