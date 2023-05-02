using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.common.model
{
    public class User
    {
        public int Id { get; set; }
        public string UserNo { get; set; }
        public string email { get; set; }
        public string Role { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Mname { get; set; }
        public string Gender { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
        public string Username { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
