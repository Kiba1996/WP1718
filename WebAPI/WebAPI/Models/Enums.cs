using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace project.Models
{
    public static class Enums
    {
        public enum DriveStatus{ Created_Waiting, Canceled, Formed, Processed, Accepted, Successful, Unsuccessful }
        public enum CarType{ NoType, PassengerCar, Van }
        public enum GenederType { Male, Female }
        public enum RoleType { Customer, Dispatcher, Driver }

    }
}