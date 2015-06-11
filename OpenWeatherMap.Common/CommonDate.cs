using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherMap.Common
{
    public static class CommonDate
    {
        public static DateTime UnixTimeStampToDateTime(ulong unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }


        public static string UnixDateToString(ulong unixTimeStamp)
        {
            DateTime date1 = UnixTimeStampToDateTime(unixTimeStamp);

            return date1.Year.ToString() + "/" + date1.Month.ToString().PadLeft(2, '0') + "/" + date1.Day.ToString().PadLeft(2, '0') + " " + date1.Hour.ToString().PadLeft(2, '0') + ":" + date1.Minute.ToString().PadLeft(2, '0');
        }
    }
}
