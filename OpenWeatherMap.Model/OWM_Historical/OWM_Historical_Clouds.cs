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
    [Table("OWM_Historical_Clouds",Schema= "public")]
    [DataContract]
    public class OWM_Historical_Clouds
    {
        protected const string Separator = ";";

        public OWM_Historical_Clouds()
        {

        }

        public string ToCSV()
        {
            string retVal = "";

            retVal += all + Separator;

            return retVal;
        }

        [Key]
        public int Id { get; set; }

        [DataMember]
        public int all { get; set; }
    }
}
