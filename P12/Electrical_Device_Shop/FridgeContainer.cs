﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electrical_Device_Shop
{
    internal class FridgeContainer
    {
        private Fridge[] fridges;
        public int Count { get; private set; }
        public FridgeContainer(int capacity = 50)
        {
            this.fridges = new Fridge[capacity];
        }

        public void Add(Fridge fridge)
        {
            if (this.Count == this.Capacity) // container is full
            {
                EnsureCapacity(this.Capacity * 2);
            }
            this.fridges[this.Count++] = fridge;
        }
        private int Capacity;
        private void EnsureCapacity(int minimumCapacity)
        {
            if (minimumCapacity > this.Capacity)
            {
                Fridge[] temp = new Fridge[minimumCapacity];
                for (int i = 0; i < this.Count; i++)
                {
                    temp[i] = this.fridges[i];
                }
                this.Capacity = minimumCapacity;
                this.fridges = temp;
            }
        }
        public Fridge Get(int index)
        {
            return this.fridges[index];
        }

        public bool Contains(Fridge fridge)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.fridges[i].Equals(fridge))
                {
                    return true;
                }
            }
            return false;
        }

        public void Put(int index, Fridge fridge)
        {
            this.fridges[index] = fridge;
        }
        public void Insert(int index, Fridge fridge)
        {
            if (this.Count == this.Capacity)
            {
                EnsureCapacity(Capacity * 2);
            }
            for (int i = Count + 1; i > index; i--)
            {
                this.fridges[i] = this.fridges[i - 1];
            }
            this.fridges[index] = fridge;

            Count++;
        }
        public void RemoveAt(int index)
        {
            for (int i = index; i < Count; i++)
            {
                this.fridges[i] = this.fridges[i + 1];
            }
            Count--;
        }
        public void Remove(Fridge fridge)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this.fridges[i].Model == fridge.Model)
                {
                    RemoveAt(i);
                    return;
                }
            }
        }
        public void Sort(DeviceComparator comparator)
        {
            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int i = 0; i < this.Count - 1; i++)
                {
                    Fridge a = this.fridges[i];
                    Fridge b = this.fridges[i + 1];
                    if (comparator.Compare(a, b) > 0)
                    {
                        this.fridges[i] = b;
                        this.fridges[i + 1] = a;
                        flag = true;
                    }
                }
            }
        }
        public void Sort()
        {
            Sort(new DeviceComparator());
        }
        public FridgeContainer(FridgeContainer container) : this()
        {
            for (int i = 0; i < container.Count; i++)
            {
                this.Add(container.Get(i));
            }
        }
        public FridgeContainer Intersect(FridgeContainer other)
        {
            FridgeContainer result = new FridgeContainer();
            for (int i = 0; i < this.Count; i++)
            {
                Fridge current = this.fridges[i];
                if (other.Contains(current))
                {
                    result.Add(current);
                }
            }
            return result;
        }

        public List <string> FridgeColor (FridgeContainer fridge)
        {
            List <string> Color = new List <string>();
            for (int i = 0; i < this.Count; i++)
            {
                string color = fridge.Get(i).Color;
                if(!Color.Contains(color))
                 {
                    Color.Add(color);
                }
            }
            return Color;
        }

        public FridgeContainer LowestPriceAPliusEnergyClass(FridgeContainer fridge)
        {
            FridgeContainer filtered = new FridgeContainer();

            for (int i = 0; i < this.Count; i++)
            {
                double minPrice = this.Get(0).Price;
                if (minPrice > this.Get(i).Price && this.Get(i).EnergyClass == "A+")
                {
                    filtered.Add(this.Get(i));
                }
            }
            return filtered;
        }
        public FridgeContainer NormalSizeFridge (FridgeContainer fridge)
        {
            FridgeContainer filtered = new FridgeContainer();

            for (int i = 0; i < this.Count; i++)
            {
              
                if ( this.Get(i).Width >= 52 && this.Get(i).Width <= 56)
                {
                    filtered.Add(this.Get(i));
                }
            }
            return filtered;
        }
    }
}
