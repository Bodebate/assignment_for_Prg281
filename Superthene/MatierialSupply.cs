using System;
using System.Collections.Generic;
using System.IdentityModel.Protocols.WSTrust;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Superthene
{
    internal class MatierialSupply
    { private string _name;
        private DateTime _dateOfOrder;
        private double _price;
        private double _quantityRemaining;
        private double _totalQuantityOrdered;
        private int _SupplyID;

        public MatierialSupply(string Name, double Price, double Quantity,  List<MatierialSupply> supplyList)
        {
            _name = Name;
            _price = Price;
            _quantityRemaining = Quantity;
            _totalQuantityOrdered = Quantity;
            _dateOfOrder = DateTime.Now;
            _SupplyID = supplyList.Count;   
        }
        public virtual bool UseMatierial(double UsedQuantity)
        {
            if (UsedQuantity < 0 || _quantityRemaining > 0)
                return false;
            else
            {
                _quantityRemaining -= UsedQuantity;
                return true;
            }
        }
        public double Price {get { return _price / _totalQuantityOrdered; } }
        public double Stock { get { return _quantityRemaining; }  }
        public DateTime Date {  get { return _dateOfOrder; } }

    }
}
