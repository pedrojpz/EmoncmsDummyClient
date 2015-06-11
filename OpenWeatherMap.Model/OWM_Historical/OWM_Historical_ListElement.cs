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
    [Table("OWM_Historical_ListElement", Schema = "public")]
    [DataContract]
    public class OWM_Historical_ListElement
    {
        protected const string Separator = ";";

        public OWM_Historical_ListElement()
        {
            weather = new List<OWM_Historical_WeatherElement>();
        }

        public string ToCSV()
        {
            string retVal = "";

            if(main!=null)
            {
                retVal+=main.ToCSV();
            }
            else
            {
                retVal += Separator;
            }
            if (wind != null)
            {
                retVal += wind.ToCSV();
            }
            else
            {
                retVal += Separator;
            }
            if (clouds != null)
            {
                retVal += clouds.ToCSV();
            }
            else
            {
                retVal += Separator;
            }

            if((weather!=null)||(weather.Count()>0))
            {
                foreach(var elem in weather)
                {
                    retVal += elem.ToCSV();
                }
            }
            else
            {
                retVal += Separator;
            }

            retVal += dt + Separator;

            return retVal;
        }

        [Key]
        public int Id { get; set; }

        [DataMember]
        public virtual OWM_Historical_Main main { get; set; }

        [DataMember]
        public virtual OWM_Historical_Wind wind { get; set; }

        [DataMember]
        public virtual OWM_Historical_Clouds clouds { get; set; }

        [DataMember]
        public virtual List<OWM_Historical_WeatherElement> weather { get; set; }

        [DataMember]
        public ulong dt { get; set; }
    }
}
