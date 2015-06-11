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
     [Table("OWM_Historical_Wind", Schema = "public")]
    [DataContract]
    public class OWM_Historical_Wind
    {
         protected const string Separator = ";";

         public OWM_Historical_Wind()
         {
         }

         [Key]
         public int Id { get; set; }

        [DataMember]
         public double speed { get; set; }

        [DataMember]
        public double gust { get; set; }

        [DataMember]
        public double deg { get; set; }

         public string ToCSV()
        {
            string retVal = "";

            retVal = speed + Separator + gust + Separator + deg+Separator;

            return retVal;
        }
    }
}
