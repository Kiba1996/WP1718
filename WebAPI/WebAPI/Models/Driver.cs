using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace project.Models
{
    public class Driver : User
    {
        public Location Location { get; set; }
        public Car Car {get; set;}


        public Driver() { }
        
    }
}