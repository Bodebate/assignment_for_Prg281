using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Superthene
{
    // Provides utility methods for searching and calculating information about blends and materials.
    interface utilities
    {
        bool MaterialInList();
        int MaterialIndex();
        double MaterialSupply();
        double MaterialCostPerTonne();
        int BlendIndex();
        bool BlendInList();


    }
    internal class Utilities
    {
        // Checks if a blend with the given name exists in the list.
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
        // Returns the index of a blend with the given name in the list.
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
        // Checks if a material with the given name exists in the list.
        public bool MaterialInList(IList<Material> material, string name)
        {
            bool found = false;
            foreach (Material mat in material)
            {
                if (mat.MaterialName.ToLower() == name.ToLower())
                {
                    found = true;
                }
            }
            return found;
        }
        // Returns the index of a material with the given name in the list.
        public int MaterialIndex(IList<Material> list, string material)
        { int count = 0;
            int location = -1;
            foreach (Material mat in list)
            {
                if (mat.MaterialName.ToLower() == material.ToLower())
                {
                    location = count;
                }
                count++;
            }
            return location;
        }
        // Calculates the total stock available for a list of supply IDs.
        public double MaterialSupply(IList<int> supplyIDs, IList<MaterialSupply> SuppliesList)
        {
            double totalSupply = 0;
            foreach (int i in supplyIDs)
            {
                totalSupply += SuppliesList[i - 1].Stock;
            }
            return totalSupply;
        }

        // Calculates the average cost per tonne for a list of supply IDs.
        public double MaterialCostPerTonne(IList<int> supplyIDs, IList<MaterialSupply> SuppliesList)
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
