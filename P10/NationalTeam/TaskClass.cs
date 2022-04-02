using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationalTeam
{
    internal class TaskClass
    {
        public static CandidatesRegister BothYearForward(CandidatesRegister list1, CandidatesRegister list2)
        {
            CandidatesRegister BothYearForward = new CandidatesRegister();

            for (int i = 0; i < list1.CandidatesCount(); i++)
            {

                for (int j = 0; j < list2.CandidatesCount(); j++)
                {
                    if (list1.GetPlayers(i).Name == list2.GetPlayers(j).Name && list1.GetPlayers(i).Surname == list2.GetPlayers(j).Surname && list1.GetPlayers(i).Position == "Puolėjas")
                    {
                        BothYearForward.Add(list1.GetPlayers(i));
                    }
                }
            }
            return BothYearForward;
        }
        public static int FindTalleatPLayers(CandidatesRegister list1, CandidatesRegister list2)
        {
            int maxHeight = 0;
            if (list1.TallestPLayer() <= list2.TallestPLayer())

                maxHeight = list2.TallestPLayer();

            else
                maxHeight = list1.TallestPLayer();
            return maxHeight;
        }
        public static CandidatesRegister MaxHeight(CandidatesRegister Candidates, CandidatesRegister list1, int maxHeight)
        {
            CandidatesRegister candidates = new CandidatesRegister();

            for (int i = 0; i < list1.CandidatesCount(); i++)
            {
                if (maxHeight == list1.GetPlayers(i).Height)
                    Candidates.Add(list1.GetPlayers(i));

            }
            return Candidates;
        }
    }
}
