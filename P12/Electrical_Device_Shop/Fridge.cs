using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electrical_Device_Shop
{
     class Fridge : Device
    {
        
        public int Volume { get; set; }
        public string Type { get; set; }       
        public Mark Freezer { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int Deep { get; set; }

        public Fridge(string Brand, string Model, string EnergyClass, string Color, int Price, int Volume,  string Type,  Mark Freezer, int Height, int Width, int Deep) : base (Brand, Model, EnergyClass, Color, Price)
        {
            this.Volume = Volume;
            this.Type = Type;
            this.Freezer = Freezer;
            this.Height = Height;
            this.Width = Width;
            this.Deep = Deep;
        }
        public override bool Equals(object other)
        {
            {
                return this.Model == ((Fridge)other).Model;
               
            }
        }
        public override int GetHashCode()
        {
            return this.Model.GetHashCode();
        }
        public override string ToString()
        {
            return  string.Format("{0,-14} | {1,-8} | {2,-11} | {3,7} | {4,11:c} | {5,10} | {6,-13} | {7,7} | {8,6} | {9,5} | {10,5} |{11,9} | {12,6}  |",
                Brand, Model, EnergyClass, Color, Price, Volume, Type, Freezer, Height, Width, Deep,"","");    
        }
    }
}
