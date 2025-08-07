using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Superthene
{
    internal class Matierial
    {
        private string _matierialName;
        private List<int> _supplyIDs = new List<int>;
        private int _matierialID;
        
        public Matierial(string Name, List<Matierial> list) 
        {
         _matierialName = Name;
         _matierialID = list.Count;
        }

    }
}
