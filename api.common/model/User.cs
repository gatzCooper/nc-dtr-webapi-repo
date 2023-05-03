using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.common.model
{
    public class User
    {
        public string userNo { get; set; }
        public string email { get; set; }
        public string role { get; set; }
        public string fName { get; set; }
        public string lName { get; set; }
        public string mName { get; set; }
        public string gender { get; set; }
        public string contact { get; set; }
        public string address { get; set; }
        public string department { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string status { get; set; }
        public DateTime createdAt { get; set; }
    }
}
