using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turistai
{
    class Narys
    {
        public string name { get; set; }
        public string surname { get; set; }
        public double money { get; set; }

        public Narys(string name, string surname, double money)
        {
            this.name = name;
            this.surname = surname;
            this.money = money;
        }

        public double CalculateSum()
        {
            double suma = this.money / 4;
            return suma;
        }
    }
}