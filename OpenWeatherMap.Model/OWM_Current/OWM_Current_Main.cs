using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherMap.Model
{
    [Table("OWM_Current_Main", Schema = "public")]
    [DataContract]
    public class OWM_Current_Main
    {
        protected const string Separator = ";";
        public OWM_Current_Main()
        { }

        public string ToCSV()
        {
            string retVal = "";

            retVal = temp + Separator + temp_min + Separator + temp_max + Separator;
            retVal+=pressure + Separator + sea_level + Separator + grnd_level + Separator + humidity + Separator;

            return retVal;
        }

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
    }
}
