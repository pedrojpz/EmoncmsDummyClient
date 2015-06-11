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
     [Table("OWM_Historical_Snow", Schema = "public")]
    [DataContract]
    public class OWM_Historical_Snow
    {
         protected const string Separator = ";";

         public OWM_Historical_Snow()
         {

         }

         public string ToCSV()
         {
             string retVal = "";

             retVal += h3 + Separator;

             return retVal;
         }


         [Key]
         public int Id { get; set; }

        [DataMember(Name="3h")]
         public double h3 { get; set; }
    }
}
