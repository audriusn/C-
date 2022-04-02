using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeweleryShop
{
     class JewelRegister
    {
        private List<Jewel> AllJewels;
        public JewelRegister()
        {
            AllJewels = new List<Jewel>();
        }
        public JewelRegister(List<Jewel> Jewel)
        {
            AllJewels = new List<Jewel>();
            foreach (Jewel jewel in Jewel)
            {
                this.AllJewels.Add(jewel);
            }
        }
        public string ShopName { get; set; }
        public string Address { get; set; }
        public string PhoneNR { get; set; }
        public void Add(Jewel jewel)
        {
            AllJewels.Add(jewel);
        }
        public bool Contains(Jewel jewel)
        {
            return AllJewels.Contains(jewel);
        }
        public int JewelCount()
        {
            return this.AllJewels.Count;
        }
        public Jewel GetJewel(int index)
        {
            return this.AllJewels[index];
        }
        /// <summary>
        /// Find and retunr max prica value
        /// </summary>
        /// <returns></returns>
        public int FindMaxPrice()
        {
            int maxPrice = int.MinValue;
            foreach (Jewel jewel in this.AllJewels)
            {
                if (jewel.Price > maxPrice)
                    maxPrice = jewel.Price;
            }
            return maxPrice;
        }
    }
}
