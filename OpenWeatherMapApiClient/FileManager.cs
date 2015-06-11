using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace OpenWeatherMapApiClient
{
    class FileManager
    {
        public static void WriteFile(string filename, string fileContent)
        {
            StreamWriter sw = new StreamWriter(filename);

            sw.Write(fileContent);
            sw.Close();
        }
    }
}
