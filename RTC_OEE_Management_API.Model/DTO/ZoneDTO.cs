using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC_OEE_Management_API.Models.DTO
{
    public class ZoneDTO
    {
        public int zone_id { get; set; }
        public int factory_id { get; set; }
        public int? parent_zone_id { get; set; }
        public string? zone_code { get; set; }
        public string? zone_name { get; set; }
        public string? layout_image { get; set; }
        public DateTime? created_at { get; set; }
        public bool? isDelete { get; set; }
    }
}
