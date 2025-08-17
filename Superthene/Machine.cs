using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Superthene
{
    // Represents a machine used in the production process.
    internal class Machine
    {
        private int _machineID;
        private string _machineDetails;

        public int MachineID { get { return _machineID; } }
        public string MachineDetails { get { return _machineDetails; } }
        // Constructor: Assigns a unique machine ID based on the machine list count.
        public Machine(IList<Machine> list)
        {
            _machineID = list.Count;
        }
    }
}
