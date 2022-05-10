using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basketball_Team
{
     class Staff : Member
    {
        public string jobTitle { get; set; }
        
        public Staff(string Name, string Surname, DateTime BirthDate, string jobTitle) : base(Name, Surname, BirthDate)
        {
            this.jobTitle = jobTitle;
           
        }
    }
}
