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
    public class Historical_Domain:OWM_Base
    {
        public OWM_Historical _historical;
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public Historical_Domain(OWM_Historical historical):this()
        {
            _historical = historical;
            
        }
        public Historical_Domain():base()
        { }

        public bool GetByCity(List<int> cities, DataMode mode)
        {
            bool retVal = true;
            DataContractJsonSerializer jsonSerializer;
            string tmpUrl = "";
            Url += "history/city?";
            string csv = "";
            Url += "&mode=" + GetDataModeStr(mode);
            Url += "&type=hour";
            Url += "&units=metrics";
            //http://api.openweathermap.org/data/2.5/history/city?id=2885679&type=hour


            try
            {
              
                //CommonNetwork.GetResponseStringAndStream(url, out responseString, out responseStream);
                tmpUrl = Url;
                foreach(var city in cities)
                {
                    Url = tmpUrl;
                    Url += "&id=" + city;
                    base.GetResponse();
                    jsonSerializer = new DataContractJsonSerializer(typeof(OWM_Historical));

                    object objResponse = jsonSerializer.ReadObject(ResponseStream);

                    _historical = (OWM_Historical)objResponse;
                    _historical.CreatedAt = DateTime.UtcNow;
                    _context.OWM_Historicals.Add(_historical);
                     csv += _historical.ToCSV()+Environment.NewLine;
                }
                string path="Historical-"+DateTime.Now.Year+".csv";
              /*  if (!File.Exists(path))
                {
                    File.Create(path);
                }*/

                StreamWriter wr = new StreamWriter(path, true);
                wr.WriteLine(csv);
                wr.Flush();
                /*OWM_Historical_WeatherElement s=new OWM_Historical_WeatherElement();
                var l = new List<OWM_Historical_WeatherElement>();
                l.Add(s);
                 var elem=new OWM_Historical_ListElement()
                 { 
                      clouds=new OWM_Historical_Clouds(),
                       main=new OWM_Historical_Main(),
                        wind=new OWM_Historical_Wind(),
                        weather=l
                 };
                 _historical.list.Add(elem);*/
              
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
            string retVal = "",newLine=System.Environment.NewLine;
            OWM_Historical_ListElement element;
            OWM_Historical_WeatherElement weatherElement;


            retVal="Respuesta: Message: " + _historical.message + "; Cod: " + _historical.cod + "; CityId: " + _historical.city_id + "; Calctime: " + _historical.calctime+newLine;
            retVal+= "Cnt: " + _historical.cnt+newLine;

            if (_historical.list != null)
            {
                for (int h = 0; h < _historical.list.Count; h++)
                {
                    element = _historical.list[h];
                    retVal+="Main: Temp: " + element.main.temp + "; Temp_min: " + element.main.temp_min + "; Temp_max: " + element.main.temp_max + "; Humidity: " + element.main.humidity + "; Pressure: " + element.main.pressure+newLine;
                    retVal += "Wind: Speed: " + element.wind.speed + "; Gust: " + element.wind.gust + "; Deg: " + element.wind.deg + newLine;
                    retVal += "Clouds: All: " + element.clouds.all + newLine;

                    if (element.weather != null)
                    {
                        for (int w = 0; w < element.weather.Count; w++)
                        {
                            weatherElement = element.weather[w];
                            retVal+="Weather: Id: " + weatherElement.id + "; Main: " + weatherElement.main + "; Description: " + weatherElement.description + "; Icon: " + weatherElement.icon+newLine;

                        }
                    }
                    retVal += "Dt: " + element.dt + " Dt(date): " + CommonDate.UnixDateToString(element.dt) + newLine;
                }
            }

            return retVal;
        }
    }
}
