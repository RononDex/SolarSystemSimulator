using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarSystemSimulator.SimStates
{
    /// <summary>
    /// Represents the state of a single object within the simulation
    /// </summary>
    [Serializable]
    public class SimObject
    {
        /// <summary>
        /// The properties for this object for the current state
        /// </summary>
        public Dictionary<string, object> Properties { get; set; }

    }
}
