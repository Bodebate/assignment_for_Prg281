using System;
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
        public bool MatierialInList(List<Matierial> matierial, string name)
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
    }
}
