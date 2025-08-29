using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC_OEE_Management_API.Models.Entities
{
    public class UnplannedDowntimeReason
    {
        public int reason_id { get; set; }
        public string reason_code { get; set; }
        public string reason_name { get; set; }
        public string description { get; set; }
        public bool? isDelete { get; set; }
        public ICollection<MachineStatusLog> MachineStatusLogs { get; set; }
    }
}
