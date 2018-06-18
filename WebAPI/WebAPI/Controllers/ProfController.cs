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

            List<Dispatcher> users = xml.ReadDispatcher(adm);
            List<Drive> drives = xml.ReadDrives(ss1);
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

    }
}
