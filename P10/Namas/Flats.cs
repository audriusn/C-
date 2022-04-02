using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Namas
{
    class Flats
    {
        public double Number { get; set; }
        public double Area { get; set; }
        public int Rooms { get; set; }
        public int Price { get; set; }
        public int MobPhone { get; set; }

        public Flats(double Number, double Area, int Rooms, int Price, int MobPhone)
        {
            this.Number = Number;
            this.Area = Area;
            this.Rooms = Rooms;
            this.Price = Price;
            this.MobPhone = MobPhone;
        }

        public double Floor
        {
            get
            {
                double floor = Math.Ceiling(Number / 3);       
                return  floor;
            }

        }
    }
}
