using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GameEngine.SimState
{
    [Serializable]
    public class SimObject
    {
        [XmlElement("Type")]
        /// <summary>
        /// 
        /// </summary>
        public ObjectType Type { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlArray("Properties")]
        [XmlArrayItem("Property")]
        public List<SimProperty> Properties { get; set; }

    }
}
