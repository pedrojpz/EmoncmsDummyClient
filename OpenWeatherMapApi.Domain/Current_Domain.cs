using log4net;
using OpenWeatherMap.Common;
using OpenWeatherMap.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherMapApi.Domain
{
    public class Current_Domain:OWM_Base
    {
        private OWM_Current _owm_Current;
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public Current_Domain()
        { }
        public Current_Domain(OWM_Current owm_Current)
        {
            _owm_Current = owm_Current;
        }

        public bool GetByCity(List<int> cityId, DataMode mode)
        {
            bool retVal = true;
            string path="",csvContent="";
            Url += "/group?";
            Url += "id=" + string.Join(",",cityId);
            Url += "&mode=" + GetDataModeStr(mode);
            Url += "&units=metric";
            //"http://api.openweathermap.org/data/2.5/weather?id=2514256&mode=xml&units=metric"

            try
            {
                base.GetResponse();

                DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Group_OWM_Current));

                object objResponse = jsonSerializer.ReadObject(ResponseStream);

                Group_OWM_Current listcurrent = (Group_OWM_Current)objResponse;
                /*foreach(var elem in listcurrent.list)
                {
                    csvContent += elem.ToCSV();
                    _context.OWM_Currents.Add(elem);
                }*/

                listcurrent.CreatedAt = DateTime.UtcNow;
                csvContent += listcurrent.ToCSV();
                path = "Current-" + DateTime.Now.Year + ".csv"; 
                StreamWriter wr = new StreamWriter(path, true);
                wr.WriteLine(csvContent);

                wr.Flush();
                _context.OWM_Currents.Add(listcurrent);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                retVal = false;
                Log.Error(ex);
            }
            return retVal;

        }
        public string ToString()
        {
            string retVal = "",newLine=Environment.NewLine;
            retVal = "Respuesta: Cod: " + _owm_Current.cod + "; Dt: " + _owm_Current.dt+ newLine;
            retVal += "Id: " + _owm_Current.id + "; Name: " + _owm_Current.name+newLine;
            retVal += "Coord: Lon: " + _owm_Current.coord.lon + "; Lat: " + _owm_Current.coord.lat+newLine;
            retVal += "Base: " + _owm_Current.bbase + newLine;

            if (_owm_Current.weather != null)
            {
                retVal+= "Weather: "+newLine;
                for (int w = 0; w < _owm_Current.weather.Count; w++)
                {
                    retVal+="Id: " + _owm_Current.weather[w].id + "; Main: " + _owm_Current.weather[w].main + "; Description: " + _owm_Current.weather[w].description + "; Icon: " + _owm_Current.weather[w].icon+newLine;
                }
            }

            retVal+= "Sys: Message:" + _owm_Current.sys.message + "; Country: " + _owm_Current.sys.country + "; Sunrise: " + _owm_Current.sys.sunrise + "; Sunset: " + _owm_Current.sys.sunset+newLine;
            retVal+="Sys: Sunrise: " + _owm_Current.sys.sunrise + "; Sunset: " + _owm_Current.sys.sunset + newLine;
            retVal+= "Wind: Speed: " + _owm_Current.wind.speed + "; Deg: " + _owm_Current.wind.deg+newLine;
            retVal+= "Clouds: All: " + _owm_Current.clouds.all+newLine;


            return retVal;
        }
    }
}
