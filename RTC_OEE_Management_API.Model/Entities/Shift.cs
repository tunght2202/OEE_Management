using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC_OEE_Management_API.Models.Entities
{
    public class Shift
    {
        public int shift_id { get; set; }
        public string shift_code { get; set; }
        public string shift_name { get; set; }
        public TimeSpan start_time { get; set; }
        public TimeSpan end_time { get; set; }
        public bool? isDelete { get; set; }
    }
}
