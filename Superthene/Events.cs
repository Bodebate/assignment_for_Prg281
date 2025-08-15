using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Superthene
{

    internal class Events
    {
        public delegate void StockLow(IList<MatierialSupply> MatierialSupplyList);
        public event StockLow Alert;

        public void AlertUser(IList<MatierialSupply> MatierialSupplyList)
        {
            if (Alert != null)
            {
                Console.Clear();
                Console.WriteLine("The following matierials' supply levels are low!");
                Console.WriteLine("Please consider ordering more!\n");
                Alert(MatierialSupplyList);

                Console.ReadKey();
          
            }
        }
    }

}
    