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
        [ActionName("getUserStatus")]
        public bool getUserStatus(string username)
        {
            string ss = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Users.xml");
            string drv = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Drivers.xml");

            List<Customer> users = xml.ReadUsers(ss);
            List<Driver> drivers = xml.ReadDrivers(drv);

            bool ret = false;

            foreach (Customer c in users)
            {
                if (c.UserName == username && c.Blocked == true)
                {
                    ret = true;
                    break;
                }
            }
            if (!ret)
            {
                foreach (Driver d in drivers)
                {
                    if (d.UserName == username && d.Blocked == true)
                    {
                        ret = true;
                        break;
                    }
                }
            }
            return ret;

        }

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



        [HttpGet]
        [ActionName("getDriverData")]
        public DriverPrenos getDriverData(string username)
        {

            string drv = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Drivers.xml");

            bool x = false;
            List<Driver> drivers = xml.ReadDrivers(drv);
            DriverPrenos ret = new DriverPrenos();
            foreach (Driver us in drivers)
            {
                if (us.UserName == username)
                {
                    ret.tipAuta = us.Car.CarType;
                    ret.zauzet = us.Zauzet;
                    ret.lokacija = us.Location;
                    x = true;
                }
            }
            if (!x)
            {
                ret.tipAuta = Enums.CarType.NoType;
                ret.zauzet = true;
                ret.lokacija = new Location();
            }

            return ret;
        }

        
        [HttpGet]
        [ActionName("Block")]
        public List<User> Block(string username)
        {
            string ss = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Users.xml");
            string drv = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Drivers.xml");

            List<Customer> users = xml.ReadUsers(ss);
            List<Driver> drivers = xml.ReadDrivers(drv);

            List<User> list = new List<User>();

            foreach (Customer c in users)
            {
                if(c.UserName == username)
                {
                    c.Blocked = true;
                }

                if (c.Blocked == false)
                {
                    list.Add(c);
                }
            }

            foreach (Driver d in drivers)
            {
                if (d.UserName == username)
                {
                    d.Blocked = true;
                }

                if (d.Blocked == false)
                {
                    list.Add(d);
                }
            }


            xml.WriteUsers(users, ss);
            xml.WriteDrivers(drivers, drv);
            return list;

        }

        [HttpGet]
        [ActionName("Unblock")]
        public List<User> Unblock(string username)
        {
            string ss = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Users.xml");
            string drv = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Drivers.xml");

            List<Customer> users = xml.ReadUsers(ss);
            List<Driver> drivers = xml.ReadDrivers(drv);

            List<User> list = new List<User>();

            foreach (Customer c in users)
            {
                if (c.UserName == username)
                {
                    c.Blocked = false;
                }

                if (c.Blocked == true)
                {
                    list.Add(c);
                }
            }

            foreach (Driver d in drivers)
            {
                if (d.UserName == username)
                {
                    d.Blocked = false;
                }

                if (d.Blocked == true)
                {
                    list.Add(d);
                }
            }

            xml.WriteUsers(users, ss);
            xml.WriteDrivers(drivers, drv);

            return list;

        }


        [HttpGet]
        [ActionName("getBlockedUsers")]
        public List<User> getBlockedUsers()
        {
            string ss = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Users.xml");
            string drv = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Drivers.xml");

            List<Customer> users = xml.ReadUsers(ss);
            List<Driver> drivers = xml.ReadDrivers(drv);

            List<User> list = new List<User>();

            foreach(Customer c in users)
            {
                if(c.Blocked == true)
                {
                    list.Add(c);
                }
            }

            foreach(Driver d in drivers)
            {
                if(d.Blocked == true)
                {
                    list.Add(d);
                }
            }

            return list;

        }

        [HttpGet]
        [ActionName("getUnblockedUsers")]
        public List<User> getUnblockedUsers()
        {
            string ss = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Users.xml");
            string drv = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Drivers.xml");

            List<Customer> users = xml.ReadUsers(ss);
            List<Driver> drivers = xml.ReadDrivers(drv);

            List<User> list = new List<User>();

            foreach (Customer c in users)
            {
                if (c.Blocked == false)
                {
                    list.Add(c);
                }
            }

            foreach (Driver d in drivers)
            {
                if (d.Blocked == false)
                {
                    list.Add(d);
                }
            }

            return list;

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
                    Address a = new Address(k.Street);  //, k.Number, k.Town, Int32.Parse(k.PostalCode));
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
        public List<string> AddDriveDispatcher([FromBody]DriveR k)
        {

            ClosestDistance closest = new ClosestDistance();

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
           

            bool p = false;



            List<Tuple<Point, string>> proslediListu = new List<Tuple<Point, string>>();


            foreach (Driver d in drivers)
            {
                if (!d.Zauzet && (d.Car.CarType == (Enums.CarType)int.Parse(k.tipAuta)))
                {
                    Point poi = new Point();
                    poi.X = Double.Parse(d.Location.X);
                    poi.Y = Double.Parse(d.Location.Y);
                    proslediListu.Add(new Tuple<Point, string>(poi, d.UserName));
                    //d.Zauzet = true;
                    //drive.Driver = d;
                    //p = true;
                    //break;
                }
            }

            List<string> najblizi = new List<string>();

            if (!proslediListu.Any())
            {
                foreach (Dispatcher u in users)
                {
                    if (u.UserName == k.korisnicko)
                    {
                        c = u;
                        Address a = new Address(k.Street);//, k.Number, k.Town, Int32.Parse(k.PostalCode));
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
                        drive.Driver = new Driver();
                        drive.Status = Enums.DriveStatus.Created_Waiting;
                        // u.Drives.Add(drive);
                        break;
                        //  g = false;
                    }
                }

                drives.Add(drive);
                // xml.WriteDrivers(drivers, drv);
                xml.WriteDrives(drives, ss1);

                

            }
            else
            {
 
                Point ip = new Point();
                ip.X = Double.Parse(k.XCoord);
                ip.Y = Double.Parse(k.YCoord);
                najblizi = closest.OrderByDistance(proslediListu, ip);
            }

            return najblizi;

        }


       
         [HttpPost]
        [ActionName("DodajVoznjuKonacno")]
        public bool DodajVoznjuKonacno([FromBody]konacnaVoznja k)
        {

            //ClosestDistance closest = new ClosestDistance();

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
                if (u.UserName == k.korisnickoAdmin)
                {
                    c = u;
                    Address a = new Address(k.voz.Street);//, k.Number, k.Town, Int32.Parse(k.PostalCode));
                    Location l = new Location(k.voz.XCoord, k.voz.YCoord, a);
                    drive.Customer = new Customer();
                    drive.Arrival = l;
                    if (k.voz.tipAuta != "")
                    {
                        drive.CarType = (Enums.CarType)int.Parse(k.voz.tipAuta);
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

            foreach(Driver driver in drivers)
            {
                if(driver.UserName == k.korisnickoVozac)
                {
                    driver.Zauzet = true;
                    drive.Driver = driver;
                    break;
                }
            }
            drives.Add(drive);
            xml.WriteDrivers(drivers, drv);
            xml.WriteDrives(drives, ss1);

            // return true;

            return true;
        }


        
        [HttpPost]
        [ActionName("ObradiVoznjuKonacno")]
        public bool ObradiVoznjuKonacno([FromBody]konacnaVoznjaObrada k)
        {

            //ClosestDistance closest = new ClosestDistance();

            string ss = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Users.xml");
            string ss1 = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Drives.xml");
            string adm = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Admins.xml");
            string drv = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Drivers.xml");

            List<Dispatcher> users = xml.ReadDispatcher(adm);
            List<Drive> drives = xml.ReadDrives(ss1);
            List<Driver> drivers = xml.ReadDrivers(drv);

            // bool g = true;
            User c = new Dispatcher();
            Driver driver = new Driver();





            foreach (Dispatcher u in users)
            {
                if (u.UserName == k.korisnickoAdmin)
                {
                    c = u; 
                    break;
                   
                }
            }

            foreach (Driver dre in drivers)
            {
                if (dre.UserName == k.korisnickoVozac)
                {
                    dre.Zauzet = true;
                    driver = dre;
                    break;
                }
            }

            foreach(Drive dr in drives)
            {
                if(DateTime.Parse(dr.DataAndTime) == DateTime.Parse(k.voz.DataAndTime) && (dr.Customer.UserName == k.voz.Customer.UserName || dr.Dispatcher.UserName == k.voz.Dispatcher.UserName))
                {

                    dr.Driver = driver;
                    dr.Dispatcher = (Dispatcher)c;
                    dr.Status = Enums.DriveStatus.Processed;

                }
            }

           
            xml.WriteDrivers(drivers, drv);
            xml.WriteDrives(drives, ss1);

            // return true;

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

            string ss = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Drivers.xml");

            List<Driver> listaDrivers = xml.ReadDrivers(ss);


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
            else if(k.PoCemu == 2)
            {


                Point po = new Point();
                foreach(Driver driv in listaDrivers)
                {
                    if(driv.UserName == k.Username)
                    {
                        po.X = Double.Parse(driv.Location.X);
                        po.Y = Double.Parse(driv.Location.Y);
                    }
                }

                ClosestDistance cd = new ClosestDistance();
                listaDrives1 = cd.OrderByDistanceForDrivers(listaDrives, po);

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

        [HttpPost]
        [ActionName("Comment")]
        public bool Comment([FromBody]KomentarVozacPrenos k)
        {
            bool por = false;
            string ss1 = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Drives.xml");
            string drv = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Drivers.xml");

            List<Drive> drives = xml.ReadDrives(ss1);
            List<Driver> drivers = xml.ReadDrivers(drv);

            //foreach(Driver kp in drivers)
            //{
            //    if(kp.UserName == k.voz.Driver.UserName)
            //    {
            //        kp.Zauzet = false;
            //        por = true;
            //    }
            //}

            //if (por)
            //{
                foreach (Drive dri in drives)
                {
                    if (dri.Driver.UserName == k.voz.Driver.UserName && DateTime.Parse(dri.DataAndTime) == DateTime.Parse(k.voz.DataAndTime))
                    {
                        dri.Comment.Date = DateTime.Parse(String.Format("{0:F}", DateTime.Now));
                        dri.Comment.Description = k.KommOpis;
                        dri.Comment.Rating = 0;//int.Parse(k.KommOcena);
                        dri.Comment.user = k.voz.Driver.UserName;
                        dri.Driver.Zauzet = false;
                        dri.Status = Enums.DriveStatus.Unsuccessful;
                        //dri.Status = Enums.DriveStatus.Canceled;
                        por = true;
                        break;
                    }
              //  }
            }
            if (por)
            {
                foreach (Driver kp in drivers)
                {
                    if (kp.UserName == k.voz.Driver.UserName)
                    {
                        kp.Zauzet = false;
                        break;
                    }
                }
            }
            xml.WriteDrives(drives, ss1);
            xml.WriteDrivers(drivers, drv);
            return por;
        }


        [HttpPost]
        [ActionName("ProcessDrive")]
        public List<string> ProcessDrive([FromBody]KomentarVozacPrenos k)
        {
            Drive por = new Drive();
            string ss1 = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Drives.xml");
            string drv = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Drivers.xml");
            string adm = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Admins.xml");
            List<Dispatcher> dispatchers = xml.ReadDispatcher(adm);
            List<Drive> drives = xml.ReadDrives(ss1);
            List<Driver> drivers = xml.ReadDrivers(drv);

            ClosestDistance cd = new ClosestDistance();
            bool p = false;
          //  Drive promenjena = new Drive(); 
            Driver driver = new Driver();
            Dispatcher dispacer = new Dispatcher();
            // List<Drive> li = new List<Drive>();
            //li = k.voznje;
            List<Tuple<Point, string>> proslediListu = new List<Tuple<Point, string>>();


            foreach (Driver d in drivers)
            {
                if (!d.Zauzet && (d.Car.CarType == k.voz.CarType))
                {
                    Point poi = new Point();
                    poi.X = Double.Parse(d.Location.X);
                    poi.Y = Double.Parse(d.Location.Y);
                    proslediListu.Add(new Tuple<Point, string>(poi, d.UserName));
                    //d.Zauzet = true;
                    //drive.Driver = d;
                    //p = true;
                    //break;
                }
            }

            List<string> najblizi = new List<string>();

            if (proslediListu.Any())
            {
           
                Point ip = new Point();
                ip.X = Double.Parse(k.voz.Arrival.X);
                ip.Y = Double.Parse(k.voz.Arrival.Y);
                najblizi = cd.OrderByDistance(proslediListu, ip);
            }

            return najblizi;

        }


        [HttpPost]
        [ActionName("AcceptDrive")]
        public List<Drive> AcceptDrive([FromBody]ObradaPrenos k)
        {
            Drive por = new Drive();
            string ss1 = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Drives.xml");
            string drv = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Drivers.xml");
            //string adm = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Admins.xml");
            //List<Dispatcher> dispatchers = xml.ReadDispatcher(adm);
            List<Drive> drives = xml.ReadDrives(ss1);
            List<Driver> drivers = xml.ReadDrivers(drv);

            bool p = false;
            //  Drive promenjena = new Drive(); 
            Driver driver = new Driver();
            //Dispatcher dispacer = new Dispatcher();
            // List<Drive> li = new List<Drive>();
            //li = k.voznje;
            foreach (Driver d in drivers)
            {
                if (d.UserName == k.korisnicko)
                {
                    d.Zauzet = true;
                    driver = d;
                    p = true;
                    break;
                }
            }

           
            //if (!p)
            //{
            //    drive.Status = Enums.DriveStatus.Created_Waiting;
            //    drive.Driver = new Driver();
            //}

            if (p)
            {
                foreach (Drive dri in drives)
                {
                    if ((dri.Customer.UserName == k.dr.Customer.UserName || dri.Dispatcher.UserName == k.dr.Dispatcher.UserName) && DateTime.Parse(dri.DataAndTime) == DateTime.Parse(k.dr.DataAndTime))
                    {

                        dri.Status = Enums.DriveStatus.Accepted;
                        //dri.Driver.Zauzet = true;
                        dri.Driver = driver;
                       
                        //por = dri;
                        // promenjena = dri;
                        break;
                    }
                }

                int i = 0;
                foreach (Drive w in k.voznje)
                { 
                    if ((w.Customer.UserName == k.dr.Customer.UserName || w.Dispatcher.UserName == k.dr.Dispatcher.UserName) && DateTime.Parse(w.DataAndTime) == DateTime.Parse(k.dr.DataAndTime))
                    {
                        break;
                        
                    }
                    i++;
                }


                k.voznje.RemoveAt(i);

                xml.WriteDrives(drives, ss1);
                xml.WriteDrivers(drivers, drv);
            }


            return k.voznje;//por;
        }
        


        [ActionName("SuccessDrive")]
        public bool SuccessDrive([FromBody]SuccessDrivePrenos k)
        {
            bool por = false;
            string ss1 = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Drives.xml");
            string drv = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Drivers.xml");

            List<Drive> drives = xml.ReadDrives(ss1);
            List<Driver> drivers = xml.ReadDrivers(drv);

            //foreach(Driver kp in drivers)
            //{
            //    if(kp.UserName == k.voz.Driver.UserName)
            //    {
            //        kp.Zauzet = false;
            //        por = true;
            //    }
            //}

            //if (por)
            //{
            foreach (Drive dri in drives)
            {
                if (dri.Driver.UserName == k.voznja.Driver.UserName && DateTime.Parse(dri.DataAndTime) == DateTime.Parse(k.voznja.DataAndTime))
                {
                    dri.Amount = k.Cena;
                    dri.Destination.X = k.XCoord;
                    dri.Destination.Y = k.YCoord;
                    dri.Destination.Address.AddressFormat = k.Street;



                    dri.Driver.Location.Address.AddressFormat = k.Street;
                    dri.Driver.Location.X = k.XCoord;
                    dri.Driver.Location.Y = k.YCoord;

                    //.Street = k.Street;
                    //dri.Destination.Address.Number = k.Number;
                    //dri.Destination.Address.Town = k.Town;
                    //dri.Destination.Address.PostalCode = int.Parse(k.PostalCode);

                  
                    dri.Driver.Zauzet = false;
                    dri.Status = Enums.DriveStatus.Successful;
                    //dri.Status = Enums.DriveStatus.Canceled;
                    por = true;
                    break;
                }
                //  }
            }
            if (por)
            {
                foreach (Driver kp in drivers)
                {
                    if (kp.UserName == k.voznja.Driver.UserName)
                    {
                        kp.Zauzet = false;
                        kp.Location.Address.AddressFormat = k.Street;
                        kp.Location.X = k.XCoord;
                        kp.Location.Y = k.YCoord;

                        break;
                    }
                }
            }
            xml.WriteDrives(drives, ss1);
            xml.WriteDrivers(drivers, drv);
            return por;
        }



        [HttpPost]
        [ActionName("EditUser")]
        public int EditUser([FromBody]UserEDit k)
        {
           
            string ss = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Users.xml");
            string adm = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Admins.xml");
            string drv = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Drivers.xml");
            string drv1 = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Drives.xml");
            string auto = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Cars.xml");

            List<Customer> users = xml.ReadUsers(ss);
            List<Dispatcher> admins = xml.ReadDispatcher(adm);
            List<Driver> drivers = xml.ReadDrivers(drv);
            List<Drive> drives = xml.ReadDrives(drv1);
            List<Car> cars = xml.ReadCars(auto);

            Customer c = new Customer();
            Dispatcher a = new Dispatcher();
            Driver d = new Driver();
                

            bool g = true;
            int q = 3;
            if (k.OldUsername != k.Username)
            {
                foreach (Customer u in users)
                {
                    if (u.UserName == k.Username)
                    {

                        g = false;
                    }
                }

                foreach (Dispatcher ad in admins)
                {
                    if (ad.UserName == k.Username)
                    {
                        g = false;
                    }
                }

                foreach (Driver dr in drivers)
                {
                    if (dr.UserName == k.Username)
                    {
                        g = false;
                    }
                }
            }
            if (g)
            {
                //int cCounter = 0;
                //int aCounter = 0;
                //int dCounter = 0;
                foreach (Customer u in users)
                {
                    if (u.UserName == k.OldUsername)
                    {
                        
                        u.UserName = k.Username;
                        u.Password = k.Password;
                        u.Name = k.Ime;
                        u.Surname = k.Prezime;
                        if (k.Pol == "Female")
                        {
                            u.Gender = Enums.GenederType.Female;
                        }
                        else
                        {
                            u.Gender = Enums.GenederType.Male;
                        }
                        u.JMBG = Int64.Parse(k.Jmbg);
                        u.ContactPhoneNumber = k.Telefon;
                        u.Email = k.Email;

                       // users.ad(user);
                        
                        q = 0;
                        c = u;

                    }
                    
                }

                foreach (Dispatcher u in admins)
                {
                    if (u.UserName == k.OldUsername)
                    {
                        u.UserName = k.Username;
                        u.Password = k.Password;
                        u.Name = k.Ime;
                        u.Surname = k.Prezime;
                        if (k.Pol == "Female" || k.Pol=="1")
                        {
                            u.Gender = Enums.GenederType.Female;
                        }
                        else
                        {
                            u.Gender = Enums.GenederType.Male;
                        }
                        u.JMBG = Int64.Parse(k.Jmbg);
                        u.ContactPhoneNumber = k.Telefon;
                        u.Email = k.Email;


                        q = 1;
                        a = u;
                    }
                }
                foreach(Driver u in drivers)
                {
                    if (u.UserName == k.OldUsername)
                    {
                        u.UserName = k.Username;
                        if (k.Password != null)
                        {
                            u.Password = k.Password;
                        }
                        u.Name = k.Ime;
                        u.Surname = k.Prezime;
                        if (k.Pol == "Female")
                        {
                            u.Gender = Enums.GenederType.Female;
                        }
                        else
                        {
                            u.Gender = Enums.GenederType.Male;
                        }
                        u.JMBG = Int64.Parse(k.Jmbg);
                        u.ContactPhoneNumber = k.Telefon;
                        u.Email = k.Email;

                        u.Car.Driver = k.Username;

                        q = 2;
                        d = u;
                    }
                }
                if (q == 0)
                {

                    foreach(Drive dri in drives)
                    {
                        if (dri.Customer.UserName == k.OldUsername)
                        {
                            dri.Customer.UserName = k.Username;
                            dri.Customer.Surname = k.Prezime;
                            //dri.Customer.Role = c.Role;
                            dri.Customer.Password = k.Password;
                            dri.Customer.Name = k.Ime;
                            dri.Customer.JMBG = Int64.Parse(k.Jmbg);
                            if (k.Pol == "Female")
                            {
                                dri.Customer.Gender = Enums.GenederType.Female;
                            }
                            else
                            {
                                dri.Customer.Gender = Enums.GenederType.Male;
                            }
                           
                            dri.Customer.Email = k.Email;
                           // dri.Customer.Drives = c.Drives;
                            dri.Customer.ContactPhoneNumber = k.Telefon;
                        }
                    }


                    xml.WriteUsers(users, ss);
                    xml.WriteDrives(drives, drv1);
                    //return 1;
                }
                if (q == 1)
                {
                    foreach (Drive dri in drives)
                    {
                        if (dri.Dispatcher.UserName == k.OldUsername)
                        {
                            dri.Dispatcher.UserName = k.Username;
                            dri.Dispatcher.Surname = k.Prezime;
                            //dri.Customer.Role = c.Role;
                            dri.Dispatcher.Password = k.Password;
                            dri.Dispatcher.Name = k.Ime;
                            dri.Dispatcher.JMBG = Int64.Parse(k.Jmbg);
                            if (k.Pol == "Female")
                            {
                                dri.Dispatcher.Gender = Enums.GenederType.Female;
                            }
                            else
                            {
                                dri.Dispatcher.Gender = Enums.GenederType.Male;
                            }

                            dri.Dispatcher.Email = k.Email;
                            // dri.Customer.Drives = c.Drives;
                            dri.Dispatcher.ContactPhoneNumber = k.Telefon;
                        }
                    }
                    xml.WriteDispatchers(admins, adm);
                    xml.WriteDrives(drives, drv1);
                    // return 2;
                }
                if (q == 2)
                {
                    foreach (Drive dri in drives)
                    {
                        if (dri.Driver.UserName == k.OldUsername)
                        {
                            dri.Driver.UserName = k.Username;
                            dri.Driver.Surname = k.Prezime;
                            //dri.Customer.Role = c.Role;
                            dri.Driver.Password = k.Password;
                            dri.Driver.Name = k.Ime;
                            dri.Driver.JMBG = Int64.Parse(k.Jmbg);
                            if (k.Pol == "Female")
                            {
                                dri.Driver.Gender = Enums.GenederType.Female;
                            }
                            else
                            {
                                dri.Driver.Gender = Enums.GenederType.Male;
                            }

                            dri.Driver.Email = k.Email;
                            // dri.Customer.Drives = c.Drives;
                            dri.Driver.ContactPhoneNumber = k.Telefon;
                        }
                    }
                    foreach(Car ca in cars){
                        if(ca.Driver == k.OldUsername)
                        {
                            ca.Driver = k.Username;
                        }
                    }

                    xml.WriteDrivers(drivers, drv);
                    xml.WriteDrives(drives, drv1);
                    xml.WriteCars(cars, auto);
                    //return 3;
                }
                
                return q;

            }
            else
            {
               
                return q;
            }

        }



        [HttpPost]
        [ActionName("ChangeDriveCustomer")]
        public bool ChangeDriveCustomer([FromBody]ChangeDrivePrenos k)
        {
            //string ss = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Users.xml");
            string ss1 = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Drives.xml");

           // List<Customer> users = xml.ReadUsers(ss);
            List<Drive> drives = xml.ReadDrives(ss1);
            // bool g = true;
            User c = new Customer();
            Drive drive = new Drive();
            foreach (Drive u in drives)
            {
                if (u.Customer.UserName == k.korisnicko && DateTime.Parse(u.DataAndTime) == DateTime.Parse(k.datum))
                {

                    u.Arrival.Address.AddressFormat = k.Street;
                    u.Arrival.X = k.XCoord;
                    u.Arrival.Y = k.YCoord;
                    u.CarType = (Enums.CarType)int.Parse(k.tipAuta);
                   
                }
            }

            //drives.Add(drive);
            //xml.WriteUsers(users, ss);
            xml.WriteDrives(drives, ss1);

            return true;

        }



        [HttpPost]
        [ActionName("ChangeLocation")]
        public bool ChangeLocation([FromBody]ChangeDrivePrenos k)
        {
            string drv = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Drivers.xml");
            string drv1 = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Drives.xml");

            List<Drive> drives = xml.ReadDrives(drv1);
            List<Driver> drivers = xml.ReadDrivers(drv);


            foreach(Driver drov in drivers)
            {
                if(drov.UserName == k.korisnicko)
                {
                    drov.Location.Address.AddressFormat = k.Street;
                    drov.Location.X = k.XCoord;
                    drov.Location.Y = k.YCoord;
                }
            }

            foreach(Drive dv in drives)
            {
                if(dv.Driver.UserName == k.korisnicko)
                {
                    dv.Driver.Location.Address.AddressFormat = k.Street;
                    dv.Driver.Location.X = k.XCoord;
                    dv.Driver.Location.Y = k.YCoord;
                }
            }

            xml.WriteDrives(drives, drv1);
            xml.WriteDrivers(drivers, drv);

            return true;
        }
    }
}
