using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC_OEE_Management_API.Models.DTO
{
    public class ModelDTO
    {
        public int model_id { get; set; }
        public string? model_code { get; set; }
        public string? model_name { get; set; }
        public string? description { get; set; }
        public DateTime? created_at { get; set; }
        public bool? isDelete { get; set; }
    }
}
