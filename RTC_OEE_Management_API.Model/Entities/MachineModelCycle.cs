using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC_OEE_Management_API.Models.Entities
{
    public class MachineModelCycle
    {
        public int id { get; set; }
        public int machine_id { get; set; }
        public int model_id { get; set; }
        public decimal ideal_cycle_time { get; set; }
        public bool? isDelete { get; set; }
        public Machine Machine { get; set; }
        public Model Model { get; set; }
    }
}
