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
    [Table("OWM_Forecast3H_Clouds", Schema = "public")]
    [DataContract]
    public class OWM_Forecast3H_Clouds
    {
        protected const string _separator = ";";
        public OWM_Forecast3H_Clouds()
        { }

        public string ToCSV()
        {
            string retVal = "";

            retVal=all+_separator;

            return retVal;
        }

        [Key]
        public int Id { get; set; }

        [DataMember]
        public int all { get; set; }
    }
}
