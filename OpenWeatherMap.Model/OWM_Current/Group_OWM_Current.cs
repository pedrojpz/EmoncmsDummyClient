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
    [DataContract]
    [Table("Group_OWM_Current",Schema="public")]
    public class Group_OWM_Current
    {
        protected const string Separator = ";";
        [DataMember]
        public int cnt { get; set; }

        [Key]
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }

        [DataMember]
        public List<OWM_Current> list { get; set; }


        public string ToCSV()
        {
            string retVal = "";

            retVal = CreatedAt + Separator+cnt+Separator;
            if((list!=null)&&(list.Count>0))
            {
                foreach(var item in list)
                {
                    retVal+=item.ToCSV();
                }
            }

            return retVal;
        }

        public Group_OWM_Current()
        {
            list = new List<OWM_Current>();
        }
    }
}
