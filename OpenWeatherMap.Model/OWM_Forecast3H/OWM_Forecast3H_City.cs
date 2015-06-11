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
    [Table("OWM_Forecast3H_City", Schema = "public")]
    [DataContract]
    public class OWM_Forecast3H_City
    {
        protected const string _separator = ";";
        public OWM_Forecast3H_City()
        { }

        public string ToCSV()
        {
            string retVal = "";

            retVal = id + _separator + name + _separator;
            if(coord==null)
            {
                retVal += coord.ToCSV();
            }
            else
            {
                retVal += _separator;
            }

            retVal += country + _separator + population+_separator;

            return retVal;
        }

        [Key]
        public int Id { get; set; }

        [DataMember]
        public int id { get; set; }

        [DataMember]
        public string name { get; set; }

        [DataMember]
        public virtual OWM_Forecast3H_Coordinates coord { get; set; }

        [DataMember]
        public string country { get; set; }

        [DataMember]
        public int population { get; set; }
    }
}
