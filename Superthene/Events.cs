using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Superthene
{
    // Handles stock level events and user alerts for low material supply.
    internal class Events
    {
        //Creates an event that will trigger a alert messages
        public delegate void StockLow(IList<MaterialSupply> MaterialSupplyList);
        public event StockLow Alert;

        // Notifies the user if any material supply levels are low.
        public void AlertUser(IList<MaterialSupply> MaterialSupplyList)
        {
            if (Alert != null)
            {
                Console.Clear();
                Console.WriteLine("The following matierials' supply levels are low!");
                Console.WriteLine("Please consider ordering more!\n");
                Alert(MaterialSupplyList);//Calls all subscribers

                Console.ReadKey();
            }
        }
    }
}
