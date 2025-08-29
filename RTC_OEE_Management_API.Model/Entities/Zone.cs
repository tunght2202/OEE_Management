using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace RTC_OEE_Management_API.Models.Entities
{
    public class Zone
    {
        public int zone_id { get; set; }
        public int factory_id { get; set; }
        public int? parent_zone_id { get; set; }
        public string? zone_code { get; set; }
        public string? zone_name { get; set; }
        public string? layout_image { get; set; }
        public DateTime? created_at { get; set; }
        public bool? isDelete { get; set; }
        public Factory Factory { get; set; }
        public Zone ParentZone { get; set; }
        public ICollection<Zone> ChildZones { get; set; }
        public ICollection<Machine> Machines { get; set; }
    }
}
