using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC_OEE_Management_API.Models.Entities
{
    public class MachineStatusLog
    {
        public long log_id { get; set; }
        public int machine_id { get; set; }
        public DateTime shift_date { get; set; }
        public string shift_code { get; set; }
        public string status { get; set; }   // RUN or STOP
        public DateTime start_time { get; set; }
        public DateTime? end_time { get; set; }
        public int? unplanned_reason_id { get; set; }
        public string note { get; set; }
        public bool? isDelete { get; set; }
        [ForeignKey("machine_id")]
        public Machine Machine { get; set; }
        public UnplannedDowntimeReason UnplannedReason { get; set; }
    }
}
