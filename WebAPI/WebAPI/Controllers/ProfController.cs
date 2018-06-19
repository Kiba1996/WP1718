using project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.DataIO;
using WebAPI.MyHelpers;

namespace WebAPI.Controllers
{
    public class ProfController : ApiController
    {
        public static XMLDataIO xml = new XMLDataIO();

        [HttpGet]
        [ActionName("GetUserByUsername")]
        public User GetUserByUsername(string username)
        {
            string ss = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Users.xml");
            string adm = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Admins.xml");
            string drv = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Drivers.xml");

            List<Customer> users = xml.ReadUsers(ss);
            List<Dispatcher> admins = xml.ReadDispatcher(adm);
            List<Driver> drivers = xml.ReadDrivers(drv);

            foreach (Customer us in users) { 
                if (us.UserName == username)
                {
                    Customer kor = new Customer();
                    kor.UserName = us.UserName;
                    kor.Name = us.Name;
                    kor.Surname = us.Surname;
                    kor.Role = us.Role;
                    kor.Email = us.Email;
                    kor.ContactPhoneNumber = us.ContactPhoneNumber;
                    kor.Gender =us.Gender;
                    kor.Password = null;
                    kor.JMBG = us.JMBG;
                   // kor.Drives = us.Drives;
                    
                    return kor;
                }
            }

            foreach (Dispatcher us in admins)
            {
                if (us.UserName == username)
                {
                    Dispatcher kor = new Dispatcher();
                    kor.UserName = us.UserName;
                    kor.Name = us.Name;
                    kor.Surname = us.Surname;
                    kor.Role = us.Role;
                    kor.Email = us.Email;
                    kor.ContactPhoneNumber = us.ContactPhoneNumber;
                    kor.Gender = us.Gender;
                    kor.Password = null;
                    kor.JMBG = us.JMBG;
                    // kor.Drives = us.Drives;

                    return kor;
                }
            }


            foreach (Driver us in drivers)
            {
                if (us.UserName == username)
                {
                    Driver kor = new Driver();
                    kor.UserName = us.UserName;
                    kor.Name = us.Name;
                    kor.Surname = us.Surname;
                    kor.Role = us.Role;
                    kor.Email = us.Email;
                    kor.ContactPhoneNumber = us.ContactPhoneNumber;
                    kor.Gender = us.Gender;
                    kor.Password = null;
                    kor.JMBG = us.JMBG;
                    //kor.Location = new Location();
                    
                    // kor.Drives = us.Drives;

                    return kor;
                }
            }

            return null;
        }

        [HttpPost]
        [ActionName("AddDriveCustomer")]
        public bool AddDriveCustomer([FromBody]DriveR k)
        {
            string ss = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Users.xml");
            string ss1 = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Drives.xml");

            List<Customer> users = xml.ReadUsers(ss);
            List<Drive> drives = xml.ReadDrives(ss1);
           // bool g = true;
            User c = new Customer();
            Drive drive = new Drive();
            foreach (Customer u in users)
            {
                if (u.UserName == k.korisnicko)
                {
                    c = u;
                    Address a = new Address(k.Street, k.Number, k.Town, Int32.Parse(k.PostalCode));
                    Location l = new Location(k.XCoord, k.YCoord, a);
                    drive.Customer = (Customer)c;
                    drive.Arrival = l;
                    if (k.tipAuta != "")
                    {
                        drive.CarType = (Enums.CarType)int.Parse(k.tipAuta);
                    }
                    drive.Amount = 0;
                    drive.Comment = new Comment();
                    drive.DataAndTime = DateTime.Now;
                    drive.Destination = new Location();
                    drive.Dispatcher = new Dispatcher();
                    drive.Driver = new Driver();
                    drive.Status = Enums.DriveStatus.Created_Waiting;
                   // u.Drives.Add(drive);

                    //  g = false;
                }
            }
            
               drives.Add(drive);
               //xml.WriteUsers(users, ss);
               xml.WriteDrives(drives, ss1);
               
                return true;
           

        }


        [HttpPost]
        [ActionName("AddDriveDispatcher")]
        public bool AddDriveDispatcher([FromBody]DriveR k)
        {
            string ss = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Users.xml");
            string ss1 = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Drives.xml");
            string adm = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Admins.xml");
            string drv = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Drivers.xml");

            List<Dispatcher> users = xml.ReadDispatcher(adm);
            List<Drive> drives = xml.ReadDrives(ss1);
            List<Driver> drivers = xml.ReadDrivers(drv);

            // bool g = true;
            User c = new Dispatcher();
            Drive drive = new Drive();
            foreach (Dispatcher u in users)
            {
                if (u.UserName == k.korisnicko)
                {
                    c = u;
                    Address a = new Address(k.Street, k.Number, k.Town, Int32.Parse(k.PostalCode));
                    Location l = new Location(k.XCoord, k.YCoord, a);
                    drive.Customer = new Customer();
                    drive.Arrival = l;
                    if (k.tipAuta != "")
                    {
                        drive.CarType = (Enums.CarType)int.Parse(k.tipAuta);
                    }
                    drive.Amount = 0;
                    drive.Comment = new Comment();
                    drive.DataAndTime = DateTime.Now;
                    drive.Destination = new Location();
                    drive.Dispatcher = (Dispatcher)c;
                    //drive.Driver = new Driver();
                    drive.Status = Enums.DriveStatus.Formed;
                    // u.Drives.Add(drive);
                    break;
                    //  g = false;
                }
            }

            bool p = false;
            foreach(Driver d in drivers)
            {
                if (!d.Zauzet && (d.Car.CarType == (Enums.CarType)int.Parse(k.tipAuta)))
                {
                    d.Zauzet = true;
                    drive.Driver = d;
                    p = true;
                    break;
                }
            }
            if(!p)
            {
                drive.Status = Enums.DriveStatus.Created_Waiting;
                drive.Driver = new Driver();
            }

            drives.Add(drive);
            xml.WriteDrivers(drivers, drv);
            xml.WriteDrives(drives, ss1);

            return true;


        }

