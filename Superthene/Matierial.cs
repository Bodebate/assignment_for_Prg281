using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Superthene
{
    internal class Matierial: Utilities
    {
        private string _materialName;
        private IList<int> _supplyIDs = new List<int>();
        private int _materialID;
        public string MaterialName { get { return _materialName; } }
        public int MaterialID { get { return _materialID; } }
        public Matierial(string Name, IList<Matierial> list) 
        {
         _materialName = Name;
         _materialID = list.Count;
        }
        public void AddSupply(int SupplyId)
        {
            _supplyIDs.Add(SupplyId);
        }
        public IList<int> GetSupplyIDs() { return _supplyIDs; }

        public void AlertUser(IList<MatierialSupply> MaterialSupplyList)
        {
            Console.WriteLine($"{_materialName.ToUpper()}\t Current stock level: {MaterialSupply(_supplyIDs, MaterialSupplyList)} tonnes");
        }
    }
}
