using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewelery_Shop
{
    internal class Jewel
    {
        public string Manufacturer { get; set; }
        public string Name { get; set; }
        public string Metal { get; set; }
        public double Weight { get; set; }
        public double Size { get; set; }
        public int Praba { get; set; }
        public int Price { get; set; }

        public Jewel(string Manufacturer, string Name, string Metal, double Weight, double Size, int Praba, int Price)
        {
            this.Manufacturer = Manufacturer;
            this.Name = Name;
            this.Metal = Metal;
            this.Weight = Weight;
            this.Size = Size;
            this.Praba = Praba;
            this.Price = Price;

        }
        public override bool Equals(object other)
        {
            return this.Name == ((Jewel)other).Name;
        }
        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }
       public int CompareManufacture(Jewel other)
        {
            return this.Manufacturer.CompareTo(other.Manufacturer);
        }
        public int ComparePrice(Jewel other)
        {
            return this.Price.CompareTo(other.Price);
        }
    }
}

