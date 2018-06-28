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
    public class LogController : ApiController
    {
        public static XMLDataIO xml = new XMLDataIO();
       

        [HttpPost]
        [ActionName("Register")]
        public bool Register([FromBody]UserR k)
        {
            string ss = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Users.xml");
            string adm = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Admins.xml");
            string drv = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Drivers.xml");

            List<Customer> users = xml.ReadUsers(ss);
            List<Dispatcher> admins = xml.ReadDispatcher(adm);
            List<Driver> drivers = xml.ReadDrivers(drv);

            bool g = true;
            
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

            if (g)
            {
                Customer user = new Customer();
                user.UserName = k.Username;
                user.Password = k.Password;
                user.Name = k.Ime;
                user.Surname = k.Prezime;
                if (k.Pol == "Female")
                {
                    user.Gender = Enums.GenederType.Female;
                }
                else
                {
                    user.Gender = Enums.GenederType.Male;
                }
                user.JMBG = Int64.Parse(k.Jmbg);
                user.ContactPhoneNumber = k.Telefon;
                user.Email = k.Email;
                user.Role = Enums.RoleType.Customer;
              
                users.Add(user);
                xml.WriteUsers(users, ss);

                return true;
            }
            else
            {
                return false;
            }
      
        }



        [HttpPost]
        [ActionName("RegisterDriver")]
        public bool RegisterDriver([FromBody]DriverR k)
        {
            string ss = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Users.xml");
            string adm = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Admins.xml");
            string drv = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Drivers.xml");
            string ca = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Cars.xml");

            List<Customer> users = xml.ReadUsers(ss);
            List<Dispatcher> admins = xml.ReadDispatcher(adm);
            List<Driver> drivers = xml.ReadDrivers(drv);
            List<Car> cars = xml.ReadCars(ca);

            Car auto = new Car();
            bool g = true;

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

            if (g)
            {
                Driver user = new Driver();
                user.UserName = k.Username;
                user.Password = k.Password;
                user.Name = k.Ime;
                user.Surname = k.Prezime;
                if (k.Pol == "Female")
                {
                    user.Gender = Enums.GenederType.Female;
                }
                else
                {
                    user.Gender = Enums.GenederType.Male;
                }
                user.JMBG = Int64.Parse(k.Jmbg);
                user.ContactPhoneNumber = k.Telefon;
                user.Email = k.Email;
                user.Role = Enums.RoleType.Driver;
                user.Location = new Location("19.849211","45.242780", new Address("10,Вељка Петровића,Лиман 1,Нови Сад,Град Нови Сад,Јужнобачки округ,Војводина,21102,Србија"));
                user.Zauzet = false;
                int brojAuta = cars.Count() +1;
                
                foreach(Car car in cars) {

                    if(car.RegistrationNumber == k.Reg)
                    {
                        return false;
                       
                    }
                }

                user.Car = new Car(k.Username, k.Year, k.Reg, brojAuta, (Enums.CarType)int.Parse(k.tipVoz));

                cars.Add(user.Car);
                drivers.Add(user);
                xml.WriteCars(cars, ca);
                xml.WriteDrivers(drivers, drv);

                return true;
            }
            else
            {
                return false;
            }

        }




        [HttpPost]
        [ActionName("Login")]
        public User Login([FromBody]UserR1 k)
        {
            string ss = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Users.xml");
            string adm = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Admins.xml");
            string drv = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Drivers.xml");

            List<Customer> users = xml.ReadUsers(ss);
            List<Dispatcher> admins = xml.ReadDispatcher(adm);
            List<Driver> drivers = xml.ReadDrivers(drv);

            foreach (var v in users)
            {
                if(v.UserName == k.Username && v.Password == k.Password)
                {
                     return v;   
                }
            }
            foreach (var v in admins)
            {
                if (v.UserName == k.Username && v.Password == k.Password)
                {
                    return v;
                }
            }

            foreach (var v in drivers)
            {
                if (v.UserName == k.Username && v.Password == k.Password)
                {
                    return v;
                }
            }

            return null;
        }

       
        [HttpGet]
        [ActionName("GetDrives")]
        public List<Drive> GetDrives(string username)
        {
            string ss = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Drives.xml");

            List<Drive> listaDrives = xml.ReadDrives(ss);
            List<Drive> listaDrives1 = new List<Drive>();
            foreach (Drive d in listaDrives)
            {
                if (d.Customer.UserName == username || d.Dispatcher.UserName == username || d.Driver.UserName == username)
                {
                    listaDrives1.Add(d);
                }
            }
            return listaDrives1;
        }

      
        [HttpGet]
        [ActionName("GetDrivesAdmin")]
        public List<Drive> GetDrivesAdmin(string username)
        {
            string ss = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Drives.xml");

            List<Drive> listaDrives = xml.ReadDrives(ss);
           
            return listaDrives;
        }

        [HttpGet]
        [ActionName("GetDrivesDriver")]
        public List<Drive> GetDrivesDriver(string username)
        {
            string ss = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Drives.xml");

            List<Drive> listaDrives = xml.ReadDrives(ss);
            List<Drive> listaDrives1 = new List<Drive>();
            foreach (Drive d in listaDrives)
            {
                if (d.Status == Enums.DriveStatus.Created_Waiting)
                {
                listaDrives1.Add(d);
                }
            }
            return listaDrives1;
        }

    }
}
