using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace project.Models
{
    public class Address
    {
        public String AddressFormat { get; set; }
        

        public Address()
        {
        }
        public Address(String format)
        {
            AddressFormat = format;
            
        }
    }
}