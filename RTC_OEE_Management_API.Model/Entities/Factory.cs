using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC_OEE_Management_API.Models.Entities
{
    public class Factory
    {
        public int factory_id { get; set; }
        public string factory_code { get; set; }
        public string factory_name { get; set; }
        public string description { get; set; }
        public DateTime created_at { get; set; }
        public bool? isDelete { get; set; }
        public ICollection<Zone> Zones { get; set; }
    }
}
