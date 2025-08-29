using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC_OEE_Management_API.Models.Entities
{
    public class UserPermission
    {
        public int user_id { get; set; }
        public int perm_id { get; set; }

        public User User { get; set; }
        public Permission Permission { get; set; }
    }
}
