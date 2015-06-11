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
    [Table("OWM_Forecast3H_Wind", Schema = "public")]
    [DataContract]
    public class OWM_Forecast3H_Wind
    {
        protected const string _separator = ";";

        public OWM_Forecast3H_Wind()
        { }

        public string ToCSV()
        {
            string retVal = "";

            retVal=speed+_separator+deg+_separator;

            return retVal;
        }

        [Key]
        public int Id { get; set; }

        [DataMember]
        public double speed { get; set; }

        [DataMember]
        public double deg { get; set; }
    }
}
