using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static project.Models.Enums;

namespace project.Models
{
    public class Drive
    {
        public string DataAndTime { get; set; }
        public Location Arrival { get; set; }
        public CarType CarType { get; set; }
        public Customer Customer { get; set; }
        public Location Destination { get; set; }
        public Dispatcher Dispatcher { get; set; }
        public Driver Driver { get; set; }
        public Double Amount { get; set; }
        public Comment Comment { get; set; }
        public DriveStatus Status { get; set; }

        public Drive()
        {
            Amount = -1;
           //CarType = CarType.NoType;
        }

    }
    
}