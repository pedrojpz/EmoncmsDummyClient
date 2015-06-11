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
    [Table("OWM_Forecast3H_Main", Schema = "public")]
    [DataContract]
    public class OWM_Forecast3H_Main
    {
        protected const string _separator = ";";
        public OWM_Forecast3H_Main()
        { }

        public string ToCSV()
        {
            string retVal = "";

            retVal = temp + _separator + temp_min + _separator + temp_max + _separator + pressure;
            retVal=_separator+sea_level+_separator+grnd_level+_separator+humidity+_separator+temp_kf+_separator;

            return retVal;
        }

        [Key]
        public int Id { get; set; }

        [DataMember]
        public double temp { get; set; }

        [DataMember]
        public double temp_min { get; set; }

        [DataMember]
        public double temp_max { get; set; }

        [DataMember]
        public double pressure { get; set; }

        [DataMember]
        public double sea_level { get; set; }

        [DataMember]
        public double grnd_level { get; set; }

        [DataMember]
        public double humidity { get; set; }

        [DataMember]
        public double temp_kf { get; set; }
    }
}
