using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC_OEE_Management_API.Models.Context
{
    public static class Config
    {
        public static string ConnectionString
        {
            get
            {
                string connectionString = "server=localhost;user=root;password=Bongmatntk9;database=rtc_oee_management;"; ;
                return connectionString;
            }
        }


    }
}
