using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turistai
{
    static class TaskClass
    {
        public static double MoneyForCosts(List<Narys> Nariai)
        {
            double sum = 0;
            foreach (Narys narys in Nariai)
            {
                sum = sum + narys.CalculateSum();
            }
            return sum;
        }
        public static  Narys FindGeerousTurist(List<Narys> Nariai)
        {
            Narys generous = Nariai[0]; //mean least value
            for (int i = 1; i < Nariai.Count; i++)
            {
                if ((Nariai[i].CalculateSum() > generous.CalculateSum()))
                {
                    generous = Nariai[i];
                    
                }
            }
            return generous;
        }

        public static List<Narys> FindMaxDonators(List<Narys> Nariai)
        {
            List <Narys> narys1 = new List<Narys>();
            double maxDonated = FindGeerousTurist(Nariai).CalculateSum();
            foreach (Narys narys in Nariai)
            {
                if (narys.CalculateSum().Equals(maxDonated) && maxDonated == FindGeerousTurist(Nariai).CalculateSum())
                    {
                    narys1.Add(narys);
                }
            }
            return narys1;
        }
    }
 
}
