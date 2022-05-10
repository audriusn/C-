using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electrical_Device_Shop
{
     class Oven : Device 
    {
        public int Power { get; set; }
        public int DifferentPrograms { get; set; }
       
        public Oven(string Brand, string Model, string EnergyClass, string Color, int Price, int Power, int DifferentPrograms) : base(Brand, Model, EnergyClass, Color, Price)
        {
            this.Power = Power;
            this.DifferentPrograms = DifferentPrograms;
           
        }
        public override bool Equals(object other)
        {
            {
                return this.Model == ((Oven)other).Model;
            }
        }
        public override int GetHashCode()
        {
            return this.Model.GetHashCode();
        }
        public override string ToString()
        {
            return string.Format("{0,-14} | {1,-8} | {2,-11} | {3,7} | {4,11:c} | {5,10} | {6,-13} | {7,7} | {8,7}| {9,6}|{10,6} |{11,9} | {12,6}  |",
                Brand, Model, EnergyClass, Color, Price, "", "","", "","","", DifferentPrograms, Power);
        }
    }
}
