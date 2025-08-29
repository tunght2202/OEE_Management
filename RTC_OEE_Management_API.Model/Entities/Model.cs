using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC_OEE_Management_API.Models.Entities
{
    public class Model
    {
        public int model_id { get; set; }
        public string model_code { get; set; }
        public string model_name { get; set; }
        public string description { get; set; }
        public DateTime created_at { get; set; }
        public bool? isDelete { get; set; }
        public ICollection<MachineModelCycle> MachineModelCycles { get; set; }
        public ICollection<ProductionCount> ProductionCounts { get; set; }
    }
}
