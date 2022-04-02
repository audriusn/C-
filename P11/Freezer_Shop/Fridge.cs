using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freezer_Shop
{
    class Fridge
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Volume { get; set; }
        public string EnergyClass { get; set; }
        public string Type { get; set; }
        public string Color { get; set; }
        public Mark Freezer { get; set; }
        public int Price { get; set; }

        public Fridge(string Brand, string Model, int Volume, string EnergyClass, string Type, string Color, Mark Freezer, int Price)
        {
            this.Brand = Brand;
            this.Model = Model;
            this.Volume = Volume;
            this.EnergyClass = EnergyClass;
            this.Type = Type;
            this.Color = Color;
            this.Freezer = Freezer;
            this.Price = Price;

        }
        public override bool Equals(object other)
        {
            return this.Model == ((Fridge)other).Model;
        }
        public override int GetHashCode()
        {
            return this.Model.GetHashCode();
        }
        public static bool operator <=(Fridge first, Fridge second)
        {
            int p = String.Compare(first.Type, second.Type,StringComparison.CurrentCulture);
            int v = String.Compare(first.Brand, second.Brand, StringComparison.CurrentCulture);
            return (p < 0 || (p == 0 && v < 0));
        }

        public static bool operator >=(Fridge first, Fridge second)
        {
            int p = String.Compare(first.Type, second.Type, StringComparison.CurrentCulture);
            int v = String.Compare(first.Brand, second.Brand, StringComparison.CurrentCulture);
            return (p > 0 || (p == 0 && v > 0));
        }
        
    }
}

