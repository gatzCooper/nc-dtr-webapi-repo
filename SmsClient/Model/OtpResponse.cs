using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsClient.Model
{
    public class OtpResponse
    {    
            public int message_id { get; set; }
            public int user_id { get; set; }
            public string user { get; set; }
            public int account_id { get; set; }
            public string account { get; set; }
            public string recipient { get; set; }
            public string message { get; set; }
            public int code { get; set; }
            public string sender_name { get; set; }
            public string network { get; set; }
            public string status { get; set; }
            public string type { get; set; }
            public string source { get; set; }
            public string created_at { get; set; }
            public string updated_at { get; set; }
        

    }
}
