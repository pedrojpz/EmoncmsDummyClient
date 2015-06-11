using log4net;
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
    public class ForeCast3H_Domain:OWM_Base
    {
        public OWM_Forecast3H _owm_forecast3h;
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public ForeCast3H_Domain():base()
        {}
        public ForeCast3H_Domain(OWM_Forecast3H foreCast3H):this()
        {
            _owm_forecast3h = foreCast3H;
        }


        public bool GetByCity(List<int> cities, DataMode mode)
        {
            string path="",tmpUrl = "";
            bool retVal=true;
            Url += "forecast?";
            Url += "&mode=" + GetDataModeStr(mode);
            Url += "&units=metric";
            //http://api.openweathermap.org/data/2.5/forecast?id=524901
            DataContractJsonSerializer jsonSerializer;
            string csv = "";
            try
            {
               
                tmpUrl = Url;
                foreach(var city in cities)
                {
                    Url = tmpUrl;
                    Url +="&id=" + city;
                    base.GetResponse();
                    jsonSerializer = new DataContractJsonSerializer(typeof(OWM_Forecast3H));

                    object objResponse = jsonSerializer.ReadObject(ResponseStream);

                    _owm_forecast3h = (OWM_Forecast3H)objResponse;
                    _owm_forecast3h.CreatedAt = DateTime.UtcNow;
                     csv+= _owm_forecast3h.ToCSV()+Environment.NewLine;
                    _context.OWM_Forecast3H.Add(_owm_forecast3h);
                }

                path = "ForeCast3H-" + DateTime.Now.Year + ".csv";
                StreamWriter wr = new StreamWriter(path, true);
                wr.WriteLine(csv);
                wr.Flush();
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                retVal = false;
                Log.Error(ex);
            }

            return retVal;
        }

        public string ToString()
        {
            string reTval = "", newLine=System.Environment.NewLine;
            reTval = "Respuesta: Cod: " + _owm_forecast3h.cod + "; Message: " + _owm_forecast3h.message + newLine;
            reTval += "City: Id: " + _owm_forecast3h.city.id + "; Name: " + _owm_forecast3h.city.name + "; Country: " + _owm_forecast3h.city.country + "; Population: " + _owm_forecast3h.city.population + newLine;
            reTval += "City: Lon: " + _owm_forecast3h.city.coord.lon + "; Lat: " + _owm_forecast3h.city.coord.lat + newLine;
            reTval += "Cnt: " + _owm_forecast3h.cnt + newLine;

            if (_owm_forecast3h.list != null)
            {
                reTval += "List: " + newLine;
                for (int f = 0; f < _owm_forecast3h.list.Count; f++)
                {
                    reTval += "Dt: " + _owm_forecast3h.list[f].dt + "; Dt_txt: " + _owm_forecast3h.list[f].dt_txt + newLine;

                    if (_owm_forecast3h.list[f].weather != null)
                    {
                        for (int w = 0; w < _owm_forecast3h.list[f].weather.Count; w++)
                        {
                            OWM_Forecast3H_Weather wea = _owm_forecast3h.list[f].weather[w];
                            reTval += "Weather: Id:" + wea.id + "; Main: " + wea.main + "; Description: " + wea.description + "; Icon: " + wea.icon + newLine;
                        }
                    }

                    reTval += "Clouds: All: " + _owm_forecast3h.list[f].clouds.all + newLine;
                    reTval += "Wind: Speed: " + _owm_forecast3h.list[f].wind.speed + "; Deg:" + _owm_forecast3h.list[f].wind.deg + newLine;
                    reTval += "Sys: Pod: " + _owm_forecast3h.list[f].sys.pod + newLine;
                }
            }

            return reTval;
        }
    }
}
