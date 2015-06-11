using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OpenWeatherMapApiClient
{
    [Serializable()]
    [XmlRoot("Configuration")]
    public class Configuration
    {
        [XmlArray("Cities")]
        [XmlArrayItem("City")]
        public List<int> Cities { get; set; }
    }
}
