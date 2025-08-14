using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Superthene
{
    internal class WeightLog
    {
        private int _entreeID;
        private int _productID;
        private double _weight;
        private int _machineID;

        public int productID { get { return _productID; } }
        public double weight { get { return _weight; } }
        public int macineID { get { return _machineID; } }

        public WeightLog(int ProductID,double RecordedWeight, int MachineId,IList<WeightLog> WeightLog)
        {
            _productID = ProductID;
            _weight = RecordedWeight;
            _machineID = MachineId;
            _entreeID = WeightLog.Count;
        }

    }
}
