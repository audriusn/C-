using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace National_Team
{
    internal class TaskClass
    {
        public static int FindTalleatPLayers(CandidatesContainer list1, CandidatesContainer list2)
        {
            int maxHeight = 0;
            if (list1.TallestPLayer(list1) <= list2.TallestPLayer(list2))

                maxHeight = list2.TallestPLayer(list2);

            else
                maxHeight = list1.TallestPLayer(list1);
            return maxHeight;
        }
        public static CandidatesContainer MaxHeight(CandidatesContainer Candidates, CandidatesContainer list1, int maxHeight)
        {
            CandidatesContainer candidates = new CandidatesContainer();

            for (int i = 0; i < list1.Count; i++)
            {
                if (maxHeight == list1.Get(i).Height)
                    Candidates.Add(list1.Get(i));

            }
            return Candidates;
        }
        public static CandidatesContainer BothYearForward(CandidatesContainer list1, CandidatesContainer list2)
        {
            CandidatesContainer BothYearForward = new CandidatesContainer();

            for (int i = 0; i < list1.Count; i++)
            {

                for (int j = 0; j < list2.Count; j++)
                {
                    if (list1.Get(i).Name == list2.Get(j).Name && list1.Get(i).Surname == list2.Get(j).Surname && list1.Get(i).Position == "Puolėjas")
                    {
                        BothYearForward.Add(list1.Get(i));
                    }
                }
            }
            return BothYearForward;
        }
        public static CandidatesContainer NationalTeam(CandidatesContainer list1)
        {
            CandidatesContainer NationalTeam = new CandidatesContainer();

            for (int i = 0; i < list1.Count; i++)
            {
                if (list1.Get(i).Candidate == Mark.TRUE)
                {
                    NationalTeam.Add(list1.Get(i));
                }
            }
            return NationalTeam;
        }
        public static CandidatesContainer BothYearsCandidates(CandidatesContainer list1, CandidatesContainer list2)
        {
            CandidatesContainer BothYearForward = new CandidatesContainer();

            for (int i = 0; i < list1.Count; i++)
            {
                for (int j = 0; j < list2.Count; j++)
                {
                    if (!list1.Contains(list2.Get(j)))
                    {

                    }
                }
                BothYearForward.Add(list1.Get(i));
            }
            return BothYearForward;
        }
      
    }
}
