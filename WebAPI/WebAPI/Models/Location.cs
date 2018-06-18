using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace project.Models
{
    public class Location
    {
        public String X { get; set; }
        public String Y { get; set; }
        public Address Address { get; set; }

        public Location() { }
        public Location(String x, String y, Address a)
        {
            X = x;
            Y = y;
            Address = a;
        }
    }
}