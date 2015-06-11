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
    [Table("OWM_Forecast3H_Coordinates", Schema = "public")]
    [DataContract]
    public class OWM_Forecast3H_Coordinates
    {
        protected const string _separator = ";";
        public OWM_Forecast3H_Coordinates()
        { }

        public string ToCSV()
        {
            string retVal = "";

            retVal = lon + _separator + lat + _separator;

            return retVal;
        }

        [Key]
        public int Id { get; set; }

        [DataMember]
        public double lon { get; set; }

        [DataMember]
        public double lat { get; set; }

    }
}
