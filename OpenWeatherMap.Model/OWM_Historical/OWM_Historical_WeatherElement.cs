using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherMap.Model
{
    [Table("OWM_Historical_WeatherElement", Schema = "public")]
    [DataContract]
    public class OWM_Historical_WeatherElement
    {
        protected const string Separator = ";";

        public OWM_Historical_WeatherElement()
        {

        }

        public string ToCSV()
        {
            string retVal = "";

            retVal += id + Separator + main + Separator + description + Separator + icon + Separator;

            return retVal;
        }

        [Key]
        public int Id { get; set; }

        [DataMember]
        public int id { get; set; }

        [DataMember]
        public string main { get; set; }

        [DataMember]
        public string description { get; set; }

        [DataMember]
        public string icon { get; set; }
    }
}
