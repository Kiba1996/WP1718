using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace project.Models
{
    public class Address
    {
        public String AddressFormat { get; set; }
        //public String Number { get; set; }
        //public String Town { get; set; }
        //public int PostalCode { get; set; }

        public Address()
        {
           // AddressFormat = "";

        }
        public Address(String format)
        {
            AddressFormat = format;
            
        }
    }
}