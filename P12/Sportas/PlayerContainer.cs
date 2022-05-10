using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Globalization;

namespace Sportas
{
    class PlayerConatiner
    {
        private Player[] players;
        public int Count { get; private set; }
        public PlayerConatiner(int capacity = 16)
        {
            this.players = new Player[capacity];
        }

        public void Add(Player player)
        {
            if (this.Count == this.Capacity) // container is full
            {
                EnsureCapacity(this.Capacity * 2);
            }
            this.players[this.Count++] = player;
        }
        private int Capacity;
        private void EnsureCapacity(int minimumCapacity)
        {
            if (minimumCapacity > this.Capacity)
            {
                Player[] temp = new Player[minimumCapacity];
                for (int i = 0; i < this.Count; i++)
                {
                    temp[i] = this.players[i];
                }
                this.Capacity = minimumCapacity;
                this.players = temp;
            }
        }
        public Player Get(int index)
        {
            return this.players[index];
        }
        public bool Contains(Player player)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.players[i].Equals(player))
                {
                    return true;
                }
            }
            return false;
        }

        public void Put(int index, Player player)
        {
            this.players[index] = player;
        }
        public void Insert(int index, Player player)
        {
            if (this.Count == this.Capacity)
            {
                EnsureCapacity(Capacity * 2);
            }
            for (int i = Count + 1; i > index; i--)
            {
                this.players[i] = this.players[i - 1];
            }
            this.players[index] = player;
            Count++;
        }
        public void RemoveAt(int index)
        {
            for (int i = index; i < Count; i++)
            {
                this.players[i] = this.players[i + 1];
            }
            Count--;
        }
        public void Remove(Player player)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this.players[i].Name == player.Name)
                {
                    RemoveAt(i);
                    return;
                }
            }
        }
        //public void Sort(AnimalsComparator comparator)
        //{
        //    bool flag = true;
        //    while (flag)
        //    {
        //        flag = false;
        //        for (int i = 0; i < this.Count - 1; i++)
        //        {
        //            Animal a = this.animals[i];
        //            Animal b = this.animals[i + 1];
        //            if (comparator.Compare(a, b) > 0)
        //            {
        //                this.animals[i] = b;
        //                this.animals[i + 1] = a;
        //                flag = true;
        //            }
        //        }
        //    }
        //}
        //public void Sort()
        //{
        //    Sort(new AnimalsComparator());
        //}
        public PlayerConatiner(PlayerConatiner container) : this()
        {
            for (int i = 0; i < container.Count; i++)
            {
                this.Add(container.Get(i));
            }
        }
        public PlayerConatiner Intersect(PlayerConatiner other)
        {
            PlayerConatiner result = new PlayerConatiner();
            for (int i = 0; i < this.Count; i++)
            {
                Player current = this.players[i];
                if (other.Contains(current))
                {
                    result.Add(current);
                }
            }
            return result;
        }
        public double GetTotalPointScored (PlayerConatiner players, string teamName)
        {
            int totalPointScored = 0;
            int count = 0;
            double avg = 0;
            for (int i = 0; i < players.Count; i++)
            {
                if (this.players[i].TeamName == teamName)
                { 
                    totalPointScored += players.Get(i).Score;
                    count++;
                    avg = totalPointScored / count;
                }
            }
            return avg;
        }
    
       
    }
}