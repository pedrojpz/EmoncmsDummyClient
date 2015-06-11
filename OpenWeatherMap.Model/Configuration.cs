using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OpenWeatherMap.Model
{
    public class Configuration
    {
        public Configuration()
        {
            Cities = new List<int>();
        }

        [XmlElement]
        public List<int> Cities;
    }
}
