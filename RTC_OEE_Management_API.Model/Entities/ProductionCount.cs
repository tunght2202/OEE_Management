using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC_OEE_Management_API.Models.Entities
{
    public class ProductionCount
    {
        public long id { get; set; }
        public int machine_id { get; set; }
        public int model_id { get; set; }
        public DateTime shift_date { get; set; }
        public string shift_code { get; set; }
        public int ok_qty { get; set; }
        public int ng_qty { get; set; }
        public DateTime created_at { get; set; }
        public bool? isDelete { get; set; }
        public Machine Machine { get; set; }
        public Model Model { get; set; }
    }
}
