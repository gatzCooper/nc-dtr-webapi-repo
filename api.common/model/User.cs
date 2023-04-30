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
        public DateTime? Bday { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string EmailCode { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        public string Pic { get; set; }
        public string Department { get; set; }
        public string Schedule { get; set; }
        public string TrackFace { get; set; }
        public string TrainedFaces { get; set; }
        public int AttemptNo { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
