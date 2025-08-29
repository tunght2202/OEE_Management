using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC_OEE_Management_API.Models.Entities
{
    public class User
    {
        public int user_id { get; set; }
        public int? dept_id { get; set; }
        public string username { get; set; }
        public string password_hash { get; set; }
        public string full_name { get; set; }
        public string role { get; set; }
        public DateTime created_at { get; set; }
        public bool? isDelete { get; set; }
        public Department Department { get; set; }
        public ICollection<UserPermission> UserPermissions { get; set; }
    }
}
