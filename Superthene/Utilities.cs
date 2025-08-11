using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Superthene
{
    interface utilities
    {
       bool MatierialInList();
    }
    internal class Utilities
    {
        public bool MatierialInList(IList<Matierial> matierial, string name)
        {
            bool found = false;
            foreach (Matierial mat in matierial)
            {
                if (mat.MatierialName.ToLower() == name.ToLower())
                {
                    found = true;
                }
            }
            return found;
        }
        public int MatierialIndex(IList<Matierial> list, string matierial)
        { int count = 0;
            int location = -1;
            foreach (Matierial mat in list)
            {
                if (mat.MatierialName.ToLower() == matierial.ToLower())
                {
                    location = count;
                }
                count++;
            }
            return location;
        }
        public double MatierialSupply(IList<int> supplyIDs, IList<MatierialSupply> SuppliesList)
        {
            double totalSupply = 0;
            foreach (int i in supplyIDs)
            {
                totalSupply += SuppliesList[i - 1].Stock;
            }
            return totalSupply;
        }

        public double MatierialCostPerTonne(IList<int> supplyIDs, IList<MatierialSupply> SuppliesList)
        {
            double totalSupply = 0;
            double totalCost = 0;
            foreach (int i in supplyIDs)
            {
                totalSupply += SuppliesList[i - 1].Stock;
                totalCost += SuppliesList[i - 1].Stock * SuppliesList[i - 1].Price;
            }
            return (double)totalCost/totalCost;
        }


    }
}
