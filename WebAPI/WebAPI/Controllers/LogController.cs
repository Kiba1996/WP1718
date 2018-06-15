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
            List<User> users = xml.ReadUsers(ss);
            bool g = true;
            foreach (User u in users)
            {
                if (u.UserName == k.Username)
                {

                    g = false;
                }
             }

            if (g)
            {
                User user = new Customer();
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
                user.Drives = new List<Drive>();
               
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
        [ActionName("Login")]
        public User Login([FromBody]UserR1 k)
        {
            string ss = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Users.xml");
            List<User> users = xml.ReadUsers(ss);

            foreach(var v in users)
            {
                if(v.UserName == k.Username && v.Password == k.Password)
                {
                     return v;   
                }
            }

            return null;
        }

        



    }
}
