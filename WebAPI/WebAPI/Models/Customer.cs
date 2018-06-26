using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace project.Models
{
    public class Customer : User
    {
        public bool Blocked { get; set; }

        public Customer() {
            Name = "";
            Surname = "";
            Role = Enums.RoleType.Customer;
            Blocked = false;
            Drives = new List<Drive>();
        }
    }
}