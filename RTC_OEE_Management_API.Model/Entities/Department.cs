using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC_OEE_Management_API.Models.Entities
{
    public class Department
    {
        public int dept_id { get; set; }
        public string dept_code { get; set; }
        public string dept_name { get; set; }
        public bool? isDelete { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
