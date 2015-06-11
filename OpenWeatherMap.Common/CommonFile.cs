using OpenWeatherMapApiClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OpenWeatherMap.Common
{
    public class CommonFile
    {
        public static Stream Copy(Stream inputStream)
        {
            const int readSize = 256;
            byte[] buffer = new byte[readSize];
            MemoryStream ms = new MemoryStream();

            int count = inputStream.Read(buffer, 0, readSize);
            while (count > 0)
            {
                ms.Write(buffer, 0, count);
                count = inputStream.Read(buffer, 0, readSize);
            }
            ms.Position = 0;
            inputStream.Close();
            return ms;
        }

        public static Configuration ReadConfiguration()
        {
            Configuration retVal = new Configuration();

            XmlSerializer serializer = new XmlSerializer(typeof(Configuration));
            StreamReader reader = new StreamReader("Configuration.xml");
            retVal = (Configuration)serializer.Deserialize(reader);
            reader.Close();


            return retVal;
        }


        //**********************************************************************
       


        
    }
}
