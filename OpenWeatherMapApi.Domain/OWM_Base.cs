using OpenWeatherMap.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherMapApi.Domain
{
 
    public class OWM_Base
    {
        public enum DataMode { JSON, XML };
        protected string Url="http://api.openweathermap.org/data/2.5/";

        protected string ResponseString { get; set; }
        protected Stream ResponseStream { get; set; }

        protected OWMContext _context;
        public OWM_Base()
        {
            _context = new OWMContext();
        }

        public bool GetResponse()
        {
            bool retVal = true;
            string responseString = "";
            Stream responseStream;
            CommonNetwork.GetResponseStringAndStream(Url, out responseString, out responseStream);
            ResponseStream = responseStream;
            ResponseString = responseString;

            return retVal;
        }

        protected static string GetDataModeStr(DataMode dm)
        {
            switch (dm)
            {
                case DataMode.JSON: return "JSON";
                    break;
                case DataMode.XML: return "XML";
                    break;
                default: return "JSON";
                    break;
            }
        }
    }
}
