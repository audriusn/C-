using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basketball_Team
{
    internal class PlayerContainer
    {
        private Player[] players;
        public int Count { get; private set; }
        public PlayerContainer(int capacity = 16)
        {
            this.players = new Player[capacity];
        }
        public int bYear { get; set; }
        public DateTime CampStart { get; set; }
        public DateTime CampEnd { get; set; }

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
        public void Sort(MembersComparator comparator)
        {
            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int i = 0; i < this.Count - 1; i++)
                {
                    Player a = this.players[i];
                    Player b = this.players[i + 1];
                    if (comparator.Compare(a, b) > 0)
                    {
                        this.players[i] = b;
                        this.players[i + 1] = a;
                        flag = true;
                    }
                }
            }
        }
        public void Sort()
        {
            Sort(new MembersComparator());
        }
        public PlayerContainer(PlayerContainer container) : this()
        {
            for (int i = 0; i < container.Count; i++)
            {
                this.Add(container.Get(i));
            }
        }
        public PlayerContainer Intersect(PlayerContainer other)
        {
            PlayerContainer result = new PlayerContainer();
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
        public static PlayerContainer AllYearForward(PlayerContainer cont1, MemberContainer cont2, MemberContainer cont3)
        {
            PlayerContainer AllYearForward = new PlayerContainer();

            for (int i = 0; i < cont1.Count; i++)
            {
                for (int j = 0; j < cont2.Count; j++)
                {
                    for (int k = 0; k < cont3.Count; k++)
                    {
                        if (cont1.Get(i).Name == cont2.Get(j).Name && cont2.Get(j).Name == cont3.Get(k).Name && cont1.Get(i).Surname == cont2.Get(j).Surname && cont2.Get(j).Surname == cont3.Get(k).Surname
                            && cont1.Get(i).BirthDate == cont2.Get(j).BirthDate && cont2.Get(j).BirthDate == cont3.Get(k).BirthDate && cont1.Get(i).Position== "Puolėjas")
                        {
                            AllYearForward.Add(cont1.Get(i));
                        }
                    }
                }
            }
            return AllYearForward;
        }
        public PlayerContainer MarkAsInvited()
        {
            PlayerContainer invited = new PlayerContainer();
            for (int i = 0; i < this.Count; i++)
            {
                if (!invited.Contains(this.Get(i)) && this.Get(i).Candidate == Mark.TRUE)
                {
                    invited.Add(this.Get(i));
                }
            }
            return invited;
        }
    }
}