        [HttpPost]
        [ActionName("GetFilterUser")]
        public List<Drive> GetFilterUser([FromBody]UserFilter k)
        {
            string ss = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Drives.xml");

            List<Drive> listaDrives = xml.ReadDrives(ss);
            List<Drive> listaDrives1 = new List<Drive>();
            if ((Enums.RoleType)int.Parse(k.Role) == Enums.RoleType.Customer)
            {
                foreach (Drive d in listaDrives)
                {
                    if (d.Status == (Enums.DriveStatus)int.Parse(k.Stat) && d.Customer.UserName == k.Username)//.Customer.UserName == username || d.Dispatcher.UserName == username || d.Driver.UserName == username)
                    {
                        listaDrives1.Add(d);
                    }
                }
            }
            else if((Enums.RoleType)int.Parse(k.Role) == Enums.RoleType.Driver)
            {
                foreach (Drive d in listaDrives)
                {
                    if (d.Status == (Enums.DriveStatus)int.Parse(k.Stat) && d.Driver.UserName == k.Username)//.Customer.UserName == username || d.Dispatcher.UserName == username || d.Driver.UserName == username)
                    {
                        listaDrives1.Add(d);
                    }
                }
            }
            else if ((Enums.RoleType)int.Parse(k.Role) == Enums.RoleType.Dispatcher)
            {
                foreach (Drive d in listaDrives)
                {
                    if (d.Status == (Enums.DriveStatus)int.Parse(k.Stat) && d.Dispatcher.UserName == k.Username)//.Customer.UserName == username || d.Dispatcher.UserName == username || d.Driver.UserName == username)
                    {
                        listaDrives1.Add(d);
                    }
                }
            }
            return listaDrives1;
        }


        

        [HttpPost]
        [ActionName("GetFilterUserAdm")]
        public List<Drive> GetFilterUserAdm([FromBody]UserFilter k)
        {
            string ss = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Drives.xml");

            List<Drive> listaDrives = xml.ReadDrives(ss);
            List<Drive> listaDrives1 = new List<Drive>();
            if ((Enums.RoleType)int.Parse(k.Role) == Enums.RoleType.Dispatcher)
            {
                foreach (Drive d in listaDrives)
                {
                    if (d.Status == (Enums.DriveStatus)int.Parse(k.Stat))//.Customer.UserName == username || d.Dispatcher.UserName == username || d.Driver.UserName == username)
                    {
                        listaDrives1.Add(d);
                    }
                }
            }
            return listaDrives1;
        }
        
         [HttpPost]
        [ActionName("SortingUser")]
        public List<Drive> SortingUser([FromBody]string k)
        {
            string ss = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Drives.xml");

            List<Drive> listaDrives = xml.ReadDrives(ss);
            List<Drive> listaDrives2 = new List<Drive>();
            foreach (Drive d in listaDrives)
            {
                if (d.Customer.UserName == k ||d.Dispatcher.UserName == k || d.Driver.UserName == k)//.Customer.UserName == username || d.Dispatcher.UserName == username || d.Driver.UserName == username)
                {
                    listaDrives2.Add(d);
                }
            }
            List<Drive> listaDrives1 = listaDrives2.OrderBy(o=> o.Comment.Rating).ToList();
           
              
            return listaDrives1;
        }
        //[HttpPost]
        //[ActionName("EditUser")]
        //public bool EditUser([FromBody]UserEDit k)
        //{
        //    string ss = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Users.xml");
        //    string adm = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Admins.xml");
        //    string drv = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Drivers.xml");

        //    List<Customer> users = xml.ReadUsers(ss);
        //    List<Dispatcher> admins = xml.ReadDispatcher(adm);
        //    List<Driver> drivers = xml.ReadDrivers(drv);

        //    bool g = true;

        //    foreach (Customer u in users)
        //    {
        //        if (u.UserName == k.Username) //&& u.UserName!=k.OldUsername)
        //        {

        //            g = false;
        //        }
        //    }

        //    foreach (Dispatcher ad in admins)
        //    {
        //        if (ad.UserName == k.Username )//&& ad.UserName != k.OldUsername)
        //        {
        //            g = false;
        //        }
        //    }

        //    foreach (Driver dr in drivers)
        //    {
        //        if (dr.UserName == k.Username )//&& dr.UserName != k.OldUsername)
        //        {
        //            g = false;
        //        }
        //    }

        //    if (g)
        //    {
        //        Customer user = new Customer();
        //       // if(k.Username)
        //        user.UserName = k.Username;
        //        user.Password = k.Password;
        //        user.Name = k.Ime;
        //        user.Surname = k.Prezime;
        //        if (k.Pol == "Female")
        //        {
        //            user.Gender = Enums.GenederType.Female;
        //        }
        //        else
        //        {
        //            user.Gender = Enums.GenederType.Male;
        //        }
        //        //user.JMBG = Int64.Parse(k.Jmbg);
        //        //user.ContactPhoneNumber = k.Telefon;
        //        user.Email = k.Email;
        //        user.Role = Enums.RoleType.Customer;
        //        // user.Drives = new List<Drive>();

        //        users.Add(user);
        //        xml.WriteUsers(users, ss);

        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }

        //}

    }
}
