using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC_OEE_Management_API.Models.Entities
{
    public class PlannedDowntime
    {
        public int downtime_id { get; set; }
        public int machine_id { get; set; }
        public DateTime? shift_date { get; set; }
        public string? shift_code { get; set; }
        public DateTime? start_time { get; set; }
        public DateTime? end_time { get; set; }
        public string? reason { get; set; }
        public bool? isDelete { get; set; }
        public Machine Machine { get; set; }
    }
}
