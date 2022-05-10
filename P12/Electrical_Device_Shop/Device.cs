using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electrical_Device_Shop
{
    public abstract class Device
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string EnergyClass { get; set; }
        public string Color { get; set; }
        public int Price { get; set; }



        public Device(string Brand, string Model, string EnergyClass, string Color, int Price)
        {
            this.Brand = Brand;
            this.Model = Model;
            this.EnergyClass = EnergyClass;
            this.Color = Color;
            this.Price = Price;
        }
        public override string ToString()
        {
            string eilute;
            eilute = string.Format("{0,-8} {1, 12} {2, 17} {3, 15} {4, 15} ",
                Brand, Model, EnergyClass, Color, Price);
            return eilute;
        }
        public override bool Equals(object other)
        {
            {
                return this.Model == ((Device)other).Model;
            }
        }
        public override int GetHashCode()
        {
            return this.Model.GetHashCode();
        }
        public int CompareTo(Device other)
        {
            int result = this.Brand.CompareTo(other.Brand);
            if (result == 0)
            {
                return this.Model.CompareTo(other.Model);
            }
            return result;
        }
    }
}
