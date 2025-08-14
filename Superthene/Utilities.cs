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
        int MatierialIndex();
        double MatierialSupply();
        double MatierialCostPerTonne();


        int BlendIndex();
        bool BlendInList();


    }
    internal class Utilities
    {
        public bool BlendInList(IList<Blend> Blends, string name)
        {
            bool found = false;
            foreach (Blend blend in Blends)
            {
                if (blend.Name.ToLower().TrimEnd() == name.ToLower().TrimEnd())
                {
                    found = true;
                }
            }
            return found;
        }
        public int BlendIndex(IList<Blend> blends, string name)
        {
            int count = 0;
            int location = -1;
            foreach (Blend blend in blends)
            {
                if (blend.Name.ToLower() == name.ToLower())
                {
                    location = count;
                }
                count++;
            }
            return location;
        }
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
            if (totalSupply > 0)
            {
                return (double)totalCost / totalSupply;
            }
            else 
            {
                return 0; 
            }
            
        }


    }
}
