using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC_OEE_Management_API.Models.Entities
{
    public class Machine
    {
        public int machine_id { get; set; }
        public int zone_id { get; set; }
        public string machine_code { get; set; }
        public string machine_name { get; set; }
        public string machine_type { get; set; }
        public int? pos_x { get; set; }
        public int? pos_y { get; set; }
        public DateTime created_at { get; set; }
        public bool? isDelete { get; set; }

        public Zone Zone { get; set; }
        public ICollection<MachineModelCycle> MachineModelCycles { get; set; }
        public ICollection<PlannedDowntime> PlannedDowntimes { get; set; }
        public ICollection<MachineStatusLog> MachineStatusLogs { get; set; }
        public ICollection<ProductionCount> ProductionCounts { get; set; }
    }
}
