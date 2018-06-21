using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace project.Models
{
    public class Customer : User
    {
        public Customer() {
            Name = "";
            Surname = "";
            Role = Enums.RoleType.Customer;
            Drives = new List<Drive>();
        }
    }
}