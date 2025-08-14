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
        private double _pricePerTonne;
        private double _totalCostOfMatierials;
        private DateTime _ManufactureDate;
        private bool _sold;
        public int ProductID { get { return _ProductID; } }
        public int BlendID { get { return _blendID; } }
        public bool Sold { get { return _sold; } set { _sold = true; } }
        public DateTime ManufactureDate { get { return _ManufactureDate; } }
        public double weight { get { return _currentWeight; } }
        public double InitialWeight { get { return _initialWeight; } }
        public Product(int blendID,IList<Product> productList, double initialWeight, double pricePerTonne)
        {
            _blendID = blendID;
            _ProductID = productList.Count;
            _initialWeight = initialWeight;
            _currentWeight = initialWeight;
            _pricePerTonne = pricePerTonne;
            _totalCostOfMatierials = _pricePerTonne*_initialWeight;
            _ManufactureDate = DateTime.Now;
            _sold = false;
        }
        public void UpdateWeight(double weight)
        {
            _currentWeight = weight;
            _pricePerTonne = _totalCostOfMatierials/weight;
        }

        
    }
}
