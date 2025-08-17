using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Superthene
{

    internal class Events
    {
        public delegate void StockLow(IList<MaterialSupply> MaterialSupplyList);
        public event StockLow Alert;

        public void AlertUser(IList<MaterialSupply> MaterialSupplyList)
        {
            if (Alert != null)
            {
                Console.Clear();
                Console.WriteLine("The following matierials' supply levels are low!");
                Console.WriteLine("Please consider ordering more!\n");
                Alert(MaterialSupplyList);

                Console.ReadKey();
          
            }
        }
    }

}
    