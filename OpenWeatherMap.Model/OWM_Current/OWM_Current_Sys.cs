using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherMap.Model
{
    [Table("OWM_Current_Sys", Schema = "public")]
    [DataContract]
    public class OWM_Current_Sys
    {
        protected const string _separator = ";";
        public OWM_Current_Sys()
        { }

        public string ToCSV()
        {
            string retVal = "";

            retVal = message + _separator + country + _separator + sunrise + _separator + sunset + _separator;

            return retVal;
        }

        public int Id { get; set; }

        [DataMember]
        public string message { get; set; }

        [DataMember]
        public string country { get; set; }

        [DataMember]
        public int sunrise { get; set; }

        [DataMember]
        public int sunset { get; set; }
    }
}
