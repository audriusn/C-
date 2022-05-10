using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electrical_Device_Shop
{
     class Kettle : Device
    {
        public int Power1 { get; set; }
        public double Volum { get; set; }

        public Kettle(string Brand, string Model, string EnergyClass, string Color, int Price, int Power1, double Volum) : base(Brand, Model, EnergyClass, Color, Price)
        {
            this.Power1 = Power1;
            this.Volum = Volum;

        }
        public override bool Equals(object other)
        {
            {
                return this.Model == ((Kettle)other).Model;
            }
        }
        public override int GetHashCode()
        {
            return this.Model.GetHashCode();
        }
        public override string ToString()
        {
            return string.Format("{0,-14} | {1,-8} | {2,-11} | {3,7} | {4,11:c} | {5,10} | {6,-13} | {7,7} | {8,6} | {9,5} | {10,5} |{11,9} | {12,6}  |",
                Brand, Model, EnergyClass, Color, Price, Volum, "","","","","","", Power1);
        }
    }
}
