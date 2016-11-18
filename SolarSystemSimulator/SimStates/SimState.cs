using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SolarSystemSimulator.SimStates
{
    [Serializable]
    public class SimState
    {
        /// <summary>
        /// Holds a list of all the simulation objects
        /// </summary>
        public List<SimObject> Objects { get; set; }

        /// <summary>
        /// Saves the current state to an XML (uses XML Serialization)
        /// </summary>
        /// <param name="filename"></param>
        public void SaveToXml(string filename)
        {
            XmlSerializer ser = new XmlSerializer(typeof(SimState));

            TextWriter writer = new StreamWriter(filename);
            ser.Serialize(writer, this);
            writer.Close();
        }

        /// <summary>
        /// Loads the state from a save file (uses XML Serialization)
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static SimState LoadFromXml(string filename)
        {
            #region PRECONDITION

            if (!File.Exists(filename))
                throw new FileNotFoundException(string.Format("File \"{0}\" does not exist", filename));

            #endregion

            XmlSerializer ser = new XmlSerializer(typeof(SimState));

            var state = (SimState)ser.Deserialize(File.OpenRead(filename));
            return state;
        }
    }
}
