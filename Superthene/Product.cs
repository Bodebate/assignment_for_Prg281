using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Superthene
{
    internal class Product 
    {
        private int _blendID;
        private int _ProductID;
        private double _initialWeight;
        private double _currentWeight;
        private double _PricePerTonne;
        private DateTime _ManufactureDate;
        private bool _sold;

        public bool Sold { get { return _sold; } set { _sold = true; } }
        public Product(int blendID,IList<Product> productList, double initialWeight, double pricePerTonne)
        {
            _blendID = blendID;
            _ProductID = productList.Count;
            _initialWeight = initialWeight;
            _currentWeight = initialWeight;
            _PricePerTonne = pricePerTonne;
            _ManufactureDate = DateTime.Now;
            _sold = false;
        }

        
    }
}
