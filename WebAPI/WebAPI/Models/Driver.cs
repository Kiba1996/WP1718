﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace project.Models
{
    public class Driver : User
    {
        public Location Location { get; set; }
        public Car Car {get; set;}
        public bool Zauzet { get; set; }
        public bool Blocked { get; set; }
        public Driver() {
           
            Name = "";
            Surname = "";
            Role = Enums.RoleType.Driver;
            Drives = new List<Drive>();
            Blocked = false;
        }
        
    }
}