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
         // Gets the machine Id used in the production process
        public int MachineID { get { return _machineID; } }
        //Gets the details of the machine
        public string MachineDetails { get { return _machineDetails; } }
        // Constructor: Assigns a unique machine ID based on the machine list count.
        public Machine(IList<Machine> list,string machineDetails)
        {
            _machineID = list.Count;
            _machineDetails = machineDetails;
        }
    }
}
