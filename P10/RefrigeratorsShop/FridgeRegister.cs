using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefrigeratorsShop
{
     class FridgeRegister
    {
        private List<Fridge> AllFrigde;
        public FridgeRegister()
        {
            AllFrigde = new List<Fridge>();
        }
        public FridgeRegister(List<Fridge> Fridge)
        {
            AllFrigde = new List<Fridge>();
            foreach (Fridge frigde in Fridge)
            {
                this.AllFrigde.Add(frigde);
            }
        }
        public string ShopName { get; set; }
        public string Address { get; set; }
        public string PhoneNR { get; set; }
        public void Add(Fridge fridge)
        {
            AllFrigde.Add(fridge);
        }
        public bool Contains(Fridge fridge)
        {
            return AllFrigde.Contains(fridge);
        }
        public int FridgeCount()
        {
            return this.AllFrigde.Count;
        }
        public Fridge GetFridge(int index)
        {
            return this.AllFrigde[index];
        }
        /// <summary>
        /// Find and return lowest price value
        /// </summary>
        /// <returns></returns>
        public int FindLowestPrice()
        {
            int lowestPrice = int.MaxValue;
            foreach (Fridge fridge in this.AllFrigde)
            {
                if (fridge.Price < lowestPrice)
                    lowestPrice = fridge.Price;
            }
            return lowestPrice;
        }
        /// <summary>
        ///Making new filtered registers: Pastatomomas = YES, Freezer = YES.
        /// </summary>
        /// <param name="fridge"></param>
        /// <returns></returns>
        public FridgeRegister FridgeWithFreezerAndStandable(FridgeRegister fridge)
        {
            FridgeRegister Refrig = new FridgeRegister();
            foreach (Fridge sald in this.AllFrigde)
            {
                if ( sald.Type == "Pastatomas" && sald.Freezer == Mark.TAIP )
                    Refrig.Add(sald);
            }
            return Refrig;
        }
        /// <summary>
        /// Find and return max price value
        /// </summary>
        /// <returns></returns>
        public int FindMaxPrice()
        {
            int maxPrice = int.MinValue;
            foreach (Fridge fridge in this.AllFrigde)
            {
                if (fridge.Price > maxPrice)
                    maxPrice = fridge.Price;
            }
            return maxPrice;
        }
    }
    
}
