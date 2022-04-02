using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Namas
{
    class FlatRegister
    {
        private List<Flats> AllFlats;

        public FlatRegister()
        {
            AllFlats = new List<Flats>();
        }

        public FlatRegister(List<Flats> Flats)
        {
            AllFlats = new List<Flats>();
            foreach (Flats flat in Flats)
            {
                this.AllFlats.Add(flat);
            }
        }
        public void Add(Flats flat)
        {
            AllFlats.Add(flat);
        }
        public bool Contains(Flats flat)
        {
            return AllFlats.Contains(flat);
        }
        public int FlatsCount()
        {
            return this.AllFlats.Count;
        }
        public Flats GetFlat(int index)      
        {
            return this.AllFlats[index];
        }
         public static FlatRegister FilteredFlats(int minFloor, int maxFloor, int rooms, int price, FlatRegister all)
        {
            FlatRegister filtered = new FlatRegister();

            for(int i = 0; i < all.FlatsCount(); i++)
            {
                Flats flat = all.GetFlat(i);
                if(flat.Floor >= minFloor && flat.Floor <= maxFloor && flat.Rooms == rooms && flat.Price <= price)
                {
                    filtered.Add(flat);
                }
            }
            return filtered;
        }

    }

}
