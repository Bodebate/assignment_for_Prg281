using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Superthene
{
    internal class Machine
    {
        private int _machineID;
        private string _machineDetails;

        public int MachineID { get { return _machineID; } }
        public string MachineDetails { get { return _machineDetails; } }
        public Machine(IList<Machine> list)
        {
            _machineID = list.Count;
        }
    }
}
