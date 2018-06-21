using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static project.Models.Enums;

namespace project.Models
{
    public abstract class User
    {
        public String UserName { get; set; }
        public String Password { get; set; }
        public String Name { get; set; }
        public String Surname { get; set; }
        public GenederType Gender { get; set; }
        public Int64 JMBG { get; set; }
        public String ContactPhoneNumber { get; set; }
        public String Email { get; set; }
        public RoleType Role { get; set; }
        public List<Drive> Drives { get; set; } 
    }

   

}