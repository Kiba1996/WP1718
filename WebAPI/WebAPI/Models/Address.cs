using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace project.Models
{
    public class Address
    {
        public String Street { get; set; }
        public String Number { get; set; }
        public String Town { get; set; }
        public int PostalCode { get; set; }

        public Address() { }
        public Address(String street, String number, String town, int postalCode)
        {
            Street = street;
            Number = number;
            Town = town;
            PostalCode = postalCode;
        }
    }
}