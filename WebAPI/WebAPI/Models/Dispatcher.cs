using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace project.Models
{
    public class Dispatcher : User
    {
        public Dispatcher() {
            Name = "";
            Surname = "";
            Role = Enums.RoleType.Dispatcher;
            Drives = new List<Drive>();
        }
    }
}