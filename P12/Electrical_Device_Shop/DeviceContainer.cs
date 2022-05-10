using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Electrical_Device_Shop
{
    internal class DeviceContainer
    {
        private Device[] devices;
        public int Count { get; private set; }
        public DeviceContainer(int capacity = 50)
        {
            this.devices = new Device[capacity];
        }
        public string ShopName { get; set; }
        public string Address { get; set; }
        public string PhoneNR { get; set; }
        public string type { get; set; }

        public void Add(Device device)
        {
            if (this.Count == this.Capacity) // container is full
            {
                EnsureCapacity(this.Capacity * 2);
            }
            this.devices[this.Count++] = device;
        }
        private int Capacity;
        private void EnsureCapacity(int minimumCapacity)
        {
            if (minimumCapacity > this.Capacity)
            {
                Device[] temp = new Device[minimumCapacity];
                for (int i = 0; i < this.Count; i++)
                {
                    temp[i] = this.devices[i];
                }
                this.Capacity = minimumCapacity;
                this.devices = temp;
            }
        }
        public Device Get(int index)
        {
            return this.devices[index];
        }

        public bool Contains(Device device)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.devices[i].Equals(device))
                {
                    return true;
                }
            }
            return false;
        }

        public void Put(int index, Device device)
        {
            this.devices[index] = device;
        }
        public void Insert(int index, Device device)
        {
            if (this.Count == this.Capacity)
            {
                EnsureCapacity(Capacity * 2);
            }
            for (int i = Count + 1; i > index; i--)
            {
                this.devices[i] = this.devices[i - 1];
            }
            this.devices[index] = device;

            Count++;
        }
        public void RemoveAt(int index)
        {
            for (int i = index; i < Count; i++)
            {
                this.devices[i] = this.devices[i + 1];
            }
            Count--;
        }
        public void Remove(Device device)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this.devices[i].Model == device.Model)
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
                    Device a = this.devices[i];
                    Device b = this.devices[i + 1];
                    if (comparator.Compare(a, b) > 0)
                    {
                        this.devices[i] = b;
                        this.devices[i + 1] = a;
                        flag = true;
                    }
                }
            }
        }
        public void Sort()
        {
            Sort(new DeviceComparator());
        }
        public DeviceContainer(DeviceContainer container) : this()
        {
            for (int i = 0; i < container.Count; i++)
            {
                this.Add(container.Get(i));
            }
        }
        public DeviceContainer Intersect(DeviceContainer other)
        {
            DeviceContainer result = new DeviceContainer();
            for (int i = 0; i < this.Count; i++)
            {
                Device current = this.devices[i];
                if (other.Contains(current))
                {
                    result.Add(current);
                }
            }
            return result;
        }
        public static DeviceContainer AllShops(DeviceContainer cont1, DeviceContainer cont2, DeviceContainer cont3)
        {
            DeviceContainer AllShops = new DeviceContainer();

            for (int i = 0; i < cont1.Count; i++)
            {
                for (int j = 0; j < cont2.Count; j++)
                {
                    for (int k = 0; k < cont3.Count; k++)
                    {
                        if (cont1.Get(i).Brand == cont2.Get(j).Brand && cont2.Get(j).Brand == cont3.Get(k).Brand && cont1.Get(i).Model == cont2.Get(j).Model && cont2.Get(j).Model == cont3.Get(k).Model
                            && cont1.Get(i).Color == cont2.Get(j).Color && cont2.Get(j).Color == cont3.Get(k).Color)
                        {
                            AllShops.Add(cont1.Get(i));
                        }
                    }
                }
            }
            return AllShops;

        }
    }
}
