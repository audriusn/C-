using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuvelyrikosParduotuvė
{
    class Ziedas
    {
        public string Manufacturer { get; set; }
        public string Name { get; set; }
        public string Metal { get; set; }
        public double Weight { get; set; }
        public double Size { get; set; }
        public int Praba { get; set; }
        public int Price { get; set; }
     
        public Ziedas(string Manufacturer, string Name, string Metal, double Weight, double Size, int Praba, int Price)
        {
            this.Manufacturer = Manufacturer;
            this.Name = Name;
            this.Metal = Metal;
            this.Weight = Weight;
            this.Size = Size;
            this.Praba = Praba;
            this.Price = Price;

        }
    }
}

