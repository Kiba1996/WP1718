using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static project.Models.Enums;

namespace project.Models
{
    public class Car
    {
        public String Driver { get; set; }//Driver Driver { get; set; }
        public int CarYear { get; set; }
        public String RegistrationNumber { get; set; }
        public int TaxiNumber { get; set; }
        public CarType CarType { get; set; }

        public Car() { }
        public Car(String d, int year, String reg, int tn, CarType c)
        {
            Driver = d;
            CarYear = year;
            RegistrationNumber = reg;
            TaxiNumber = tn;
            CarType = c;
        }
    }
}