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

            foreach (Customer us in users)
            {
                if (us.UserName == username)
                {
                    Customer kor = new Customer();
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
                    // DateTime date = DateTime.Now;
                    drive.DataAndTime = String.Format("{0:F}", DateTime.Now);// new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second);
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
                    // DateTime date = DateTime.Now.;
                    drive.DataAndTime = String.Format("{0:F}", DateTime.Now);// new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second);

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
            foreach (Driver d in drivers)
            {
                if (!d.Zauzet && (d.Car.CarType == (Enums.CarType)int.Parse(k.tipAuta)))
                {
                    d.Zauzet = true;
                    drive.Driver = d;
                    p = true;
                    break;
                }
            }
            if (!p)
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
            if (k.Driv == null || k.Stat == null)
            {
                return new List<Drive>();
            }
            //string ss = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Drives.xml");
            List<Drive> listaDrives1 = new List<Drive>();
            foreach (Drive d in k.Driv)
            {
                if (d.Status == (Enums.DriveStatus)int.Parse(k.Stat))// && d.Customer.UserName == k.Username)//.Customer.UserName == username || d.Dispatcher.UserName == username || d.Driver.UserName == username)
                {
                    listaDrives1.Add(d);
                }
            }
            //List<Drive> listaDrives = xml.ReadDrives(ss);
            //if (k.Stat == null)
            //{
            //    return listaDrives;
            //}
            //List<Drive> listaDrives1 = new List<Drive>();
            //if ((Enums.RoleType)int.Parse(k.Role) == Enums.RoleType.Customer)
            //{
            //    foreach (Drive d in listaDrives)
            //    {
            //        if (d.Status == (Enums.DriveStatus)int.Parse(k.Stat) && d.Customer.UserName == k.Username)//.Customer.UserName == username || d.Dispatcher.UserName == username || d.Driver.UserName == username)
            //        {
            //            listaDrives1.Add(d);
            //        }
            //    }
            //}
            //else if((Enums.RoleType)int.Parse(k.Role) == Enums.RoleType.Driver)
            //{
            //    foreach (Drive d in listaDrives)
            //    {
            //        if (d.Status == (Enums.DriveStatus)int.Parse(k.Stat) && d.Driver.UserName == k.Username)//.Customer.UserName == username || d.Dispatcher.UserName == username || d.Driver.UserName == username)
            //        {
            //            listaDrives1.Add(d);
            //        }
            //    }
            //}
            //else if ((Enums.RoleType)int.Parse(k.Role) == Enums.RoleType.Dispatcher)
            //{

            //    foreach (Drive d in listaDrives)
            //    {
            //        if (d.Status == (Enums.DriveStatus)int.Parse(k.Stat) && d.Dispatcher.UserName == k.Username)//.Customer.UserName == username || d.Dispatcher.UserName == username || d.Driver.UserName == username)
            //        {
            //            listaDrives1.Add(d);
            //        }
            //    }
            //}
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

        //[HttpGet]
        //[ActionName("SortingUser")]
        //public List<Drive> SortingUser(string k)
        //{
        //    string ss = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Drives.xml");

        //    List<Drive> listaDrives = xml.ReadDrives(ss);
        //    List<Drive> listaDrives2 = new List<Drive>();
        //    foreach (Drive d in listaDrives)
        //    {
        //        if (d.Customer.UserName == k ||d.Dispatcher.UserName == k || d.Driver.UserName == k)//.Customer.UserName == username || d.Dispatcher.UserName == username || d.Driver.UserName == username)
        //        {
        //            listaDrives2.Add(d);
        //        }
        //    }
        //    List<Drive> listaDrives1 = listaDrives2.OrderByDescending(o=> o.Comment.Rating).ToList();


        //    return listaDrives1;
        //}


        [HttpPost]
        [ActionName("SortingUser")]
        public List<Drive> SortingUser([FromBody] UserSort k)
        {
            //string ss = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Drives.xml");

            List<Drive> listaDrives = k.Driv;//xml.ReadDrives(ss);
            List<Drive> listaDrives1 = new List<Drive>();
            //foreach (Drive d in listaDrives)
            //{
            //    if (d.Customer.UserName == k || d.Dispatcher.UserName == k || d.Driver.UserName == k)//.Customer.UserName == username || d.Dispatcher.UserName == username || d.Driver.UserName == username)
            //    {
            //        listaDrives2.Add(d);
            //    }
            //}
            if (k.PoCemu == 0)
            {
                listaDrives1 = listaDrives.OrderByDescending(o => o.Comment.Rating).ToList();
            }
            else if (k.PoCemu == 1)
            {
                listaDrives1 = listaDrives.OrderByDescending(o => DateTime.Parse(o.DataAndTime)).ToList();

            }

            return listaDrives1;
        }


        [HttpPost]
        [ActionName("SearchUser")]
        public List<Drive> SearchUser([FromBody]UserSearch k)
        {
            if (k.Driv == null)
            {
                return new List<Drive>();
            }
            //string ss = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Drives.xml");
            List<Drive> listaDrives1 = k.Driv;//new List<Drive>();
                                              //foreach (Drive d in k.Driv)
                                              //{
            if (k.DatumOd != null)
            {
                listaDrives1 = listaDrives1.Where(o => DateTime.Parse(o.DataAndTime) >= DateTime.Parse(k.DatumOd)).ToList();
            }
            if (k.DatumDo != null)
            {
                listaDrives1 = listaDrives1.Where(o => DateTime.Parse(o.DataAndTime) <= DateTime.Parse(k.DatumDo)).ToList();
            }
            if (k.CenaOd != null)
            {
                listaDrives1 = listaDrives1.Where(o => o.Amount >= Double.Parse(k.CenaOd)).ToList();
            }
            if (k.CenaDo != null)
            {
                listaDrives1 = listaDrives1.Where(o => o.Amount <= Double.Parse(k.CenaDo)).ToList();
            }
            if (k.OcenaOd != null)
            {
                listaDrives1 = listaDrives1.Where(o => o.Comment.Rating >= int.Parse(k.OcenaOd)).ToList();
            }
            if (k.OcenaDo != null)
            {
                listaDrives1 = listaDrives1.Where(o => o.Comment.Rating <= int.Parse(k.OcenaDo)).ToList();

            }
            if ((Enums.RoleType)int.Parse(k.Role) == Enums.RoleType.Dispatcher)
            {
                if (k.MusIme != null)
                {
                    listaDrives1 = listaDrives1.Where(o => (o.Customer.Name != null && o.Customer.Name.Contains(k.MusIme))).ToList();

                }
                if (k.MusPre != null)
                {
                    listaDrives1 = listaDrives1.Where(o => o.Customer.Surname.Contains(k.MusPre)).ToList();

                }
                if (k.VozIme != null)
                {
                    listaDrives1 = listaDrives1.Where(o => o.Driver.Name.Contains(k.VozIme)).ToList();

                }
                if (k.VozPre != null)
                {
                    listaDrives1 = listaDrives1.Where(o => o.Driver.Surname.Contains(k.VozPre)).ToList();

                }
            }
            return listaDrives1;
        }



        [HttpPost]
        [ActionName("CancelDrive")]
        public Drive CancelDrive([FromBody]VoznjaPrenos k)
        {
            Drive por = new Drive();
            string ss1 = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Drives.xml");
            List<Drive> drives = xml.ReadDrives(ss1);
            foreach (Drive dri in drives)
            {
                if (dri.Customer.UserName == k.dr.Customer.UserName && DateTime.Parse(dri.DataAndTime) == DateTime.Parse(k.dr.DataAndTime))
                {
                    dri.Status = Enums.DriveStatus.Canceled;
                    por = dri;
                    break;
                }
            }
            xml.WriteDrives(drives, ss1);
            return por;
        }


        [HttpPost]
        [ActionName("Commenting")]
        public bool Commenting([FromBody]KomentarPrenos k)
        {
            bool por = false;
            string ss1 = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Drives.xml");
            List<Drive> drives = xml.ReadDrives(ss1);
            foreach (Drive dri in drives)
            {
                if (dri.Customer.UserName == k.voz.Customer.UserName && DateTime.Parse(dri.DataAndTime) == DateTime.Parse(k.voz.DataAndTime))
                {
                    dri.Comment.Date = DateTime.Parse(String.Format("{0:F}", DateTime.Now));
                    dri.Comment.Description = k.KommOpis;
                    dri.Comment.Rating = int.Parse(k.KommOcena);
                    dri.Comment.user = k.voz.Customer.UserName;
                    //dri.Status = Enums.DriveStatus.Canceled;
                    por =true;
                    break;
                }
            }
            xml.WriteDrives(drives, ss1);
            return por;
        }


    }
}
