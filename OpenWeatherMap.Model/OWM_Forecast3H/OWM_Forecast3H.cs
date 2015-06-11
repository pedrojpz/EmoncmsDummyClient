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
     [Table("OWM_Current_Wind",Schema="public")]
    [DataContract]
    public class OWM_Forecast3H
    {
         protected const string _separator = ";";
         public OWM_Forecast3H()
         {
             list = new List<OWM_Forecast3H_Forecast>();
         }

         public string ToCSV()
         {
             string retVal = "";

             retVal = CreatedAt+_separator+ cod + _separator + message + _separator;

             if(city!=null)
             {
                 retVal+= city.ToCSV();
             }
             else
             {
                 retVal += _separator;
             }
             retVal += cnt+_separator;

             if((list!=null)&&(list.Count()>0))
             {
                 foreach(var elem in list)
                 {
                     retVal += elem.ToCSV();
                 }
             }
             else
             {
                 retVal += _separator;
             }
             return retVal;
         }

         [Key]
         public int Id { get; set; }

         public DateTime CreatedAt { get; set; }

        [DataMember]
         public string cod { get; set; }

        [DataMember]
        public string message { get; set; }

        //internal string city;
        [DataMember]
        public virtual OWM_Forecast3H_City city { get; set; }

        [DataMember]
        public int cnt { get; set; }

        [DataMember]
        public virtual List<OWM_Forecast3H_Forecast> list { get; set; }
    }
}
