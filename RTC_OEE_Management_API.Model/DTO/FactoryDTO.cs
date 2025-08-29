using RTC_OEE_Management_API.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC_OEE_Management_API.Models.DTO
{
    public class FactoryDTO
    {
        public int factory_id { get; set; }
        public string factory_code { get; set; }
        public string factory_name { get; set; }
        public string description { get; set; }
        public DateTime created_at { get; set; }
        public bool? isDelete { get; set; }
    }
}
