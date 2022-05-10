using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dogs_And_Cats
{
    public class GuineaPig : Animal
    {
        public GuineaPig(int id, string name, string breed, DateTime birtDate, Gender gender) : base(id, name, breed, birtDate, gender)
        {

        }
        public override bool RequiresVaccination
        {
            get
            {       
                    return false;
            }
        }
    }
}
