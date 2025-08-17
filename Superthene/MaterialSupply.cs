using System;
using System.Collections.Generic;
using System.IdentityModel.Protocols.WSTrust;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Superthene
{
    // Represents a supply order for a material, tracking price, quantity, and order date.
    internal class MaterialSupply
    {
        private string _name;
        private DateTime _dateOfOrder;
        private double _price;
        private double _quantityRemaining;
        private double _totalQuantityOrdered;
        private int _SupplyID;

        // Constructor: Initializes a new material supply with name, price, quantity, and assigns a unique supply ID.
        public MaterialSupply(string Name, double Price, double Quantity,  IList<MaterialSupply> supplyList)
        {
            _name = Name;
            _price = Price;
            _quantityRemaining = Quantity;
            _totalQuantityOrdered = Quantity;
            _dateOfOrder = DateTime.Now;
            _SupplyID = supplyList.Count;   
        }
        // Deducts used quantity from remaining stock if available; returns true if successful.
        public virtual bool UseMaterial(double UsedQuantity)
        {
            if (UsedQuantity < 0 || _quantityRemaining < UsedQuantity)
            {
                return false;
            }
            else
            {
                _quantityRemaining -= UsedQuantity;
                return true;
            }
        }
        // Gets the price per unit of the material supply.
        public double Price {get { return _price / _totalQuantityOrdered; } }
        // Gets the remaining stock of the material supply.
        public double Stock { get { return _quantityRemaining; }  }
        // Gets the date the supply was ordered.
        public DateTime Date {  get { return _dateOfOrder; } }
    }
}
