using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherMap.Model
{
    public class OWM_Forecast3H_Rain
    {
        public OWM_Forecast3H_Rain()
        { }
        [DataMember(Name="3h")]
        public double h3{get;set;}

        public string ToCSV()
        {
            string retval = "";

            retval = h3.ToString();
            return retval;
        }
    }
}
