using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace National_Team
{
    class CandidatesContainer
    {
        private Candidates[] candidates;
        public int Count { get; private set; }
        public CandidatesContainer(int capacity = 20)
        {
            this.candidates = new Candidates[capacity];
        }
        public int bYear { get; set; }
        public DateTime CampStart { get; set; }
        public DateTime CampEnd { get; set; }
        public void Add(Candidates candidate)
        {
            if (this.Count == this.Capacity) // container is full
            {
                EnsureCapacity(this.Capacity * 2);
            }
            this.candidates[this.Count++] = candidate;
        }
        private int Capacity;
        private void EnsureCapacity(int minimumCapacity)
        {
            if (minimumCapacity > this.Capacity)
            {
                Candidates[] temp = new Candidates[minimumCapacity];
                for (int i = 0; i < this.Count; i++)
                {
                    temp[i] = this.candidates[i];
                }
                this.Capacity = minimumCapacity;
                this.candidates = temp;
            }
        }
        public Candidates Get(int index)
        {
            return this.candidates[index];
        }
        public bool Contains(Candidates candidate)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.candidates[i].Equals(candidate))
                {
                    return true;
                }
            }
            return false;
        }
        public void Put(int index, Candidates candidate)
        {
            this.candidates[index] = candidate;
        }
        public void Insert(int index, Candidates candidate)
        {
            if (this.Count == this.Capacity)
            {
                EnsureCapacity(Capacity * 2);
            }
            for (int i = Count + 1; i > index; i--)
            {
                this.candidates[i] = this.candidates[i - 1];
            }
            this.candidates[index] = candidate;
            Count++;
        }
        public void RemoveAt(int index)
        {
            for (int i = index; i < Count; i++)
            {
                this.candidates[i] = this.candidates[i + 1];
            }
            Count--;
        }
        public void Remove(Candidates candidate)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this.candidates[i].Name == candidate.Name)
                {
                    RemoveAt(i);
                    return;
                }
            }
        }
        public void Sort()
        {
            for (int i = 0; i < this.Count - 1; i++)
            {
                Candidates film = this.candidates[i];
                int im = i;
                for (int j = i + 1; j < this.Count; j++)
                    if (this.candidates[j] <= film)
                    {
                        film = this.candidates[j];
                        im = j;
                    }
                this.candidates[im] = this.candidates[i];
                this.candidates[i] = film;
            }
        }
        public CandidatesContainer(CandidatesContainer container) : this()
        {
            for (int i = 0; i < container.Count; i++)
            {
                this.Add(container.Get(i));
            }
        }
        public CandidatesContainer Intersect(CandidatesContainer other)
        {
            CandidatesContainer result = new CandidatesContainer();
            for (int i = 0; i < this.Count; i++)
            {
                Candidates current = this.candidates[i];
                if (other.Contains(current))
                {
                    result.Add(current);
                }
            }
            return result;
        }
        public int TallestPLayer(CandidatesContainer other)
        {
            int maxHeight = int.MinValue;
            for(int i = 0; i < this.Count; i++)
            {
                if (this.candidates[i].Height > maxHeight)
                    maxHeight = this.candidates[i].Height;
            }
            return maxHeight;
        }
        public List<string> TeamNames (CandidatesContainer players)
        {
            List<string> TeamNames = new List<string>();
            for (int i = 0; i < players.Count; i++)
            {
                if (!TeamNames.Contains(players.Get(i).TeamName))

                    TeamNames.Add(players.Get(i).TeamName);

            }
            return TeamNames;
        }
    }
}