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
    [Table("OWM_Historical",Schema= "public")]
    [DataContract]
    public class OWM_Historical
    {
        protected const string Separator = ";";

        public OWM_Historical()
        {
            list = new List<OWM_Historical_ListElement>();
        }

        public string ToCSV()
        {
            string retVal = "";

            retVal = message+Separator+CreatedAt + Separator + cod + Separator + city_id + Separator + calctime + Separator + cnt + Separator;

            if((list!=null)&&(list.Count()>0))
            {
                foreach(var elem in list)
                {
                    retVal += elem.ToCSV() ;
                } 
            }
            else
            {
                retVal += Separator;
            }

            return retVal;
        }
        [Key]
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        [DataMember]
        public string message { get; set; }

        [DataMember]
        public int cod { get; set; }

        [DataMember]
        public ulong city_id { get; set; }

        [DataMember]
        public double calctime { get; set; }

        [DataMember]
        public int cnt { get; set; }

        [DataMember]
        public virtual List<OWM_Historical_ListElement> list { get; set; }
    }
}
