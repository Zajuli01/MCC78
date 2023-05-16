using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TugasGG.Model
{
    public class Account
    {
        public string employee_id { get; set; }
        public string password { get; set; }
        public bool is_deleted { get; set; }
        public string otp { get; set; }
        public bool is_used { get; set; }
        public string expired_time { get; set; }
    }
}
