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
        private IList<int> _supplyIDs = new List<int>();
        private int _matierialID;
        public string MatierialName { get { return _matierialName; } }
        public Matierial(string Name, IList<Matierial> list) 
        {
         _matierialName = Name;
         _matierialID = list.Count;
        }
        public void AddSupply(int SupplyId)
        {
            _supplyIDs.Add(SupplyId);
        }
        public IList<int> GetSupplyIDs() { return _supplyIDs; }
    }
}
