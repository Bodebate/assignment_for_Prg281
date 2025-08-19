using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Superthene
{
    // Represents a material used in blends and products, tracking its supply and ID.
    internal class Material: Utilities
    {
        private string _materialName;
        private IList<int> _supplyIDs = new List<int>();
        private int _materialID;
        public string MaterialName { get { return _materialName; } }
        public int MaterialID { get { return _materialID; } }
        // Constructor: Initializes a new material with a name and assigns a unique ID.
        public Material(string Name, IList<Material> list) 
        {
         _materialName = Name;
         _materialID = list.Count;
        }
        // Adds a supply ID to the material's list of supplies.
        public void AddSupply(int SupplyId)
        {
            _supplyIDs.Add(SupplyId);
        }
        // Returns the list of supply IDs associated with this material.
        public IList<int> GetSupplyIDs() { return _supplyIDs; }
        // Alerts the user about the current stock level of this material.
        public void AlertUser(IList<MaterialSupply> MaterialSupplyList)
        {
            Console.WriteLine($"{_materialName.ToUpper()}\t Current stock level: {MaterialSupply(_supplyIDs, MaterialSupplyList)} tonnes");
        }
        // to string function
        public void ToString(IList<MaterialSupply> MaterialSupplyList)
        {
            Console.WriteLine($"{_materialID} : {_materialName} ({MaterialSupply(_supplyIDs, MaterialSupplyList)} tonnes)");
        }
    }
}
