using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace project.Models
{
    public class Location
    {
        public Double X { get; set; }
        public Double Y { get; set; }
        public Address Address { get; set; }

        public Location() { }
        public Location(Double x, Double y, Address a)
        {
            X = x;
            Y = y;
            Address = a;
        }
    }
}