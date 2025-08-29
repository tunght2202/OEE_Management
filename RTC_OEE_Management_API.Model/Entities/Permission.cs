using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC_OEE_Management_API.Models.Entities
{
    public class Permission
    {
        public int perm_id { get; set; }
        public string perm_code { get; set; }
        public string perm_name { get; set; }

        public ICollection<UserPermission> UserPermissions { get; set; }
    }
}
